using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Vendinha.Contexts;
using Vendinha.Models;

namespace Vendinha.Services
{
    /// <summary>
    /// Camada de negócio: regras e validações de dívidas.
    /// </summary>
    public class DividaService
    {
        private readonly VendinhaDbContext context;

        public DividaService(VendinhaDbContext context)
        {
            this.context = context;
        }

        public DividaService() : this(new VendinhaDbContext(Configuracao.ConnectionString))
        {
        }

        /// <summary>
        /// Lista as dívidas de um cliente (em aberto primeiro, depois as mais recentes).
        /// </summary>
        public List<Divida> ListarPorCliente(int clienteId)
        {
            return context.Dividas
                .AsNoTracking()
                .Where(d => d.ClienteId == clienteId)
                .OrderBy(d => d.Paga)
                .ThenByDescending(d => d.DataCriacao)
                .ToList();
        }

        /// <summary>
        /// Cadastra uma dívida para o cliente.
        /// Regra: um cliente só pode ter uma dívida em aberto.
        /// A verificação e o INSERT acontecem dentro de uma transação (ACID).
        /// </summary>
        public bool Criar(int clienteId, decimal valor, out List<ValidationResult> erros)
        {
            var divida = new Divida
            {
                ClienteId = clienteId,
                Valor = valor,
                Paga = false,
                DataCriacao = DateTime.UtcNow
            };

            erros = new List<ValidationResult>();
            if (valor <= 0)
            {
                erros.Add(new ValidationResult("O valor da dívida deve ser maior que zero.", new[] { nameof(Divida.Valor) }));
                return false;
            }

            // BEGIN TRANSACTION: a verificação e a gravação são uma unidade só.
            // O índice único parcial (uq_dividas_uma_em_aberto) garante a regra mesmo com acessos simultâneos.
            using var transacao = context.Database.BeginTransaction();
            try
            {
                if (!context.Clientes.Any(c => c.Id == clienteId))
                {
                    erros.Add(new ValidationResult("Cliente não encontrado."));
                    transacao.Rollback();
                    return false;
                }

                if (context.Dividas.Any(d => d.ClienteId == clienteId && !d.Paga))
                {
                    erros.Add(new ValidationResult("O cliente já possui uma dívida em aberto. Quite-a antes de lançar outra."));
                    transacao.Rollback();
                    return false;
                }

                context.Dividas.Add(divida);
                context.SaveChanges();
                transacao.Commit();      // COMMIT
                return true;
            }
            catch (DbUpdateException)
            {
                transacao.Rollback();    // ROLLBACK
                context.Entry(divida).State = EntityState.Detached;
                erros.Add(new ValidationResult("Não foi possível salvar a dívida. Verifique se o cliente já possui uma dívida em aberto."));
                return false;
            }
        }

        /// <summary>
        /// Marca a dívida como paga, registrando a data de pagamento.
        /// </summary>
        public bool MarcarComoPaga(int dividaId, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();

            var divida = context.Dividas.FirstOrDefault(d => d.Id == dividaId);
            if (divida == null)
            {
                erros.Add(new ValidationResult("Dívida não encontrada."));
                return false;
            }

            if (divida.Paga)
            {
                erros.Add(new ValidationResult("Esta dívida já está paga."));
                return false;
            }

            divida.Paga = true;
            divida.DataPagamento = DateTime.UtcNow;
            context.SaveChanges();
            return true;
        }

        public bool Excluir(int dividaId, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();

            var divida = context.Dividas.FirstOrDefault(d => d.Id == dividaId);
            if (divida == null)
            {
                erros.Add(new ValidationResult("Dívida não encontrada."));
                return false;
            }

            context.Dividas.Remove(divida);
            context.SaveChanges();
            return true;
        }
    }
}

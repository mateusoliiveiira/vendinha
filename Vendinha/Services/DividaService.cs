using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Vendinha.Contexts;
using Vendinha.Models;

namespace Vendinha.Services
{
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

        public List<Divida> ListarPorCliente(int clienteId)
        {
            return context.Dividas
                .AsNoTracking()
                .Where(d => d.ClienteId == clienteId)
                .OrderBy(d => d.Paga)
                .ThenByDescending(d => d.DataCriacao)
                .ToList();
        }

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
                transacao.Commit();
                return true;
            }
            catch (DbUpdateException)
            {
                transacao.Rollback();
                context.Entry(divida).State = EntityState.Detached;
                erros.Add(new ValidationResult("Não foi possível salvar a dívida. Verifique se o cliente já possui uma dívida em aberto."));
                return false;
            }
        }

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

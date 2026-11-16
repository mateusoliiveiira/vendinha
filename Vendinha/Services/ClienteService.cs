using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Vendinha.Contexts;
using Vendinha.Models;

namespace Vendinha.Services
{
    public class ClienteService
    {
        public const int TamanhoPaginaPadrao = 10;

        private readonly VendinhaDbContext context;

        public ClienteService(VendinhaDbContext context)
        {
            this.context = context;
        }

        public ClienteService() : this(new VendinhaDbContext(Configuracao.ConnectionString))
        {
        }

        public Pagina<ClienteResumo> Listar(string? pesquisa = null, int pagina = 1, int tamanhoPagina = TamanhoPaginaPadrao)
        {
            if (pagina < 1) pagina = 1;
            if (tamanhoPagina < 1) tamanhoPagina = TamanhoPaginaPadrao;

            var consulta = context.Clientes.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                var termo = "%" + pesquisa.Trim() + "%";
                consulta = consulta.Where(c => EF.Functions.ILike(c.Nome, termo));
            }

            var total = consulta.Count();

            var itens = consulta
                .Select(c => new ClienteResumo
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Cpf = c.Cpf,
                    DataNascimento = c.DataNascimento,
                    Email = c.Email,
                    TotalDividas = c.Dividas
                        .Where(d => !d.Paga)
                        .Sum(d => (decimal?)d.Valor) ?? 0
                })
                .OrderByDescending(c => c.TotalDividas)
                .ThenBy(c => c.Nome)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList();

            return new Pagina<ClienteResumo>
            {
                Itens = itens,
                NumeroPagina = pagina,
                TamanhoPagina = tamanhoPagina,
                TotalItens = total
            };
        }

        public Cliente? Buscar(int id)
        {
            return context.Clientes.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public bool Criar(Cliente cliente, out List<ValidationResult> erros)
        {
            if (!Validar(cliente, out erros))
            {
                return false;
            }

            try
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                context.Entry(cliente).State = EntityState.Detached;
                erros.Add(new ValidationResult("Não foi possível salvar o cliente. Verifique se o CPF já está cadastrado."));
                return false;
            }
        }

        public bool Atualizar(int id, Cliente dados, out List<ValidationResult> erros)
        {
            var cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                erros = new List<ValidationResult> { new ValidationResult("Cliente não encontrado.") };
                return false;
            }

            dados.Id = id;
            if (!Validar(dados, out erros))
            {
                return false;
            }

            cliente.Nome = dados.Nome;
            cliente.Cpf = dados.Cpf;
            cliente.DataNascimento = dados.DataNascimento;
            cliente.Email = dados.Email;

            context.SaveChanges();
            return true;
        }

        public bool Excluir(int id, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();

            var cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                erros.Add(new ValidationResult("Cliente não encontrado."));
                return false;
            }

            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return true;
        }

        public bool Validar(Cliente cliente, out List<ValidationResult> erros)
        {
            var validationContext = new ValidationContext(cliente);
            erros = new List<ValidationResult>();
            Validator.TryValidateObject(cliente, validationContext, erros, true);

            if (cliente.DataNascimento == default)
            {
                erros.Add(new ValidationResult("A data de nascimento é obrigatória.", new[] { nameof(Cliente.DataNascimento) }));
            }
            else if (cliente.DataNascimento.Date > DateTime.Today)
            {
                erros.Add(new ValidationResult("A data de nascimento não pode ser no futuro.", new[] { nameof(Cliente.DataNascimento) }));
            }

            if (!string.IsNullOrEmpty(cliente.Cpf) &&
                context.Clientes.Any(c => c.Cpf == cliente.Cpf && c.Id != cliente.Id))
            {
                erros.Add(new ValidationResult("Já existe um cliente cadastrado com este CPF.", new[] { nameof(Cliente.Cpf) }));
            }

            return erros.Count == 0;
        }
    }
}

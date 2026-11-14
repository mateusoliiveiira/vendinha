namespace Vendinha.Models
{
    /// <summary>
    /// Linha da listagem de clientes: dados do cliente + idade atualizada + total devido.
    /// </summary>
    public class ClienteResumo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }

        /// <summary>
        /// Soma das dívidas em aberto do cliente.
        /// </summary>
        public decimal TotalDividas { get; set; }

        public int Idade
        {
            get { return Cliente.CalcularIdade(DataNascimento); }
        }
    }
}

namespace Vendinha.Models
{
    public class ClienteResumo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }

        public decimal TotalDividas { get; set; }

        public int Idade
        {
            get { return Cliente.CalcularIdade(DataNascimento); }
        }
    }
}

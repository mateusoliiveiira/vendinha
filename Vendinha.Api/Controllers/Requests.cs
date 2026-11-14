namespace Vendinha.Api.Controllers
{
    public class ClienteRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
    }

    public class DividaRequest
    {
        public decimal Valor { get; set; }
    }
}

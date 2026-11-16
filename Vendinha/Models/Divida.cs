namespace Vendinha.Models
{
    public class Divida
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public decimal Valor { get; set; }

        public bool Paga { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataPagamento { get; set; }

        public string Situacao
        {
            get { return Paga ? "Paga" : "Em aberto"; }
        }
    }
}

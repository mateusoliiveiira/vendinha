namespace Vendinha.Models
{
    public class Divida
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        /// <summary>
        /// Valor da dívida (validado na DividaService: deve ser maior que zero).
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Situação: true = paga, false = em aberto.
        /// </summary>
        public bool Paga { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataPagamento { get; set; }

        public string Situacao
        {
            get { return Paga ? "Paga" : "Em aberto"; }
        }
    }
}

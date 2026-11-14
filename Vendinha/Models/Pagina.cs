namespace Vendinha.Models
{
    /// <summary>
    /// Resultado paginado genérico.
    /// </summary>
    public class Pagina<T>
    {
        public List<T> Itens { get; set; } = new List<T>();
        public int NumeroPagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalItens { get; set; }

        public int TotalPaginas
        {
            get
            {
                if (TamanhoPagina <= 0) return 0;
                return (int)Math.Ceiling(TotalItens / (double)TamanhoPagina);
            }
        }

        public bool TemProxima
        {
            get { return NumeroPagina < TotalPaginas; }
        }

        public bool TemAnterior
        {
            get { return NumeroPagina > 1; }
        }
    }
}

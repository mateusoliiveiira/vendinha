namespace Vendinha
{
    public static class Configuracao
    {
        /// <summary>
        /// String de conexão padrão do PostgreSQL.
        /// Pode ser sobrescrita pela variável de ambiente VENDINHA_DB.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return Environment.GetEnvironmentVariable("VENDINHA_DB")
                    ?? "Host=localhost;Port=5432;Database=vendinha;Username=postgres;Password=postgres";
            }
        }
    }
}

namespace Vendinha
{
    public static class Configuracao
    {
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

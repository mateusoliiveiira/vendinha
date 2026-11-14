using System.ComponentModel.DataAnnotations;

namespace Vendinha.Validations
{
    /// <summary>
    /// Valida se o valor informado é um CPF válido (dígitos verificadores).
    /// Aceita com ou sem máscara (000.000.000-00).
    /// </summary>
    public class CpfAttribute : ValidationAttribute
    {
        public CpfAttribute()
        {
            ErrorMessage = "CPF inválido.";
        }

        public override bool IsValid(object? value)
        {
            // campo obrigatório é tratado pelo [Required]
            if (value is not string texto || string.IsNullOrWhiteSpace(texto))
                return true;

            return EhValido(texto);
        }

        public static string SomenteNumeros(string? cpf)
        {
            if (cpf == null) return string.Empty;
            return new string(cpf.Where(char.IsDigit).ToArray());
        }

        public static bool EhValido(string cpf)
        {
            var numeros = SomenteNumeros(cpf);

            if (numeros.Length != 11)
                return false;

            // CPFs com todos os dígitos iguais (111.111.111-11) são inválidos
            if (numeros.Distinct().Count() == 1)
                return false;

            var digitos = numeros.Select(c => c - '0').ToArray();

            int CalcularDigito(int quantidade)
            {
                var soma = 0;
                for (int i = 0; i < quantidade; i++)
                {
                    soma += digitos[i] * (quantidade + 1 - i);
                }
                var resto = soma % 11;
                return resto < 2 ? 0 : 11 - resto;
            }

            return CalcularDigito(9) == digitos[9]
                && CalcularDigito(10) == digitos[10];
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Vendinha.Validations;

namespace Vendinha.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        private string cpf = string.Empty;

        /// <summary>
        /// CPF armazenado apenas com números.
        /// </summary>
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [Cpf]
        public string Cpf
        {
            get { return cpf; }
            set { cpf = CpfAttribute.SomenteNumeros(value); }
        }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        private string? email;

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string? Email
        {
            get { return email; }
            set
            {
                email = string.IsNullOrWhiteSpace(value)
                    ? null
                    : value.Trim().ToLower();
            }
        }

        /// <summary>
        /// Idade calculada a partir da data de nascimento (não é gravada no banco).
        /// </summary>
        public int Idade
        {
            get { return CalcularIdade(DataNascimento); }
        }

        [JsonIgnore]
        public List<Divida> Dividas { get; set; } = new List<Divida>();

        public static int CalcularIdade(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - dataNascimento.Year;
            if (dataNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }
            return idade;
        }

        public string CpfFormatado
        {
            get
            {
                return Cpf.Length == 11
                    ? Convert.ToUInt64(Cpf).ToString(@"000\.000\.000\-00")
                    : Cpf;
            }
        }
    }
}

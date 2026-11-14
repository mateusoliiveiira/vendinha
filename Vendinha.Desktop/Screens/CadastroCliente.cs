using Vendinha.Models;
using Vendinha.Services;

namespace Vendinha.Desktop.Screens
{
    /// <summary>
    /// Cadastro e edição de cliente.
    /// </summary>
    public partial class CadastroCliente : Form
    {
        private readonly ClienteService service;
        private readonly int? clienteId;

        /// <summary>Novo cliente.</summary>
        public CadastroCliente(ClienteService service) : this(service, null)
        {
        }

        /// <summary>Edição de cliente existente (clienteId informado).</summary>
        public CadastroCliente(ClienteService service, int? clienteId)
        {
            this.service = service;
            this.clienteId = clienteId;
            InitializeComponent();

            pickerDataNascimento.MaxDate = DateTime.Today;
            pickerDataNascimento.Value = DateTime.Today.AddYears(-18);

            if (clienteId.HasValue)
            {
                CarregarCliente(clienteId.Value);
            }
        }

        private void CarregarCliente(int id)
        {
            var cliente = service.Buscar(id);
            if (cliente == null)
            {
                MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            Text = "Editar cliente";
            lblTitulo.Text = "Editar cliente";
            txtNome.Text = cliente.Nome;
            txtCpf.Text = cliente.CpfFormatado;
            pickerDataNascimento.Value = cliente.DataNascimento.Date;
            txtEmail.Text = cliente.Email;
            AtualizarIdade();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente
            {
                Nome = txtNome.Text.Trim(),
                Cpf = txtCpf.Text,
                DataNascimento = pickerDataNascimento.Value.Date,
                Email = txtEmail.Text
            };

            bool sucesso;
            List<System.ComponentModel.DataAnnotations.ValidationResult> erros;

            if (clienteId.HasValue)
                sucesso = service.Atualizar(clienteId.Value, cliente, out erros);
            else
                sucesso = service.Criar(cliente, out erros);

            if (sucesso)
            {
                MessageBox.Show("Cliente salvo com sucesso!", "Vendinha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                var mensagem = string.Join(Environment.NewLine, erros.Select(x => "• " + x.ErrorMessage));
                MessageBox.Show(mensagem, "Verifique os dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pickerDataNascimento_ValueChanged(object sender, EventArgs e)
        {
            AtualizarIdade();
        }

        private void AtualizarIdade()
        {
            lblIdade.Text = "Idade: " + Cliente.CalcularIdade(pickerDataNascimento.Value) + " anos";
        }
    }
}

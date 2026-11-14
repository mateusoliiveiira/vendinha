using Vendinha.Desktop.Screens;
using Vendinha.Services;

namespace Vendinha.Desktop
{
    /// <summary>
    /// Tela principal (menu).
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly ClienteService clienteService;
        private readonly DividaService dividaService;

        public Form1()
        {
            clienteService = new ClienteService();
            dividaService = new DividaService();
            InitializeComponent();
        }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            // janela modal
            var tela = new CadastroCliente(clienteService);
            tela.ShowDialog(this);
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            var tela = new ListarClientes(clienteService, dividaService);
            tela.ShowDialog(this);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

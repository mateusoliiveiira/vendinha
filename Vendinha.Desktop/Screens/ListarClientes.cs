using Vendinha.Models;
using Vendinha.Services;

namespace Vendinha.Desktop.Screens
{
    /// <summary>
    /// Listagem de clientes: ordenada por quem mais deve, busca por nome e paginação de 10 em 10.
    /// </summary>
    public partial class ListarClientes : Form
    {
        private readonly ClienteService clienteService;
        private readonly DividaService dividaService;

        private int paginaAtual = 1;
        private string pesquisaAtual = string.Empty;

        public ListarClientes(ClienteService clienteService, DividaService dividaService)
        {
            this.clienteService = clienteService;
            this.dividaService = dividaService;
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            var pagina = clienteService.Listar(pesquisaAtual, paginaAtual);

            // se excluiu o último item da página, volta uma página
            if (pagina.Itens.Count == 0 && paginaAtual > 1)
            {
                paginaAtual--;
                pagina = clienteService.Listar(pesquisaAtual, paginaAtual);
            }

            CarregarDadosTabela(pagina.Itens);

            var totalPaginas = Math.Max(pagina.TotalPaginas, 1);
            lblPagina.Text = $"Página {pagina.NumeroPagina} de {totalPaginas} ({pagina.TotalItens} clientes)";
            btnAnterior.Enabled = pagina.TemAnterior;
            btnProxima.Enabled = pagina.TemProxima;
        }

        private void CarregarDadosTabela(List<ClienteResumo> lista)
        {
            dataGridView1.Rows.Clear();
            foreach (var cliente in lista)
            {
                dataGridView1.Rows.Add(
                    cliente.Id,
                    cliente.Nome,
                    new Cliente { Cpf = cliente.Cpf }.CpfFormatado,
                    cliente.Idade,
                    cliente.Email,
                    cliente.TotalDividas.ToString("C2")
                );
            }
        }

        private int? IdSelecionado()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente na lista.", "Vendinha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return Convert.ToInt32(dataGridView1.CurrentRow.Cells[colId.Index].Value);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisaAtual = txtPesquisa.Text;
            paginaAtual = 1;
            CarregarDados();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            paginaAtual--;
            CarregarDados();
        }

        private void btnProxima_Click(object sender, EventArgs e)
        {
            paginaAtual++;
            CarregarDados();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var tela = new CadastroCliente(clienteService);
            if (tela.ShowDialog(this) == DialogResult.OK)
            {
                CarregarDados();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var id = IdSelecionado();
            if (id == null) return;

            var tela = new CadastroCliente(clienteService, id);
            if (tela.ShowDialog(this) == DialogResult.OK)
            {
                CarregarDados();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = IdSelecionado();
            if (id == null) return;

            var confirmacao = MessageBox.Show(
                "Deseja excluir o cliente selecionado? As dívidas dele também serão excluídas.",
                "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes) return;

            if (!clienteService.Excluir(id.Value, out var erros))
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros.Select(x => x.ErrorMessage)),
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CarregarDados();
        }

        private void btnDividas_Click(object sender, EventArgs e)
        {
            var id = IdSelecionado();
            if (id == null) return;

            var tela = new DividasCliente(clienteService, dividaService, id.Value);
            tela.ShowDialog(this);
            CarregarDados(); // total devido pode ter mudado
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnDividas_Click(sender, e);
            }
        }
    }
}

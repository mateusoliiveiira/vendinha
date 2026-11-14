using Vendinha.Models;
using Vendinha.Services;

namespace Vendinha.Desktop.Screens
{
    /// <summary>
    /// Dívidas de um cliente: lançar nova dívida (pendurar) e marcar como paga.
    /// </summary>
    public partial class DividasCliente : Form
    {
        private readonly DividaService dividaService;
        private readonly int clienteId;

        public DividasCliente(ClienteService clienteService, DividaService dividaService, int clienteId)
        {
            this.dividaService = dividaService;
            this.clienteId = clienteId;
            InitializeComponent();

            var cliente = clienteService.Buscar(clienteId);
            lblCliente.Text = cliente == null
                ? "Cliente não encontrado"
                : $"{cliente.Nome}  |  CPF {cliente.CpfFormatado}  |  {cliente.Idade} anos";

            CarregarDados();
        }

        private void CarregarDados()
        {
            var dividas = dividaService.ListarPorCliente(clienteId);

            dataGridView1.Rows.Clear();
            foreach (var divida in dividas)
            {
                dataGridView1.Rows.Add(
                    divida.Id,
                    divida.Valor.ToString("C2"),
                    divida.Situacao,
                    divida.DataCriacao.ToLocalTime().ToString("dd/MM/yyyy HH:mm"),
                    divida.DataPagamento?.ToLocalTime().ToString("dd/MM/yyyy HH:mm") ?? "-"
                );
            }

            var emAberto = dividas.Where(d => !d.Paga).Sum(d => d.Valor);
            lblTotal.Text = "Total em aberto: " + emAberto.ToString("C2");
        }

        private int? IdSelecionado()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma dívida na lista.", "Vendinha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return Convert.ToInt32(dataGridView1.CurrentRow.Cells[colId.Index].Value);
        }

        private void btnPendurar_Click(object sender, EventArgs e)
        {
            if (!dividaService.Criar(clienteId, numValor.Value, out var erros))
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros.Select(x => "• " + x.ErrorMessage)),
                    "Não foi possível pendurar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            numValor.Value = 0;
            CarregarDados();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            var id = IdSelecionado();
            if (id == null) return;

            if (!dividaService.MarcarComoPaga(id.Value, out var erros))
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros.Select(x => x.ErrorMessage)),
                    "Vendinha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CarregarDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = IdSelecionado();
            if (id == null) return;

            if (MessageBox.Show("Excluir a dívida selecionada?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            if (!dividaService.Excluir(id.Value, out var erros))
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros.Select(x => x.ErrorMessage)),
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CarregarDados();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

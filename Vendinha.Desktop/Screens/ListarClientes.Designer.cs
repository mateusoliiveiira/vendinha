namespace Vendinha.Desktop.Screens
{
    partial class ListarClientes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblPesquisa = new Label();
            txtPesquisa = new TextBox();
            btnPesquisar = new Button();
            dataGridView1 = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNome = new DataGridViewTextBoxColumn();
            colCpf = new DataGridViewTextBoxColumn();
            colIdade = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            btnAnterior = new Button();
            lblPagina = new Label();
            btnProxima = new Button();
            btnNovo = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            btnDividas = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // lblPesquisa
            //
            lblPesquisa.AutoSize = true;
            lblPesquisa.Location = new Point(15, 18);
            lblPesquisa.Name = "lblPesquisa";
            lblPesquisa.Text = "Buscar por nome:";
            //
            // txtPesquisa
            //
            txtPesquisa.Location = new Point(125, 15);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(450, 23);
            txtPesquisa.TabIndex = 0;
            //
            // btnPesquisar
            //
            btnPesquisar.Location = new Point(585, 14);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(100, 25);
            btnPesquisar.TabIndex = 1;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            //
            // colId
            //
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            //
            // colNome
            //
            colNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNome.HeaderText = "Nome";
            colNome.Name = "colNome";
            colNome.ReadOnly = true;
            //
            // colCpf
            //
            colCpf.HeaderText = "CPF";
            colCpf.Name = "colCpf";
            colCpf.ReadOnly = true;
            colCpf.Width = 120;
            //
            // colIdade
            //
            colIdade.HeaderText = "Idade";
            colIdade.Name = "colIdade";
            colIdade.ReadOnly = true;
            colIdade.Width = 60;
            //
            // colEmail
            //
            colEmail.HeaderText = "E-mail";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 180;
            //
            // colTotal
            //
            colTotal.HeaderText = "Total devido";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 110;
            //
            // dataGridView1
            //
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colId, colNome, colCpf, colIdade, colEmail, colTotal });
            dataGridView1.Location = new Point(15, 50);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(670, 300);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            //
            // btnAnterior
            //
            btnAnterior.Location = new Point(15, 360);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(90, 28);
            btnAnterior.TabIndex = 3;
            btnAnterior.Text = "< Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            //
            // lblPagina
            //
            lblPagina.Location = new Point(110, 360);
            lblPagina.Name = "lblPagina";
            lblPagina.Size = new Size(480, 28);
            lblPagina.Text = "Página 1 de 1";
            lblPagina.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnProxima
            //
            btnProxima.Location = new Point(595, 360);
            btnProxima.Name = "btnProxima";
            btnProxima.Size = new Size(90, 28);
            btnProxima.TabIndex = 4;
            btnProxima.Text = "Próxima >";
            btnProxima.UseVisualStyleBackColor = true;
            btnProxima.Click += btnProxima_Click;
            //
            // btnNovo
            //
            btnNovo.Location = new Point(15, 405);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(120, 32);
            btnNovo.TabIndex = 5;
            btnNovo.Text = "Novo cliente";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            //
            // btnEditar
            //
            btnEditar.Location = new Point(145, 405);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 32);
            btnEditar.TabIndex = 6;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            //
            // btnExcluir
            //
            btnExcluir.Location = new Point(255, 405);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(100, 32);
            btnExcluir.TabIndex = 7;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            //
            // btnDividas
            //
            btnDividas.Location = new Point(535, 405);
            btnDividas.Name = "btnDividas";
            btnDividas.Size = new Size(150, 32);
            btnDividas.TabIndex = 8;
            btnDividas.Text = "Ver dívidas";
            btnDividas.UseVisualStyleBackColor = true;
            btnDividas.Click += btnDividas_Click;
            //
            // ListarClientes
            //
            AcceptButton = btnPesquisar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 452);
            Controls.Add(lblPesquisa);
            Controls.Add(txtPesquisa);
            Controls.Add(btnPesquisar);
            Controls.Add(dataGridView1);
            Controls.Add(btnAnterior);
            Controls.Add(lblPagina);
            Controls.Add(btnProxima);
            Controls.Add(btnNovo);
            Controls.Add(btnEditar);
            Controls.Add(btnExcluir);
            Controls.Add(btnDividas);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ListarClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPesquisa;
        private TextBox txtPesquisa;
        private Button btnPesquisar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNome;
        private DataGridViewTextBoxColumn colCpf;
        private DataGridViewTextBoxColumn colIdade;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colTotal;
        private Button btnAnterior;
        private Label lblPagina;
        private Button btnProxima;
        private Button btnNovo;
        private Button btnEditar;
        private Button btnExcluir;
        private Button btnDividas;
    }
}

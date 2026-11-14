namespace Vendinha.Desktop.Screens
{
    partial class DividasCliente
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
            lblCliente = new Label();
            lblValor = new Label();
            numValor = new NumericUpDown();
            btnPendurar = new Button();
            dataGridView1 = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colValor = new DataGridViewTextBoxColumn();
            colSituacao = new DataGridViewTextBoxColumn();
            colCriacao = new DataGridViewTextBoxColumn();
            colPagamento = new DataGridViewTextBoxColumn();
            lblTotal = new Label();
            btnPagar = new Button();
            btnExcluir = new Button();
            btnFechar = new Button();
            ((System.ComponentModel.ISupportInitialize)numValor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // lblCliente
            //
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCliente.Location = new Point(15, 15);
            lblCliente.Name = "lblCliente";
            lblCliente.Text = "Cliente";
            //
            // lblValor
            //
            lblValor.AutoSize = true;
            lblValor.Location = new Point(15, 55);
            lblValor.Name = "lblValor";
            lblValor.Text = "Nova dívida (R$):";
            //
            // numValor
            //
            numValor.DecimalPlaces = 2;
            numValor.Increment = 1M;
            numValor.Location = new Point(125, 52);
            numValor.Maximum = 9999999M;
            numValor.Name = "numValor";
            numValor.Size = new Size(120, 23);
            numValor.TabIndex = 0;
            numValor.ThousandsSeparator = true;
            //
            // btnPendurar
            //
            btnPendurar.Location = new Point(255, 50);
            btnPendurar.Name = "btnPendurar";
            btnPendurar.Size = new Size(110, 27);
            btnPendurar.TabIndex = 1;
            btnPendurar.Text = "Pendurar";
            btnPendurar.UseVisualStyleBackColor = true;
            btnPendurar.Click += btnPendurar_Click;
            //
            // colId
            //
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            //
            // colValor
            //
            colValor.HeaderText = "Valor";
            colValor.Name = "colValor";
            colValor.ReadOnly = true;
            colValor.Width = 110;
            //
            // colSituacao
            //
            colSituacao.HeaderText = "Situação";
            colSituacao.Name = "colSituacao";
            colSituacao.ReadOnly = true;
            //
            // colCriacao
            //
            colCriacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCriacao.HeaderText = "Data de criação";
            colCriacao.Name = "colCriacao";
            colCriacao.ReadOnly = true;
            //
            // colPagamento
            //
            colPagamento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPagamento.HeaderText = "Data de pagamento";
            colPagamento.Name = "colPagamento";
            colPagamento.ReadOnly = true;
            //
            // dataGridView1
            //
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colId, colValor, colSituacao, colCriacao, colPagamento });
            dataGridView1.Location = new Point(15, 90);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(570, 240);
            dataGridView1.TabIndex = 2;
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.Location = new Point(15, 340);
            lblTotal.Name = "lblTotal";
            lblTotal.Text = "Total em aberto:";
            //
            // btnPagar
            //
            btnPagar.Location = new Point(15, 370);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(150, 32);
            btnPagar.TabIndex = 3;
            btnPagar.Text = "Marcar como paga";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            //
            // btnExcluir
            //
            btnExcluir.Location = new Point(175, 370);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(110, 32);
            btnExcluir.TabIndex = 4;
            btnExcluir.Text = "Excluir dívida";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            //
            // btnFechar
            //
            btnFechar.Location = new Point(485, 370);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(100, 32);
            btnFechar.TabIndex = 5;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            //
            // DividasCliente
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnFechar;
            ClientSize = new Size(600, 418);
            Controls.Add(lblCliente);
            Controls.Add(lblValor);
            Controls.Add(numValor);
            Controls.Add(btnPendurar);
            Controls.Add(dataGridView1);
            Controls.Add(lblTotal);
            Controls.Add(btnPagar);
            Controls.Add(btnExcluir);
            Controls.Add(btnFechar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DividasCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dívidas do cliente";
            ((System.ComponentModel.ISupportInitialize)numValor).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCliente;
        private Label lblValor;
        private NumericUpDown numValor;
        private Button btnPendurar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colValor;
        private DataGridViewTextBoxColumn colSituacao;
        private DataGridViewTextBoxColumn colCriacao;
        private DataGridViewTextBoxColumn colPagamento;
        private Label lblTotal;
        private Button btnPagar;
        private Button btnExcluir;
        private Button btnFechar;
    }
}

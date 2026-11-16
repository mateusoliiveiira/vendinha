namespace Vendinha.Desktop
{
    partial class Form1
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
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            btnNovoCliente = new Button();
            btnListarClientes = new Button();
            btnSair = new Button();
            SuspendLayout();
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(40, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Vendinha";
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(44, 75);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Text = "Controle de contas penduradas";
            btnNovoCliente.Location = new Point(44, 120);
            btnNovoCliente.Name = "btnNovoCliente";
            btnNovoCliente.Size = new Size(260, 40);
            btnNovoCliente.Text = "Cadastrar cliente";
            btnNovoCliente.UseVisualStyleBackColor = true;
            btnNovoCliente.Click += btnNovoCliente_Click;
            btnListarClientes.Location = new Point(44, 170);
            btnListarClientes.Name = "btnListarClientes";
            btnListarClientes.Size = new Size(260, 40);
            btnListarClientes.Text = "Clientes e dívidas";
            btnListarClientes.UseVisualStyleBackColor = true;
            btnListarClientes.Click += btnListarClientes_Click;
            btnSair.Location = new Point(44, 220);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(260, 40);
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 300);
            Controls.Add(lblTitulo);
            Controls.Add(lblSubtitulo);
            Controls.Add(btnNovoCliente);
            Controls.Add(btnListarClientes);
            Controls.Add(btnSair);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vendinha";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnNovoCliente;
        private Button btnListarClientes;
        private Button btnSair;
    }
}

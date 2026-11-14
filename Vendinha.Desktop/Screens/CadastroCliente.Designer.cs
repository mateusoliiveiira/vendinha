namespace Vendinha.Desktop.Screens
{
    partial class CadastroCliente
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
            lblNome = new Label();
            txtNome = new TextBox();
            lblCpf = new Label();
            txtCpf = new MaskedTextBox();
            lblDataNascimento = new Label();
            pickerDataNascimento = new DateTimePicker();
            lblIdade = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Novo cliente";
            //
            // lblNome
            //
            lblNome.AutoSize = true;
            lblNome.Location = new Point(20, 60);
            lblNome.Name = "lblNome";
            lblNome.Text = "Nome completo *";
            //
            // txtNome
            //
            txtNome.Location = new Point(20, 80);
            txtNome.MaxLength = 150;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(380, 23);
            txtNome.TabIndex = 0;
            //
            // lblCpf
            //
            lblCpf.AutoSize = true;
            lblCpf.Location = new Point(20, 115);
            lblCpf.Name = "lblCpf";
            lblCpf.Text = "CPF *";
            //
            // txtCpf
            //
            txtCpf.Location = new Point(20, 135);
            txtCpf.Mask = "000.000.000-00";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(180, 23);
            txtCpf.TabIndex = 1;
            //
            // lblDataNascimento
            //
            lblDataNascimento.AutoSize = true;
            lblDataNascimento.Location = new Point(20, 170);
            lblDataNascimento.Name = "lblDataNascimento";
            lblDataNascimento.Text = "Data de nascimento *";
            //
            // pickerDataNascimento
            //
            pickerDataNascimento.Format = DateTimePickerFormat.Short;
            pickerDataNascimento.Location = new Point(20, 190);
            pickerDataNascimento.Name = "pickerDataNascimento";
            pickerDataNascimento.Size = new Size(180, 23);
            pickerDataNascimento.TabIndex = 2;
            pickerDataNascimento.ValueChanged += pickerDataNascimento_ValueChanged;
            //
            // lblIdade
            //
            lblIdade.AutoSize = true;
            lblIdade.ForeColor = Color.DimGray;
            lblIdade.Location = new Point(215, 194);
            lblIdade.Name = "lblIdade";
            lblIdade.Text = "Idade:";
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 225);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "E-mail";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(20, 245);
            txtEmail.MaxLength = 150;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(380, 23);
            txtEmail.TabIndex = 3;
            //
            // btnSalvar
            //
            btnSalvar.Location = new Point(200, 290);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(95, 32);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            //
            // btnCancelar
            //
            btnCancelar.Location = new Point(305, 290);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(95, 32);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // CadastroCliente
            //
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(424, 340);
            Controls.Add(lblTitulo);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblCpf);
            Controls.Add(txtCpf);
            Controls.Add(lblDataNascimento);
            Controls.Add(pickerDataNascimento);
            Controls.Add(lblIdade);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CadastroCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblCpf;
        private MaskedTextBox txtCpf;
        private Label lblDataNascimento;
        private DateTimePicker pickerDataNascimento;
        private Label lblIdade;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}

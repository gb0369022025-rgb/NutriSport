namespace View
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMarca = new Panel();
            picLogo = new PictureBox();
            lblMarca = new Label();
            lblLema = new Label();
            panelAcceso = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblClave = new Label();
            txtClave = new TextBox();
            lblMensaje = new Label();
            btnIngresar = new Button();
            btnSalir = new Button();
            panelMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panelAcceso.SuspendLayout();
            SuspendLayout();
            // 
            // panelMarca
            // 
            panelMarca.BackColor = Color.FromArgb(24, 30, 54);
            panelMarca.Controls.Add(lblLema);
            panelMarca.Controls.Add(lblMarca);
            panelMarca.Controls.Add(picLogo);
            panelMarca.Dock = DockStyle.Left;
            panelMarca.Location = new Point(0, 0);
            panelMarca.Name = "panelMarca";
            panelMarca.Size = new Size(340, 480);
            panelMarca.TabIndex = 1;
            // 
            // picLogo
            // 
            picLogo.Location = new Point(110, 105);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(120, 120);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblMarca
            // 
            lblMarca.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(0, 236);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(340, 60);
            lblMarca.TabIndex = 1;
            lblMarca.Text = "NutriSport";
            lblMarca.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLema
            // 
            lblLema.ForeColor = Color.FromArgb(120, 130, 150);
            lblLema.Location = new Point(0, 298);
            lblLema.Name = "lblLema";
            lblLema.Size = new Size(340, 24);
            lblLema.TabIndex = 2;
            lblLema.Text = "Sistema de Gestión";
            lblLema.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAcceso
            // 
            panelAcceso.BackColor = Color.White;
            panelAcceso.Controls.Add(btnSalir);
            panelAcceso.Controls.Add(btnIngresar);
            panelAcceso.Controls.Add(lblMensaje);
            panelAcceso.Controls.Add(txtClave);
            panelAcceso.Controls.Add(lblClave);
            panelAcceso.Controls.Add(txtUsuario);
            panelAcceso.Controls.Add(lblUsuario);
            panelAcceso.Controls.Add(lblSubtitulo);
            panelAcceso.Controls.Add(lblTitulo);
            panelAcceso.Dock = DockStyle.Fill;
            panelAcceso.Location = new Point(340, 0);
            panelAcceso.Name = "panelAcceso";
            panelAcceso.Size = new Size(480, 480);
            panelAcceso.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.ForeColor = Color.FromArgb(30, 30, 30);
            lblTitulo.Location = new Point(68, 60);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(169, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Iniciar sesión";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.ForeColor = Color.Gray;
            lblSubtitulo.Location = new Point(70, 100);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(228, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Ingresa tu usuario y contraseña";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = Color.FromArgb(30, 30, 30);
            lblUsuario.Location = new Point(70, 150);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(59, 20);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(70, 172);
            txtUsuario.MaxLength = 20;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(340, 27);
            txtUsuario.TabIndex = 3;
            txtUsuario.TextChanged += txtCampo_TextChanged;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.ForeColor = Color.FromArgb(30, 30, 30);
            lblClave.Location = new Point(70, 214);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(83, 20);
            lblClave.TabIndex = 4;
            lblClave.Text = "Contraseña";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(70, 236);
            txtClave.MaxLength = 25;
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(340, 27);
            txtClave.TabIndex = 5;
            txtClave.UseSystemPasswordChar = true;
            txtClave.TextChanged += txtCampo_TextChanged;
            // 
            // lblMensaje
            // 
            lblMensaje.ForeColor = Color.FromArgb(192, 57, 43);
            lblMensaje.Location = new Point(70, 272);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(340, 40);
            lblMensaje.TabIndex = 6;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(46, 51, 73);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(70, 318);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(340, 42);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Iniciar sesión";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(230, 235, 240);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(70, 370);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(340, 38);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 480);
            Controls.Add(panelAcceso);
            Controls.Add(panelMarca);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NutriSport - Iniciar sesión";
            panelMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panelAcceso.ResumeLayout(false);
            panelAcceso.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMarca;
        private PictureBox picLogo;
        private Label lblMarca;
        private Label lblLema;
        private Panel panelAcceso;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblClave;
        private TextBox txtClave;
        private Label lblMensaje;
        private Button btnIngresar;
        private Button btnSalir;
    }
}

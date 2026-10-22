namespace View
{
    partial class FrmUsuarios
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelSuperior = new Panel();
            lblTitulo = new Label();
            lblSeccion = new Label();
            panelInferior = new Panel();
            lblEstado = new Label();
            panelDatos = new Panel();
            lblNombreUsuario = new Label();
            txtNombreUsuario = new TextBox();
            lblEmpleado = new Label();
            cboEmpleado = new ComboBox();
            lblClave = new Label();
            txtClave = new TextBox();
            lblTipo = new Label();
            cboTipo = new ComboBox();
            lblEstadoRegistro = new Label();
            cboEstado = new ComboBox();
            btnAgregar = new Button();
            btnLimpiar = new Button();
            panelContenido = new Panel();
            dgvUsuarios = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colNombreEmpleado = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            panelDatos.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(lblSeccion);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1082, 60);
            panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F);
            lblTitulo.Location = new Point(20, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(96, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Usuarios";
            // 
            // lblSeccion
            // 
            lblSeccion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSeccion.ForeColor = Color.FromArgb(120, 130, 150);
            lblSeccion.Location = new Point(762, 20);
            lblSeccion.Name = "lblSeccion";
            lblSeccion.Size = new Size(300, 20);
            lblSeccion.TabIndex = 1;
            lblSeccion.Text = "ADMINISTRACIÓN";
            lblSeccion.TextAlign = ContentAlignment.MiddleRight;
            lblSeccion.UseMnemonic = false;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.FromArgb(245, 247, 251);
            panelInferior.Controls.Add(lblEstado);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 573);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(1082, 30);
            panelInferior.TabIndex = 3;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.ForeColor = Color.Gray;
            lblEstado.Location = new Point(20, 5);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(84, 20);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "Cargando...";
            // 
            // panelDatos
            // 
            panelDatos.Controls.Add(btnLimpiar);
            panelDatos.Controls.Add(btnAgregar);
            panelDatos.Controls.Add(lblEstadoRegistro);
            panelDatos.Controls.Add(cboEstado);
            panelDatos.Controls.Add(lblTipo);
            panelDatos.Controls.Add(cboTipo);
            panelDatos.Controls.Add(lblClave);
            panelDatos.Controls.Add(txtClave);
            panelDatos.Controls.Add(lblEmpleado);
            panelDatos.Controls.Add(cboEmpleado);
            panelDatos.Controls.Add(lblNombreUsuario);
            panelDatos.Controls.Add(txtNombreUsuario);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Location = new Point(0, 60);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(360, 513);
            panelDatos.TabIndex = 1;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.ForeColor = Color.FromArgb(30, 30, 30);
            lblNombreUsuario.Location = new Point(20, 20);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(133, 20);
            lblNombreUsuario.TabIndex = 0;
            lblNombreUsuario.Text = "Nombre de usuario";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(20, 42);
            txtNombreUsuario.MaxLength = 20;
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(320, 27);
            txtNombreUsuario.TabIndex = 1;
            // 
            // lblEmpleado
            // 
            lblEmpleado.AutoSize = true;
            lblEmpleado.ForeColor = Color.FromArgb(30, 30, 30);
            lblEmpleado.Location = new Point(20, 83);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(64, 20);
            lblEmpleado.TabIndex = 2;
            lblEmpleado.Text = "Empleado";
            // 
            // cboEmpleado
            // 
            cboEmpleado.DropDownStyle = ComboBoxStyle.DropDown;
            cboEmpleado.FormattingEnabled = true;
            cboEmpleado.Location = new Point(20, 105);
            cboEmpleado.MaxLength = 60;
            cboEmpleado.Name = "cboEmpleado";
            cboEmpleado.Size = new Size(320, 28);
            cboEmpleado.TabIndex = 3;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.ForeColor = Color.FromArgb(30, 30, 30);
            lblClave.Location = new Point(20, 147);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(42, 20);
            lblClave.TabIndex = 4;
            lblClave.Text = "Clave";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(20, 169);
            txtClave.MaxLength = 25;
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(320, 27);
            txtClave.TabIndex = 5;
            txtClave.UseSystemPasswordChar = true;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.ForeColor = Color.FromArgb(30, 30, 30);
            lblTipo.Location = new Point(20, 210);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(34, 20);
            lblTipo.TabIndex = 6;
            lblTipo.Text = "Tipo";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Items.AddRange(new object[] { "Administrador", "Vendedor", "Bodeguero" });
            cboTipo.Location = new Point(20, 232);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(155, 28);
            cboTipo.TabIndex = 7;
            // 
            // lblEstadoRegistro
            // 
            lblEstadoRegistro.AutoSize = true;
            lblEstadoRegistro.ForeColor = Color.FromArgb(30, 30, 30);
            lblEstadoRegistro.Location = new Point(185, 210);
            lblEstadoRegistro.Name = "lblEstadoRegistro";
            lblEstadoRegistro.Size = new Size(49, 20);
            lblEstadoRegistro.TabIndex = 8;
            lblEstadoRegistro.Text = "Estado";
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cboEstado.Location = new Point(185, 232);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(155, 28);
            cboEstado.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 51, 73);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(20, 284);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(155, 38);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(230, 235, 240);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(185, 284);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 38);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvUsuarios);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(360, 60);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(10, 20, 20, 20);
            panelContenido.Size = new Size(722, 513);
            panelContenido.TabIndex = 2;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsuarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuarios.ColumnHeadersHeight = 40;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colNombre, colNombreEmpleado, colTipo, colEstado });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.GridColor = Color.FromArgb(230, 235, 240);
            dgvUsuarios.Location = new Point(10, 20);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.RowTemplate.Height = 32;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(692, 473);
            dgvUsuarios.TabIndex = 12;
            dgvUsuarios.DataBindingComplete += dgvUsuarios_DataBindingComplete;
            // 
            // colCodigo
            // 
            colCodigo.DataPropertyName = "UsuarioId";
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCodigo.FillWeight = 50F;
            colCodigo.HeaderText = "Código";
            colCodigo.MinimumWidth = 6;
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.DataPropertyName = "Nombre";
            colNombre.FillWeight = 90F;
            colNombre.HeaderText = "Usuario";
            colNombre.MinimumWidth = 90;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colNombreEmpleado
            // 
            colNombreEmpleado.DataPropertyName = "NombreEmpleado";
            colNombreEmpleado.FillWeight = 150F;
            colNombreEmpleado.HeaderText = "Empleado";
            colNombreEmpleado.MinimumWidth = 90;
            colNombreEmpleado.Name = "colNombreEmpleado";
            colNombreEmpleado.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.DataPropertyName = "Tipo";
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colTipo.FillWeight = 90F;
            colTipo.HeaderText = "Tipo";
            colTipo.MinimumWidth = 6;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "Estado";
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colEstado.FillWeight = 70F;
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 603);
            Controls.Add(panelContenido);
            Controls.Add(panelDatos);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            MinimumSize = new Size(1000, 600);
            Name = "FrmUsuarios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NutriSport - Usuarios";
            Load += FrmUsuarios_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Label lblTitulo;
        private Label lblSeccion;
        private Panel panelInferior;
        private Label lblEstado;
        private Panel panelDatos;
        private Label lblNombreUsuario;
        private TextBox txtNombreUsuario;
        private Label lblEmpleado;
        private ComboBox cboEmpleado;
        private Label lblClave;
        private TextBox txtClave;
        private Label lblTipo;
        private ComboBox cboTipo;
        private Label lblEstadoRegistro;
        private ComboBox cboEstado;
        private Button btnAgregar;
        private Button btnLimpiar;
        private Panel panelContenido;
        private DataGridView dgvUsuarios;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colNombreEmpleado;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colEstado;
    }
}

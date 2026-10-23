namespace View
{
    partial class FrmEmpleados
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblDUI = new Label();
            txtDUI = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            lblRolId = new Label();
            nudRolId = new NumericUpDown();
            lblCargoId = new Label();
            nudCargoId = new NumericUpDown();
            btnAgregar = new Button();
            btnLimpiar = new Button();
            panelContenido = new Panel();
            dgvEmpleados = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDUI = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            colRolId = new DataGridViewTextBoxColumn();
            colCargoId = new DataGridViewTextBoxColumn();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            panelDatos.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRolId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCargoId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
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
            lblTitulo.Size = new Size(107, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Empleados";
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
            panelDatos.Controls.Add(lblCargoId);
            panelDatos.Controls.Add(nudCargoId);
            panelDatos.Controls.Add(lblRolId);
            panelDatos.Controls.Add(nudRolId);
            panelDatos.Controls.Add(lblDireccion);
            panelDatos.Controls.Add(txtDireccion);
            panelDatos.Controls.Add(lblEmail);
            panelDatos.Controls.Add(txtEmail);
            panelDatos.Controls.Add(lblDUI);
            panelDatos.Controls.Add(txtDUI);
            panelDatos.Controls.Add(lblTelefono);
            panelDatos.Controls.Add(txtTelefono);
            panelDatos.Controls.Add(lblApellido);
            panelDatos.Controls.Add(txtApellido);
            panelDatos.Controls.Add(lblNombre);
            panelDatos.Controls.Add(txtNombre);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Location = new Point(0, 60);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(360, 513);
            panelDatos.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.ForeColor = Color.FromArgb(30, 30, 30);
            lblNombre.Location = new Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(49, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(20, 42);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(320, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.ForeColor = Color.FromArgb(30, 30, 30);
            lblApellido.Location = new Point(20, 83);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(64, 20);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(20, 105);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(320, 27);
            txtApellido.TabIndex = 3;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.ForeColor = Color.FromArgb(30, 30, 30);
            lblTelefono.Location = new Point(20, 146);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(64, 20);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(20, 168);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(155, 27);
            txtTelefono.TabIndex = 5;
            // 
            // lblDUI
            // 
            lblDUI.AutoSize = true;
            lblDUI.ForeColor = Color.FromArgb(30, 30, 30);
            lblDUI.Location = new Point(185, 146);
            lblDUI.Name = "lblDUI";
            lblDUI.Size = new Size(26, 20);
            lblDUI.TabIndex = 6;
            lblDUI.Text = "DUI";
            // 
            // txtDUI
            // 
            txtDUI.Location = new Point(185, 168);
            txtDUI.MaxLength = 15;
            txtDUI.Name = "txtDUI";
            txtDUI.Size = new Size(155, 27);
            txtDUI.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = Color.FromArgb(30, 30, 30);
            lblEmail.Location = new Point(20, 209);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(140, 20);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Correo electrónico";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 231);
            txtEmail.MaxLength = 50;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 27);
            txtEmail.TabIndex = 9;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.ForeColor = Color.FromArgb(30, 30, 30);
            lblDireccion.Location = new Point(20, 272);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(72, 20);
            lblDireccion.TabIndex = 10;
            lblDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(20, 294);
            txtDireccion.MaxLength = 50;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(320, 27);
            txtDireccion.TabIndex = 11;
            // 
            // lblRolId
            // 
            lblRolId.AutoSize = true;
            lblRolId.ForeColor = Color.FromArgb(30, 30, 30);
            lblRolId.Location = new Point(20, 335);
            lblRolId.Name = "lblRolId";
            lblRolId.Size = new Size(95, 20);
            lblRolId.TabIndex = 12;
            lblRolId.Text = "Rol (código)";
            // 
            // nudRolId
            // 
            nudRolId.Location = new Point(20, 357);
            nudRolId.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            nudRolId.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRolId.Name = "nudRolId";
            nudRolId.Size = new Size(155, 27);
            nudRolId.TabIndex = 13;
            nudRolId.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCargoId
            // 
            lblCargoId.AutoSize = true;
            lblCargoId.ForeColor = Color.FromArgb(30, 30, 30);
            lblCargoId.Location = new Point(185, 335);
            lblCargoId.Name = "lblCargoId";
            lblCargoId.Size = new Size(110, 20);
            lblCargoId.TabIndex = 14;
            lblCargoId.Text = "Cargo (código)";
            // 
            // nudCargoId
            // 
            nudCargoId.Location = new Point(185, 357);
            nudCargoId.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            nudCargoId.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCargoId.Name = "nudCargoId";
            nudCargoId.Size = new Size(155, 27);
            nudCargoId.TabIndex = 15;
            nudCargoId.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 51, 73);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(20, 408);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(155, 38);
            btnAgregar.TabIndex = 16;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(230, 235, 240);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(185, 408);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 38);
            btnLimpiar.TabIndex = 17;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvEmpleados);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(360, 60);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(10, 20, 20, 20);
            panelContenido.Size = new Size(722, 513);
            panelContenido.TabIndex = 2;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.AllowUserToResizeRows = false;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.BackgroundColor = Color.White;
            dgvEmpleados.BorderStyle = BorderStyle.None;
            dgvEmpleados.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmpleados.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmpleados.ColumnHeadersHeight = 40;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEmpleados.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colNombre, colApellido, colTelefono, colEmail, colDUI, colDireccion, colRolId, colCargoId });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEmpleados.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEmpleados.Dock = DockStyle.Fill;
            dgvEmpleados.EnableHeadersVisualStyles = false;
            dgvEmpleados.GridColor = Color.FromArgb(230, 235, 240);
            dgvEmpleados.Location = new Point(10, 20);
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.RowHeadersWidth = 51;
            dgvEmpleados.RowTemplate.Height = 32;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.Size = new Size(692, 473);
            dgvEmpleados.TabIndex = 18;
            dgvEmpleados.DataBindingComplete += dgvEmpleados_DataBindingComplete;
            // 
            // colCodigo
            // 
            colCodigo.DataPropertyName = "EmpleadoId";
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colCodigo.FillWeight = 45F;
            colCodigo.HeaderText = "Código";
            colCodigo.MinimumWidth = 6;
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.DataPropertyName = "Nombre";
            colNombre.FillWeight = 80F;
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 90;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colApellido
            // 
            colApellido.DataPropertyName = "Apellido";
            colApellido.FillWeight = 80F;
            colApellido.HeaderText = "Apellido";
            colApellido.MinimumWidth = 90;
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            // 
            // colTelefono
            // 
            colTelefono.DataPropertyName = "Telefono";
            colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTelefono.FillWeight = 70F;
            colTelefono.HeaderText = "Teléfono";
            colTelefono.MinimumWidth = 6;
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 120F;
            colEmail.HeaderText = "Correo";
            colEmail.MinimumWidth = 90;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colDUI
            // 
            colDUI.DataPropertyName = "DUI";
            colDUI.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDUI.FillWeight = 75F;
            colDUI.HeaderText = "DUI";
            colDUI.MinimumWidth = 6;
            colDUI.Name = "colDUI";
            colDUI.ReadOnly = true;
            // 
            // colDireccion
            // 
            colDireccion.DataPropertyName = "Direccion";
            colDireccion.FillWeight = 120F;
            colDireccion.HeaderText = "Dirección";
            colDireccion.MinimumWidth = 90;
            colDireccion.Name = "colDireccion";
            colDireccion.ReadOnly = true;
            // 
            // colRolId
            // 
            colRolId.DataPropertyName = "RolId";
            colRolId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colRolId.FillWeight = 35F;
            colRolId.HeaderText = "Rol";
            colRolId.MinimumWidth = 6;
            colRolId.Name = "colRolId";
            colRolId.ReadOnly = true;
            // 
            // colCargoId
            // 
            colCargoId.DataPropertyName = "CargoId";
            colCargoId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colCargoId.FillWeight = 40F;
            colCargoId.HeaderText = "Cargo";
            colCargoId.MinimumWidth = 6;
            colCargoId.Name = "colCargoId";
            colCargoId.ReadOnly = true;
            // 
            // FrmEmpleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 603);
            Controls.Add(panelContenido);
            Controls.Add(panelDatos);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            MinimumSize = new Size(1000, 600);
            Name = "FrmEmpleados";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NutriSport - Empleados";
            Load += FrmEmpleados_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudRolId).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCargoId).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Label lblTitulo;
        private Label lblSeccion;
        private Panel panelInferior;
        private Label lblEstado;
        private Panel panelDatos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblDUI;
        private TextBox txtDUI;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private Label lblRolId;
        private NumericUpDown nudRolId;
        private Label lblCargoId;
        private NumericUpDown nudCargoId;
        private Button btnAgregar;
        private Button btnLimpiar;
        private Panel panelContenido;
        private DataGridView dgvEmpleados;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDUI;
        private DataGridViewTextBoxColumn colDireccion;
        private DataGridViewTextBoxColumn colRolId;
        private DataGridViewTextBoxColumn colCargoId;
    }
}

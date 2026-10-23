namespace View
{
    partial class FrmControlInventario
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelSuperior = new Panel();
            lblTitulo = new Label();
            lblSeccion = new Label();
            panelInferior = new Panel();
            lblEstado = new Label();
            panelDatos = new Panel();
            lblUsuario = new Label();
            cboUsuario = new ComboBox();
            lblFechaHora = new Label();
            dtpFechaHora = new DateTimePicker();
            lblCantProducto = new Label();
            nudCantProducto = new NumericUpDown();
            lblEstadoRegistro = new Label();
            cboEstado = new ComboBox();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
            btnAgregar = new Button();
            btnLimpiar = new Button();
            panelContenido = new Panel();
            dgvControlInventario = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colFechaHora = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colCantProducto = new DataGridViewTextBoxColumn();
            colObservacion = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            panelDatos.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantProducto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvControlInventario).BeginInit();
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
            lblTitulo.Size = new Size(245, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Control de inventario";
            // 
            // lblSeccion
            // 
            lblSeccion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSeccion.ForeColor = Color.FromArgb(120, 130, 150);
            lblSeccion.Location = new Point(762, 20);
            lblSeccion.Name = "lblSeccion";
            lblSeccion.Size = new Size(300, 20);
            lblSeccion.TabIndex = 1;
            lblSeccion.Text = "INVENTARIO & PRODUCTOS";
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
            panelDatos.Controls.Add(lblObservacion);
            panelDatos.Controls.Add(txtObservacion);
            panelDatos.Controls.Add(lblEstadoRegistro);
            panelDatos.Controls.Add(cboEstado);
            panelDatos.Controls.Add(lblCantProducto);
            panelDatos.Controls.Add(nudCantProducto);
            panelDatos.Controls.Add(lblFechaHora);
            panelDatos.Controls.Add(dtpFechaHora);
            panelDatos.Controls.Add(lblUsuario);
            panelDatos.Controls.Add(cboUsuario);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Location = new Point(0, 60);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(360, 513);
            panelDatos.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = Color.FromArgb(30, 30, 30);
            lblUsuario.Location = new Point(20, 20);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(148, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario responsable";
            // 
            // cboUsuario
            // 
            cboUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUsuario.FormattingEnabled = true;
            cboUsuario.Location = new Point(20, 42);
            cboUsuario.Name = "cboUsuario";
            cboUsuario.Size = new Size(320, 28);
            cboUsuario.TabIndex = 1;
            // 
            // lblFechaHora
            // 
            lblFechaHora.AutoSize = true;
            lblFechaHora.ForeColor = Color.FromArgb(30, 30, 30);
            lblFechaHora.Location = new Point(20, 84);
            lblFechaHora.Name = "lblFechaHora";
            lblFechaHora.Size = new Size(95, 20);
            lblFechaHora.TabIndex = 2;
            lblFechaHora.Text = "Fecha y hora";
            // 
            // dtpFechaHora
            // 
            dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.Location = new Point(20, 106);
            dtpFechaHora.Name = "dtpFechaHora";
            dtpFechaHora.Size = new Size(320, 27);
            dtpFechaHora.TabIndex = 3;
            // 
            // lblCantProducto
            // 
            lblCantProducto.AutoSize = true;
            lblCantProducto.ForeColor = Color.FromArgb(30, 30, 30);
            lblCantProducto.Location = new Point(20, 147);
            lblCantProducto.Name = "lblCantProducto";
            lblCantProducto.Size = new Size(163, 20);
            lblCantProducto.TabIndex = 4;
            lblCantProducto.Text = "Cantidad de productos";
            // 
            // nudCantProducto
            // 
            nudCantProducto.Location = new Point(20, 169);
            nudCantProducto.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudCantProducto.Name = "nudCantProducto";
            nudCantProducto.Size = new Size(155, 27);
            nudCantProducto.TabIndex = 5;
            nudCantProducto.ThousandsSeparator = true;
            // 
            // lblEstadoRegistro
            // 
            lblEstadoRegistro.AutoSize = true;
            lblEstadoRegistro.ForeColor = Color.FromArgb(30, 30, 30);
            lblEstadoRegistro.Location = new Point(185, 147);
            lblEstadoRegistro.Name = "lblEstadoRegistro";
            lblEstadoRegistro.Size = new Size(49, 20);
            lblEstadoRegistro.TabIndex = 6;
            lblEstadoRegistro.Text = "Estado";
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Procesado", "Pendiente" });
            cboEstado.Location = new Point(185, 169);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(155, 28);
            cboEstado.TabIndex = 7;
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.ForeColor = Color.FromArgb(30, 30, 30);
            lblObservacion.Location = new Point(20, 211);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(87, 20);
            lblObservacion.TabIndex = 8;
            lblObservacion.Text = "Observación";
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(20, 233);
            txtObservacion.MaxLength = 200;
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.ScrollBars = ScrollBars.Vertical;
            txtObservacion.Size = new Size(320, 100);
            txtObservacion.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 51, 73);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(20, 357);
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
            btnLimpiar.Location = new Point(185, 357);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 38);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvControlInventario);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(360, 60);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(10, 20, 20, 20);
            panelContenido.Size = new Size(722, 513);
            panelContenido.TabIndex = 2;
            // 
            // dgvControlInventario
            // 
            dgvControlInventario.AllowUserToAddRows = false;
            dgvControlInventario.AllowUserToDeleteRows = false;
            dgvControlInventario.AllowUserToResizeRows = false;
            dgvControlInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvControlInventario.BackgroundColor = Color.White;
            dgvControlInventario.BorderStyle = BorderStyle.None;
            dgvControlInventario.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvControlInventario.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvControlInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvControlInventario.ColumnHeadersHeight = 40;
            dgvControlInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvControlInventario.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colFechaHora, colUsuario, colCantProducto, colObservacion, colEstado });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvControlInventario.DefaultCellStyle = dataGridViewCellStyle2;
            dgvControlInventario.Dock = DockStyle.Fill;
            dgvControlInventario.EnableHeadersVisualStyles = false;
            dgvControlInventario.GridColor = Color.FromArgb(230, 235, 240);
            dgvControlInventario.Location = new Point(10, 20);
            dgvControlInventario.MultiSelect = false;
            dgvControlInventario.Name = "dgvControlInventario";
            dgvControlInventario.ReadOnly = true;
            dgvControlInventario.RowHeadersVisible = false;
            dgvControlInventario.RowHeadersWidth = 51;
            dgvControlInventario.RowTemplate.Height = 32;
            dgvControlInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvControlInventario.Size = new Size(692, 473);
            dgvControlInventario.TabIndex = 12;
            dgvControlInventario.DataBindingComplete += dgvControlInventario_DataBindingComplete;
            // 
            // colCodigo
            // 
            colCodigo.DataPropertyName = "ControlInvId";
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colCodigo.FillWeight = 50F;
            colCodigo.HeaderText = "Código";
            colCodigo.MinimumWidth = 6;
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            // 
            // colFechaHora
            // 
            colFechaHora.DataPropertyName = "FechaHora";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm";
            dataGridViewCellStyle3.NullValue = null;
            colFechaHora.DefaultCellStyle = dataGridViewCellStyle3;
            colFechaHora.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colFechaHora.FillWeight = 95F;
            colFechaHora.HeaderText = "Fecha y hora";
            colFechaHora.MinimumWidth = 6;
            colFechaHora.Name = "colFechaHora";
            colFechaHora.ReadOnly = true;
            // 
            // colUsuario
            // 
            colUsuario.DataPropertyName = "Usuario";
            colUsuario.FillWeight = 80F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.MinimumWidth = 90;
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            // 
            // colCantProducto
            // 
            colCantProducto.DataPropertyName = "CantProducto";
            colCantProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colCantProducto.FillWeight = 65F;
            colCantProducto.HeaderText = "Cantidad";
            colCantProducto.MinimumWidth = 6;
            colCantProducto.Name = "colCantProducto";
            colCantProducto.ReadOnly = true;
            // 
            // colObservacion
            // 
            colObservacion.DataPropertyName = "Observacion";
            colObservacion.FillWeight = 160F;
            colObservacion.HeaderText = "Observación";
            colObservacion.MinimumWidth = 90;
            colObservacion.Name = "colObservacion";
            colObservacion.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "Estado";
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colEstado.FillWeight = 70F;
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // FrmControlInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 603);
            Controls.Add(panelContenido);
            Controls.Add(panelDatos);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            MinimumSize = new Size(1000, 600);
            Name = "FrmControlInventario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NutriSport - Control de inventario";
            Load += FrmControlInventario_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudCantProducto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvControlInventario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Label lblTitulo;
        private Label lblSeccion;
        private Panel panelInferior;
        private Label lblEstado;
        private Panel panelDatos;
        private Label lblUsuario;
        private ComboBox cboUsuario;
        private Label lblFechaHora;
        private DateTimePicker dtpFechaHora;
        private Label lblCantProducto;
        private NumericUpDown nudCantProducto;
        private Label lblEstadoRegistro;
        private ComboBox cboEstado;
        private Label lblObservacion;
        private TextBox txtObservacion;
        private Button btnAgregar;
        private Button btnLimpiar;
        private Panel panelContenido;
        private DataGridView dgvControlInventario;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colFechaHora;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colCantProducto;
        private DataGridViewTextBoxColumn colObservacion;
        private DataGridViewTextBoxColumn colEstado;
    }
}

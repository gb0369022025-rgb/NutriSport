namespace View
{
    partial class FrmCompras
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            panelSuperior = new Panel();
            lblTitulo = new Label();
            lblSeccion = new Label();
            panelInferior = new Panel();
            lblEstado = new Label();
            panelDatos = new Panel();
            lblFechaHora = new Label();
            dtpFechaHora = new DateTimePicker();
            lblProveedor = new Label();
            cboProveedor = new ComboBox();
            lblNumFact = new Label();
            nudNumFact = new NumericUpDown();
            lblEstadoRegistro = new Label();
            cboEstado = new ComboBox();
            lblUsuario = new Label();
            cboUsuario = new ComboBox();
            lblSubTotal = new Label();
            nudSubTotal = new NumericUpDown();
            lblTotalPagar = new Label();
            nudTotalPagar = new NumericUpDown();
            btnAgregar = new Button();
            btnLimpiar = new Button();
            panelContenido = new Panel();
            dgvCompras = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colFechaHora = new DataGridViewTextBoxColumn();
            colProveedor = new DataGridViewTextBoxColumn();
            colNumFact = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colSubTotal = new DataGridViewTextBoxColumn();
            colTotalPagar = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            panelDatos.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNumFact).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSubTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTotalPagar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
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
            lblTitulo.Size = new Size(84, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Compras";
            // 
            // lblSeccion
            // 
            lblSeccion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSeccion.ForeColor = Color.FromArgb(120, 130, 150);
            lblSeccion.Location = new Point(762, 20);
            lblSeccion.Name = "lblSeccion";
            lblSeccion.Size = new Size(300, 20);
            lblSeccion.TabIndex = 1;
            lblSeccion.Text = "OPERACIONES & PROVEEDORES";
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
            panelDatos.Controls.Add(lblTotalPagar);
            panelDatos.Controls.Add(nudTotalPagar);
            panelDatos.Controls.Add(lblSubTotal);
            panelDatos.Controls.Add(nudSubTotal);
            panelDatos.Controls.Add(lblUsuario);
            panelDatos.Controls.Add(cboUsuario);
            panelDatos.Controls.Add(lblEstadoRegistro);
            panelDatos.Controls.Add(cboEstado);
            panelDatos.Controls.Add(lblNumFact);
            panelDatos.Controls.Add(nudNumFact);
            panelDatos.Controls.Add(lblProveedor);
            panelDatos.Controls.Add(cboProveedor);
            panelDatos.Controls.Add(lblFechaHora);
            panelDatos.Controls.Add(dtpFechaHora);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Location = new Point(0, 60);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(360, 513);
            panelDatos.TabIndex = 1;
            // 
            // lblFechaHora
            // 
            lblFechaHora.AutoSize = true;
            lblFechaHora.ForeColor = Color.FromArgb(30, 30, 30);
            lblFechaHora.Location = new Point(20, 20);
            lblFechaHora.Name = "lblFechaHora";
            lblFechaHora.Size = new Size(95, 20);
            lblFechaHora.TabIndex = 0;
            lblFechaHora.Text = "Fecha y hora";
            // 
            // dtpFechaHora
            // 
            dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.Location = new Point(20, 42);
            dtpFechaHora.Name = "dtpFechaHora";
            dtpFechaHora.Size = new Size(320, 27);
            dtpFechaHora.TabIndex = 1;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.ForeColor = Color.FromArgb(30, 30, 30);
            lblProveedor.Location = new Point(20, 83);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(72, 20);
            lblProveedor.TabIndex = 2;
            lblProveedor.Text = "Proveedor";
            // 
            // cboProveedor
            // 
            cboProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new Point(20, 105);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new Size(320, 28);
            cboProveedor.TabIndex = 3;
            // 
            // lblNumFact
            // 
            lblNumFact.AutoSize = true;
            lblNumFact.ForeColor = Color.FromArgb(30, 30, 30);
            lblNumFact.Location = new Point(20, 147);
            lblNumFact.Name = "lblNumFact";
            lblNumFact.Size = new Size(102, 20);
            lblNumFact.TabIndex = 4;
            lblNumFact.Text = "N° de factura";
            // 
            // nudNumFact
            // 
            nudNumFact.Location = new Point(20, 169);
            nudNumFact.Maximum = new decimal(new int[] { 2147483647, 0, 0, 0 });
            nudNumFact.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumFact.Name = "nudNumFact";
            nudNumFact.Size = new Size(155, 27);
            nudNumFact.TabIndex = 5;
            nudNumFact.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
            cboEstado.Items.AddRange(new object[] { "Completada", "Pendiente", "Anulada" });
            cboEstado.Location = new Point(185, 169);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(155, 28);
            cboEstado.TabIndex = 7;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = Color.FromArgb(30, 30, 30);
            lblUsuario.Location = new Point(20, 211);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(156, 20);
            lblUsuario.TabIndex = 8;
            lblUsuario.Text = "Usuario que registra";
            // 
            // cboUsuario
            // 
            cboUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUsuario.FormattingEnabled = true;
            cboUsuario.Location = new Point(20, 233);
            cboUsuario.Name = "cboUsuario";
            cboUsuario.Size = new Size(320, 28);
            cboUsuario.TabIndex = 9;
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.ForeColor = Color.FromArgb(30, 30, 30);
            lblSubTotal.Location = new Point(20, 275);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(95, 20);
            lblSubTotal.TabIndex = 10;
            lblSubTotal.Text = "Subtotal ($)";
            // 
            // nudSubTotal
            // 
            nudSubTotal.DecimalPlaces = 2;
            nudSubTotal.Location = new Point(20, 297);
            nudSubTotal.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudSubTotal.Name = "nudSubTotal";
            nudSubTotal.Size = new Size(155, 27);
            nudSubTotal.TabIndex = 11;
            nudSubTotal.ThousandsSeparator = true;
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.ForeColor = Color.FromArgb(30, 30, 30);
            lblTotalPagar.Location = new Point(185, 275);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(133, 20);
            lblTotalPagar.TabIndex = 12;
            lblTotalPagar.Text = "Total a pagar ($)";
            // 
            // nudTotalPagar
            // 
            nudTotalPagar.DecimalPlaces = 2;
            nudTotalPagar.Location = new Point(185, 297);
            nudTotalPagar.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudTotalPagar.Name = "nudTotalPagar";
            nudTotalPagar.Size = new Size(155, 27);
            nudTotalPagar.TabIndex = 13;
            nudTotalPagar.ThousandsSeparator = true;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 51, 73);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(20, 348);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(155, 38);
            btnAgregar.TabIndex = 14;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(230, 235, 240);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(185, 348);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 38);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvCompras);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(360, 60);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(10, 20, 20, 20);
            panelContenido.Size = new Size(722, 513);
            panelContenido.TabIndex = 2;
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.AllowUserToResizeRows = false;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.BackgroundColor = Color.White;
            dgvCompras.BorderStyle = BorderStyle.None;
            dgvCompras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCompras.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCompras.ColumnHeadersHeight = 40;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCompras.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colFechaHora, colProveedor, colNumFact, colUsuario, colSubTotal, colTotalPagar, colEstado });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCompras.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCompras.Dock = DockStyle.Fill;
            dgvCompras.EnableHeadersVisualStyles = false;
            dgvCompras.GridColor = Color.FromArgb(230, 235, 240);
            dgvCompras.Location = new Point(10, 20);
            dgvCompras.MultiSelect = false;
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.RowHeadersVisible = false;
            dgvCompras.RowHeadersWidth = 51;
            dgvCompras.RowTemplate.Height = 32;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(692, 473);
            dgvCompras.TabIndex = 16;
            dgvCompras.DataBindingComplete += dgvCompras_DataBindingComplete;
            // 
            // colCodigo
            // 
            colCodigo.DataPropertyName = "CompraId";
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
            // colProveedor
            // 
            colProveedor.DataPropertyName = "Proveedor";
            colProveedor.FillWeight = 130F;
            colProveedor.HeaderText = "Proveedor";
            colProveedor.MinimumWidth = 90;
            colProveedor.Name = "colProveedor";
            colProveedor.ReadOnly = true;
            // 
            // colNumFact
            // 
            colNumFact.DataPropertyName = "NumFact";
            colNumFact.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colNumFact.FillWeight = 65F;
            colNumFact.HeaderText = "N° factura";
            colNumFact.MinimumWidth = 6;
            colNumFact.Name = "colNumFact";
            colNumFact.ReadOnly = true;
            // 
            // colUsuario
            // 
            colUsuario.DataPropertyName = "Usuario";
            colUsuario.FillWeight = 75F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.MinimumWidth = 90;
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            // 
            // colSubTotal
            // 
            colSubTotal.DataPropertyName = "SubTotal";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "$#,##0.00";
            dataGridViewCellStyle4.NullValue = null;
            colSubTotal.DefaultCellStyle = dataGridViewCellStyle4;
            colSubTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colSubTotal.FillWeight = 70F;
            colSubTotal.HeaderText = "Subtotal";
            colSubTotal.MinimumWidth = 6;
            colSubTotal.Name = "colSubTotal";
            colSubTotal.ReadOnly = true;
            // 
            // colTotalPagar
            // 
            colTotalPagar.DataPropertyName = "TotalPagar";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "$#,##0.00";
            dataGridViewCellStyle5.NullValue = null;
            colTotalPagar.DefaultCellStyle = dataGridViewCellStyle5;
            colTotalPagar.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTotalPagar.FillWeight = 70F;
            colTotalPagar.HeaderText = "Total";
            colTotalPagar.MinimumWidth = 6;
            colTotalPagar.Name = "colTotalPagar";
            colTotalPagar.ReadOnly = true;
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
            // FrmCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 603);
            Controls.Add(panelContenido);
            Controls.Add(panelDatos);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            MinimumSize = new Size(1000, 600);
            Name = "FrmCompras";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NutriSport - Compras";
            Load += FrmCompras_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudNumFact).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSubTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTotalPagar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Label lblTitulo;
        private Label lblSeccion;
        private Panel panelInferior;
        private Label lblEstado;
        private Panel panelDatos;
        private Label lblFechaHora;
        private DateTimePicker dtpFechaHora;
        private Label lblProveedor;
        private ComboBox cboProveedor;
        private Label lblNumFact;
        private NumericUpDown nudNumFact;
        private Label lblEstadoRegistro;
        private ComboBox cboEstado;
        private Label lblUsuario;
        private ComboBox cboUsuario;
        private Label lblSubTotal;
        private NumericUpDown nudSubTotal;
        private Label lblTotalPagar;
        private NumericUpDown nudTotalPagar;
        private Button btnAgregar;
        private Button btnLimpiar;
        private Panel panelContenido;
        private DataGridView dgvCompras;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colFechaHora;
        private DataGridViewTextBoxColumn colProveedor;
        private DataGridViewTextBoxColumn colNumFact;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colSubTotal;
        private DataGridViewTextBoxColumn colTotalPagar;
        private DataGridViewTextBoxColumn colEstado;
    }
}

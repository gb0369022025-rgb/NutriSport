namespace View
{
    partial class FrmPedidos
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
            lblNumeroPedido = new Label();
            nudNumeroPedido = new NumericUpDown();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblEstadoRegistro = new Label();
            cboEstado = new ComboBox();
            btnAgregar = new Button();
            btnLimpiar = new Button();
            panelContenido = new Panel();
            dgvPedidos = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colNumeroPedido = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            panelDatos.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNumeroPedido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
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
            lblTitulo.Text = "Pedidos";
            // 
            // lblSeccion
            // 
            lblSeccion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSeccion.ForeColor = Color.FromArgb(120, 130, 150);
            lblSeccion.Location = new Point(762, 20);
            lblSeccion.Name = "lblSeccion";
            lblSeccion.Size = new Size(300, 20);
            lblSeccion.TabIndex = 1;
            lblSeccion.Text = "GESTIÓN COMERCIAL";
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
            panelDatos.Controls.Add(lblFecha);
            panelDatos.Controls.Add(dtpFecha);
            panelDatos.Controls.Add(lblNumeroPedido);
            panelDatos.Controls.Add(nudNumeroPedido);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Location = new Point(0, 60);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(360, 513);
            panelDatos.TabIndex = 1;
            // 
            // lblNumeroPedido
            // 
            lblNumeroPedido.AutoSize = true;
            lblNumeroPedido.ForeColor = Color.FromArgb(30, 30, 30);
            lblNumeroPedido.Location = new Point(20, 20);
            lblNumeroPedido.Name = "lblNumeroPedido";
            lblNumeroPedido.Size = new Size(125, 20);
            lblNumeroPedido.TabIndex = 0;
            lblNumeroPedido.Text = "Número de pedido";
            // 
            // nudNumeroPedido
            // 
            nudNumeroPedido.Location = new Point(20, 42);
            nudNumeroPedido.Maximum = new decimal(new int[] { 2147483647, 0, 0, 0 });
            nudNumeroPedido.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumeroPedido.Name = "nudNumeroPedido";
            nudNumeroPedido.Size = new Size(320, 27);
            nudNumeroPedido.TabIndex = 1;
            nudNumeroPedido.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.ForeColor = Color.FromArgb(30, 30, 30);
            lblFecha.Location = new Point(20, 83);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(95, 20);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha y hora";
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(20, 105);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(320, 27);
            dtpFecha.TabIndex = 3;
            // 
            // lblEstadoRegistro
            // 
            lblEstadoRegistro.AutoSize = true;
            lblEstadoRegistro.ForeColor = Color.FromArgb(30, 30, 30);
            lblEstadoRegistro.Location = new Point(20, 146);
            lblEstadoRegistro.Name = "lblEstadoRegistro";
            lblEstadoRegistro.Size = new Size(49, 20);
            lblEstadoRegistro.TabIndex = 4;
            lblEstadoRegistro.Text = "Estado";
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Pendiente", "Entregado", "Cancelado" });
            cboEstado.Location = new Point(20, 168);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(320, 28);
            cboEstado.TabIndex = 5;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 51, 73);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(20, 220);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(155, 38);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(230, 235, 240);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(185, 220);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 38);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvPedidos);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(360, 60);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(10, 20, 20, 20);
            panelContenido.Size = new Size(722, 513);
            panelContenido.TabIndex = 2;
            // 
            // dgvPedidos
            // 
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = false;
            dgvPedidos.AllowUserToResizeRows = false;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.BackgroundColor = Color.White;
            dgvPedidos.BorderStyle = BorderStyle.None;
            dgvPedidos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPedidos.ColumnHeadersHeight = 40;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPedidos.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colNumeroPedido, colFecha, colEstado });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPedidos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPedidos.Dock = DockStyle.Fill;
            dgvPedidos.EnableHeadersVisualStyles = false;
            dgvPedidos.GridColor = Color.FromArgb(230, 235, 240);
            dgvPedidos.Location = new Point(10, 20);
            dgvPedidos.MultiSelect = false;
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.RowHeadersVisible = false;
            dgvPedidos.RowHeadersWidth = 51;
            dgvPedidos.RowTemplate.Height = 32;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.Size = new Size(692, 473);
            dgvPedidos.TabIndex = 8;
            dgvPedidos.DataBindingComplete += dgvPedidos_DataBindingComplete;
            // 
            // colCodigo
            // 
            colCodigo.DataPropertyName = "PedidoId";
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCodigo.FillWeight = 50F;
            colCodigo.HeaderText = "Código";
            colCodigo.MinimumWidth = 6;
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            // 
            // colNumeroPedido
            // 
            colNumeroPedido.DataPropertyName = "NumeroPedido";
            colNumeroPedido.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colNumeroPedido.FillWeight = 70F;
            colNumeroPedido.HeaderText = "N° pedido";
            colNumeroPedido.MinimumWidth = 6;
            colNumeroPedido.Name = "colNumeroPedido";
            colNumeroPedido.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm";
            dataGridViewCellStyle3.NullValue = null;
            colFecha.DefaultCellStyle = dataGridViewCellStyle3;
            colFecha.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colFecha.FillWeight = 100F;
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "Estado";
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colEstado.FillWeight = 80F;
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // FrmPedidos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 603);
            Controls.Add(panelContenido);
            Controls.Add(panelDatos);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            MinimumSize = new Size(1000, 600);
            Name = "FrmPedidos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NutriSport - Pedidos";
            Load += FrmPedidos_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudNumeroPedido).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Label lblTitulo;
        private Label lblSeccion;
        private Panel panelInferior;
        private Label lblEstado;
        private Panel panelDatos;
        private Label lblNumeroPedido;
        private NumericUpDown nudNumeroPedido;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblEstadoRegistro;
        private ComboBox cboEstado;
        private Button btnAgregar;
        private Button btnLimpiar;
        private Panel panelContenido;
        private DataGridView dgvPedidos;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colNumeroPedido;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colEstado;
    }
}

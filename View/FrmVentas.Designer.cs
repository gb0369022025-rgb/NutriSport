namespace View
{
    partial class FrmVentas
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            panelSuperior = new Panel();
            lblTitulo = new Label();
            lblSeccion = new Label();
            btnVolver = new Button();
            panelInferior = new Panel();
            lblEstado = new Label();
            panelDatos = new Panel();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblCliente = new Label();
            cboCliente = new ComboBox();
            lblEstadoRegistro = new Label();
            cboEstado = new ComboBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblCodigoBarras = new Label();
            txtCodigoBarras = new TextBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            btnAgregar = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            panelContenido = new Panel();
            panelDetalle = new Panel();
            lblDetalle = new Label();
            dgvDetalle = new DataGridView();
            colDetProducto = new DataGridViewTextBoxColumn();
            colDetCantidad = new DataGridViewTextBoxColumn();
            colDetPrecio = new DataGridViewTextBoxColumn();
            colDetTotal = new DataGridViewTextBoxColumn();
            panelTotal = new Panel();
            lblTotal = new Label();
            btnQuitarProducto = new Button();
            lblHistorial = new Label();
            dgvVentas = new DataGridView();
            colIdVenta = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            panelDatos.SuspendLayout();
            panelContenido.SuspendLayout();
            panelDetalle.SuspendLayout();
            panelTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(btnVolver);
            panelSuperior.Controls.Add(lblSeccion);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1082, 60);
            panelSuperior.TabIndex = 4;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F);
            lblTitulo.Location = new Point(20, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(73, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Ventas";
            // 
            // lblSeccion
            // 
            lblSeccion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSeccion.ForeColor = Color.FromArgb(120, 130, 150);
            lblSeccion.Location = new Point(612, 20);
            lblSeccion.Name = "lblSeccion";
            lblSeccion.Size = new Size(300, 20);
            lblSeccion.TabIndex = 1;
            lblSeccion.Text = "GESTIÓN COMERCIAL";
            lblSeccion.TextAlign = ContentAlignment.MiddleRight;
            lblSeccion.UseMnemonic = false;
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(230, 235, 240);
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Location = new Point(932, 11);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(130, 38);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver al menú";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
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
            panelDatos.Controls.Add(btnEliminar);
            panelDatos.Controls.Add(btnLimpiar);
            panelDatos.Controls.Add(btnAgregar);
            panelDatos.Controls.Add(lblCantidad);
            panelDatos.Controls.Add(nudCantidad);
            panelDatos.Controls.Add(lblCodigoBarras);
            panelDatos.Controls.Add(txtCodigoBarras);
            panelDatos.Controls.Add(lblDescripcion);
            panelDatos.Controls.Add(txtDescripcion);
            panelDatos.Controls.Add(lblEstadoRegistro);
            panelDatos.Controls.Add(cboEstado);
            panelDatos.Controls.Add(lblCliente);
            panelDatos.Controls.Add(cboCliente);
            panelDatos.Controls.Add(lblFecha);
            panelDatos.Controls.Add(dtpFecha);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Location = new Point(0, 60);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(360, 513);
            panelDatos.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.ForeColor = Color.FromArgb(30, 30, 30);
            lblFecha.Location = new Point(20, 20);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(133, 20);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha de la venta";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Enabled = false;
            dtpFecha.Location = new Point(20, 42);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(320, 27);
            dtpFecha.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.ForeColor = Color.FromArgb(30, 30, 30);
            lblCliente.Location = new Point(20, 83);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(57, 20);
            lblCliente.TabIndex = 2;
            lblCliente.Text = "Cliente";
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(20, 105);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(320, 28);
            cboCliente.TabIndex = 3;
            // 
            // lblEstadoRegistro
            // 
            lblEstadoRegistro.AutoSize = true;
            lblEstadoRegistro.ForeColor = Color.FromArgb(30, 30, 30);
            lblEstadoRegistro.Location = new Point(20, 147);
            lblEstadoRegistro.Name = "lblEstadoRegistro";
            lblEstadoRegistro.Size = new Size(49, 20);
            lblEstadoRegistro.TabIndex = 4;
            lblEstadoRegistro.Text = "Estado";
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] { "Completada", "Pendiente", "Anulada" });
            cboEstado.Location = new Point(20, 169);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(320, 28);
            cboEstado.TabIndex = 5;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.ForeColor = Color.FromArgb(30, 30, 30);
            lblDescripcion.Location = new Point(20, 211);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(87, 20);
            lblDescripcion.TabIndex = 6;
            lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(20, 233);
            txtDescripcion.MaxLength = 250;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(320, 60);
            txtDescripcion.TabIndex = 7;
            // 
            // lblCodigoBarras
            // 
            lblCodigoBarras.AutoSize = true;
            lblCodigoBarras.ForeColor = Color.FromArgb(30, 30, 30);
            lblCodigoBarras.Location = new Point(20, 307);
            lblCodigoBarras.Name = "lblCodigoBarras";
            lblCodigoBarras.Size = new Size(125, 20);
            lblCodigoBarras.TabIndex = 8;
            lblCodigoBarras.Text = "Código de barras";
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.Location = new Point(20, 329);
            txtCodigoBarras.MaxLength = 30;
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(155, 27);
            txtCodigoBarras.KeyDown += txtCodigoBarras_KeyDown;
            txtCodigoBarras.TabIndex = 9;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.ForeColor = Color.FromArgb(30, 30, 30);
            lblCantidad.Location = new Point(185, 307);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(64, 20);
            lblCantidad.TabIndex = 10;
            lblCantidad.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(185, 329);
            nudCantidad.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(155, 27);
            nudCantidad.TabIndex = 11;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 51, 73);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(20, 380);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(155, 38);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "Registrar venta";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(230, 235, 240);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(185, 380);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 38);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(230, 235, 240);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(20, 428);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(155, 38);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvVentas);
            panelContenido.Controls.Add(lblHistorial);
            panelContenido.Controls.Add(panelDetalle);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(360, 60);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(10, 20, 20, 20);
            panelContenido.Size = new Size(722, 513);
            panelContenido.TabIndex = 2;
            // 
            // panelDetalle
            // 
            panelDetalle.Controls.Add(dgvDetalle);
            panelDetalle.Controls.Add(panelTotal);
            panelDetalle.Controls.Add(lblDetalle);
            panelDetalle.Dock = DockStyle.Top;
            panelDetalle.Location = new Point(10, 20);
            panelDetalle.Name = "panelDetalle";
            panelDetalle.Size = new Size(692, 230);
            panelDetalle.TabIndex = 15;
            // 
            // lblDetalle
            // 
            lblDetalle.Dock = DockStyle.Top;
            lblDetalle.ForeColor = Color.FromArgb(30, 30, 30);
            lblDetalle.Location = new Point(0, 0);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new Size(692, 28);
            lblDetalle.TabIndex = 16;
            lblDetalle.Text = "Productos de la venta";
            lblDetalle.TextAlign = ContentAlignment.TopLeft;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AllowUserToResizeRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.BackgroundColor = Color.White;
            dgvDetalle.BorderStyle = BorderStyle.None;
            dgvDetalle.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetalle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetalle.ColumnHeadersHeight = 40;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] { colDetProducto, colDetCantidad, colDetPrecio, colDetTotal });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDetalle.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDetalle.Dock = DockStyle.Fill;
            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.GridColor = Color.FromArgb(230, 235, 240);
            dgvDetalle.Location = new Point(0, 28);
            dgvDetalle.MultiSelect = false;
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.RowTemplate.Height = 32;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(692, 152);
            dgvDetalle.TabIndex = 17;
            dgvDetalle.DataBindingComplete += dgvDetalle_DataBindingComplete;
            // 
            // colDetProducto
            // 
            colDetProducto.DataPropertyName = "Producto";
            colDetProducto.FillWeight = 200F;
            colDetProducto.HeaderText = "Producto";
            colDetProducto.MinimumWidth = 90;
            colDetProducto.Name = "colDetProducto";
            colDetProducto.ReadOnly = true;
            // 
            // colDetCantidad
            // 
            colDetCantidad.DataPropertyName = "Cantidad";
            colDetCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDetCantidad.FillWeight = 60F;
            colDetCantidad.HeaderText = "Cantidad";
            colDetCantidad.MinimumWidth = 6;
            colDetCantidad.Name = "colDetCantidad";
            colDetCantidad.ReadOnly = true;
            // 
            // colDetPrecio
            // 
            colDetPrecio.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "$#,##0.00";
            dataGridViewCellStyle3.NullValue = null;
            colDetPrecio.DefaultCellStyle = dataGridViewCellStyle3;
            colDetPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDetPrecio.FillWeight = 80F;
            colDetPrecio.HeaderText = "Precio unitario";
            colDetPrecio.MinimumWidth = 6;
            colDetPrecio.Name = "colDetPrecio";
            colDetPrecio.ReadOnly = true;
            // 
            // colDetTotal
            // 
            colDetTotal.DataPropertyName = "Total";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "$#,##0.00";
            dataGridViewCellStyle4.NullValue = null;
            colDetTotal.DefaultCellStyle = dataGridViewCellStyle4;
            colDetTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDetTotal.FillWeight = 80F;
            colDetTotal.HeaderText = "Total";
            colDetTotal.MinimumWidth = 6;
            colDetTotal.Name = "colDetTotal";
            colDetTotal.ReadOnly = true;
            // 
            // panelTotal
            // 
            panelTotal.Controls.Add(btnQuitarProducto);
            panelTotal.Controls.Add(lblTotal);
            panelTotal.Dock = DockStyle.Bottom;
            panelTotal.Location = new Point(0, 180);
            panelTotal.Name = "panelTotal";
            panelTotal.Size = new Size(692, 50);
            panelTotal.TabIndex = 18;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F);
            lblTotal.Location = new Point(0, 12);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(118, 28);
            lblTotal.TabIndex = 19;
            lblTotal.Text = "Total: $0.00";
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuitarProducto.BackColor = Color.FromArgb(230, 235, 240);
            btnQuitarProducto.FlatStyle = FlatStyle.Flat;
            btnQuitarProducto.Location = new Point(537, 8);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(155, 38);
            btnQuitarProducto.TabIndex = 20;
            btnQuitarProducto.Text = "Quitar producto";
            btnQuitarProducto.UseVisualStyleBackColor = false;
            btnQuitarProducto.Click += btnQuitarProducto_Click;
            // 
            // lblHistorial
            // 
            lblHistorial.Dock = DockStyle.Top;
            lblHistorial.ForeColor = Color.FromArgb(30, 30, 30);
            lblHistorial.Location = new Point(10, 250);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(692, 34);
            lblHistorial.TabIndex = 21;
            lblHistorial.Text = "Ventas registradas";
            lblHistorial.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.AllowUserToResizeRows = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.BackgroundColor = Color.White;
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVentas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvVentas.ColumnHeadersHeight = 40;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVentas.Columns.AddRange(new DataGridViewColumn[] { colIdVenta, colFecha, colCliente, colDescripcion, colEstado });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle6.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvVentas.DefaultCellStyle = dataGridViewCellStyle6;
            dgvVentas.Dock = DockStyle.Fill;
            dgvVentas.EnableHeadersVisualStyles = false;
            dgvVentas.GridColor = Color.FromArgb(230, 235, 240);
            dgvVentas.Location = new Point(10, 284);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.RowTemplate.Height = 32;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(692, 209);
            dgvVentas.TabIndex = 22;
            dgvVentas.CellClick += dgvVentas_CellClick;
            dgvVentas.DataBindingComplete += dgvVentas_DataBindingComplete;
            // 
            // colIdVenta
            // 
            colIdVenta.DataPropertyName = "IdVenta";
            colIdVenta.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colIdVenta.FillWeight = 55F;
            colIdVenta.HeaderText = "N° venta";
            colIdVenta.MinimumWidth = 6;
            colIdVenta.Name = "colIdVenta";
            colIdVenta.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "FechaVenta";
            dataGridViewCellStyle7.Format = "dd/MM/yyyy";
            dataGridViewCellStyle7.NullValue = null;
            colFecha.DefaultCellStyle = dataGridViewCellStyle7;
            colFecha.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colFecha.FillWeight = 70F;
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.DataPropertyName = "Cliente";
            colCliente.FillWeight = 110F;
            colCliente.HeaderText = "Cliente";
            colCliente.MinimumWidth = 90;
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.FillWeight = 170F;
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.MinimumWidth = 90;
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "Estado";
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colEstado.FillWeight = 75F;
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 603);
            Controls.Add(panelContenido);
            Controls.Add(panelDatos);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            MinimumSize = new Size(1000, 600);
            Name = "FrmVentas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NutriSport - Ventas";
            Load += FrmVentas_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelContenido.ResumeLayout(false);
            panelDetalle.ResumeLayout(false);
            panelDetalle.PerformLayout();
            panelTotal.ResumeLayout(false);
            panelTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Label lblTitulo;
        private Label lblSeccion;
        private Button btnVolver;
        private Panel panelInferior;
        private Label lblEstado;
        private Panel panelDatos;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblCliente;
        private ComboBox cboCliente;
        private Label lblEstadoRegistro;
        private ComboBox cboEstado;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblCodigoBarras;
        private TextBox txtCodigoBarras;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnAgregar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Panel panelContenido;
        private Panel panelDetalle;
        private Label lblDetalle;
        private DataGridView dgvDetalle;
        private DataGridViewTextBoxColumn colDetProducto;
        private DataGridViewTextBoxColumn colDetCantidad;
        private DataGridViewTextBoxColumn colDetPrecio;
        private DataGridViewTextBoxColumn colDetTotal;
        private Panel panelTotal;
        private Label lblTotal;
        private Button btnQuitarProducto;
        private Label lblHistorial;
        private DataGridView dgvVentas;
        private DataGridViewTextBoxColumn colIdVenta;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colEstado;
    }
}

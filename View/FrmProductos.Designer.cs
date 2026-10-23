namespace View
{
    partial class FrmProductos
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
            btnVolver = new Button();
            panelInferior = new Panel();
            lblEstado = new Label();
            panelDatos = new Panel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPrecio = new Label();
            nudPrecio = new NumericUpDown();
            lblExistencia = new Label();
            nudExistencia = new NumericUpDown();
            lblCategoria = new Label();
            cboCategoria = new ComboBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnLimpiar = new Button();
            panelContenido = new Panel();
            panelBusqueda = new Panel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvProductos = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colExistencia = new DataGridViewTextBoxColumn();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            panelDatos.SuspendLayout();
            panelContenido.SuspendLayout();
            panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudExistencia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
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
            lblTitulo.Size = new Size(107, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Productos";
            // 
            // lblSeccion
            // 
            lblSeccion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSeccion.ForeColor = Color.FromArgb(120, 130, 150);
            lblSeccion.Location = new Point(612, 20);
            lblSeccion.Name = "lblSeccion";
            lblSeccion.Size = new Size(300, 20);
            lblSeccion.TabIndex = 1;
            lblSeccion.Text = "INVENTARIO & PRODUCTOS";
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
            panelDatos.Controls.Add(btnLimpiar);
            panelDatos.Controls.Add(btnModificar);
            panelDatos.Controls.Add(btnAgregar);
            panelDatos.Controls.Add(lblCategoria);
            panelDatos.Controls.Add(cboCategoria);
            panelDatos.Controls.Add(lblExistencia);
            panelDatos.Controls.Add(nudExistencia);
            panelDatos.Controls.Add(lblPrecio);
            panelDatos.Controls.Add(nudPrecio);
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
            lblNombre.Size = new Size(148, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre del producto";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(20, 42);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(320, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.ForeColor = Color.FromArgb(30, 30, 30);
            lblPrecio.Location = new Point(20, 83);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(80, 20);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio ($)";
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Location = new Point(20, 105);
            nudPrecio.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(155, 27);
            nudPrecio.TabIndex = 3;
            nudPrecio.ThousandsSeparator = true;
            // 
            // lblExistencia
            // 
            lblExistencia.AutoSize = true;
            lblExistencia.ForeColor = Color.FromArgb(30, 30, 30);
            lblExistencia.Location = new Point(185, 83);
            lblExistencia.Name = "lblExistencia";
            lblExistencia.Size = new Size(80, 20);
            lblExistencia.TabIndex = 4;
            lblExistencia.Text = "Existencia";
            // 
            // nudExistencia
            // 
            nudExistencia.Location = new Point(185, 105);
            nudExistencia.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudExistencia.Name = "nudExistencia";
            nudExistencia.Size = new Size(155, 27);
            nudExistencia.TabIndex = 5;
            nudExistencia.ThousandsSeparator = true;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.ForeColor = Color.FromArgb(30, 30, 30);
            lblCategoria.Location = new Point(20, 146);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(72, 20);
            lblCategoria.TabIndex = 6;
            lblCategoria.Text = "Categoría";
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(20, 168);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(320, 28);
            cboCategoria.TabIndex = 7;
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
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(46, 51, 73);
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.ForeColor = Color.White;
            btnModificar.Enabled = false;
            btnModificar.Location = new Point(185, 220);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(155, 38);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(230, 235, 240);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(20, 268);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 38);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvProductos);
            panelContenido.Controls.Add(panelBusqueda);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(360, 60);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(10, 20, 20, 20);
            panelContenido.Size = new Size(722, 513);
            panelContenido.TabIndex = 2;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Controls.Add(btnBuscar);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(lblBuscar);
            panelBusqueda.Dock = DockStyle.Top;
            panelBusqueda.Location = new Point(10, 20);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(692, 80);
            panelBusqueda.TabIndex = 11;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.ForeColor = Color.FromArgb(30, 30, 30);
            lblBuscar.Location = new Point(0, 0);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(201, 20);
            lblBuscar.TabIndex = 12;
            lblBuscar.Text = "Buscar producto por nombre";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(0, 22);
            txtBuscar.MaxLength = 50;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(330, 27);
            txtBuscar.TabIndex = 13;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(230, 235, 240);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(340, 17);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(130, 38);
            btnBuscar.TabIndex = 14;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.ColumnHeadersHeight = 40;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colProducto, colPrecio, colExistencia });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(230, 235, 240);
            dgvProductos.Location = new Point(10, 100);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowTemplate.Height = 32;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(692, 393);
            dgvProductos.TabIndex = 15;
            dgvProductos.CellClick += dgvProductos_CellClick;
            dgvProductos.DataBindingComplete += dgvProductos_DataBindingComplete;
            // 
            // colCodigo
            // 
            colCodigo.DataPropertyName = "ProductoId";
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colCodigo.FillWeight = 50F;
            colCodigo.HeaderText = "Código";
            colCodigo.MinimumWidth = 6;
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            // 
            // colProducto
            // 
            colProducto.DataPropertyName = "NombreProducto";
            colProducto.FillWeight = 200F;
            colProducto.HeaderText = "Producto";
            colProducto.MinimumWidth = 90;
            colProducto.Name = "colProducto";
            colProducto.ReadOnly = true;
            // 
            // colPrecio
            // 
            colPrecio.DataPropertyName = "Precio";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "$#,##0.00";
            dataGridViewCellStyle3.NullValue = null;
            colPrecio.DefaultCellStyle = dataGridViewCellStyle3;
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colPrecio.FillWeight = 70F;
            colPrecio.HeaderText = "Precio";
            colPrecio.MinimumWidth = 6;
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            // 
            // colExistencia
            // 
            colExistencia.DataPropertyName = "Existencia";
            colExistencia.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colExistencia.FillWeight = 70F;
            colExistencia.HeaderText = "Existencia";
            colExistencia.MinimumWidth = 6;
            colExistencia.Name = "colExistencia";
            colExistencia.ReadOnly = true;
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 603);
            Controls.Add(panelContenido);
            Controls.Add(panelDatos);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            MinimumSize = new Size(1000, 600);
            Name = "FrmProductos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NutriSport - Productos";
            Load += FrmProductos_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelContenido.ResumeLayout(false);
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudExistencia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
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
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblPrecio;
        private NumericUpDown nudPrecio;
        private Label lblExistencia;
        private NumericUpDown nudExistencia;
        private Label lblCategoria;
        private ComboBox cboCategoria;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnLimpiar;
        private Panel panelContenido;
        private Panel panelBusqueda;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colExistencia;
    }
}

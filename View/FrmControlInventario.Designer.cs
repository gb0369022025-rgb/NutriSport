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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            panelSuperior = new Panel();
            lblTitulo = new Label();
            lblSeccion = new Label();
            btnVolver = new Button();
            panelInferior = new Panel();
            lblEstado = new Label();
            panelDatos = new Panel();
            panelContenido = new Panel();
            dgvProductos = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colCodigoBarras = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colExistencia = new DataGridViewTextBoxColumn();
            lblCategorias = new Label();
            dgvCategorias = new DataGridView();
            colCategoriaId = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colProductos = new DataGridViewTextBoxColumn();
            colExistenciaTotal = new DataGridViewTextBoxColumn();
            lblProductos = new Label();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            panelDatos.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
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
            lblTitulo.Size = new Size(245, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Control de inventario";
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
            panelDatos.Controls.Add(dgvCategorias);
            panelDatos.Controls.Add(lblCategorias);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Location = new Point(0, 60);
            panelDatos.Name = "panelDatos";
            panelDatos.Padding = new Padding(20, 20, 10, 20);
            panelDatos.Size = new Size(360, 513);
            panelDatos.TabIndex = 1;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvProductos);
            panelContenido.Controls.Add(lblProductos);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(360, 60);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(10, 20, 20, 20);
            panelContenido.Size = new Size(722, 513);
            panelContenido.TabIndex = 2;
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
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colProducto, colCodigoBarras, colPrecio, colExistencia });
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
            dgvProductos.Location = new Point(10, 20);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowTemplate.Height = 32;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(692, 473);
            dgvProductos.TabIndex = 0;
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
            // colCodigoBarras
            // 
            colCodigoBarras.DataPropertyName = "CodigoBarras";
            colCodigoBarras.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colCodigoBarras.FillWeight = 90F;
            colCodigoBarras.HeaderText = "Código de barras";
            colCodigoBarras.MinimumWidth = 6;
            colCodigoBarras.Name = "colCodigoBarras";
            colCodigoBarras.ReadOnly = true;
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
            // lblCategorias
            // 
            lblCategorias.Dock = DockStyle.Top;
            lblCategorias.ForeColor = Color.FromArgb(30, 30, 30);
            lblCategorias.Location = new Point(20, 20);
            lblCategorias.Name = "lblCategorias";
            lblCategorias.Size = new Size(330, 28);
            lblCategorias.TabIndex = 0;
            lblCategorias.Text = "Categorías";
            lblCategorias.TextAlign = ContentAlignment.TopLeft;
            // 
            // dgvCategorias
            // 
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.AllowUserToResizeRows = false;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.BackgroundColor = Color.White;
            dgvCategorias.BorderStyle = BorderStyle.None;
            dgvCategorias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategorias.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCategorias.ColumnHeadersHeight = 40;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCategorias.Columns.AddRange(new DataGridViewColumn[] { colCategoriaId, colCategoria, colProductos, colExistenciaTotal });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle5.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvCategorias.DefaultCellStyle = dataGridViewCellStyle5;
            dgvCategorias.Dock = DockStyle.Fill;
            dgvCategorias.EnableHeadersVisualStyles = false;
            dgvCategorias.GridColor = Color.FromArgb(230, 235, 240);
            dgvCategorias.Location = new Point(20, 48);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.RowHeadersWidth = 51;
            dgvCategorias.RowTemplate.Height = 32;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(330, 445);
            dgvCategorias.TabIndex = 1;
            dgvCategorias.DataBindingComplete += dgvCategorias_DataBindingComplete;
            dgvCategorias.CellClick += dgvCategorias_CellClick;
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
            // 
            // colCategoriaId
            // 
            colCategoriaId.DataPropertyName = "CategoriaId";
            colCategoriaId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colCategoriaId.FillWeight = 40F;
            colCategoriaId.HeaderText = "Código";
            colCategoriaId.MinimumWidth = 6;
            colCategoriaId.Name = "colCategoriaId";
            colCategoriaId.ReadOnly = true;
            colCategoriaId.Visible = false;
            // 
            // colCategoria
            // 
            colCategoria.DataPropertyName = "Categoria";
            colCategoria.FillWeight = 150F;
            colCategoria.HeaderText = "Categoría";
            colCategoria.MinimumWidth = 90;
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            // 
            // colProductos
            // 
            colProductos.DataPropertyName = "Productos";
            colProductos.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colProductos.FillWeight = 60F;
            colProductos.HeaderText = "Productos";
            colProductos.MinimumWidth = 6;
            colProductos.Name = "colProductos";
            colProductos.ReadOnly = true;
            // 
            // colExistenciaTotal
            // 
            colExistenciaTotal.DataPropertyName = "Existencia";
            colExistenciaTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colExistenciaTotal.FillWeight = 60F;
            colExistenciaTotal.HeaderText = "Existencia";
            colExistenciaTotal.MinimumWidth = 6;
            colExistenciaTotal.Name = "colExistenciaTotal";
            colExistenciaTotal.ReadOnly = true;
            // 
            // lblProductos
            // 
            lblProductos.Dock = DockStyle.Top;
            lblProductos.ForeColor = Color.FromArgb(30, 30, 30);
            lblProductos.Location = new Point(10, 20);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(692, 28);
            lblProductos.TabIndex = 2;
            lblProductos.Text = "Selecciona una categoría para ver sus productos";
            lblProductos.TextAlign = ContentAlignment.TopLeft;
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
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
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
        private Panel panelContenido;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colCodigoBarras;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colExistencia;
        private Label lblCategorias;
        private DataGridView dgvCategorias;
        private DataGridViewTextBoxColumn colCategoriaId;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colProductos;
        private DataGridViewTextBoxColumn colExistenciaTotal;
        private Label lblProductos;
    }
}

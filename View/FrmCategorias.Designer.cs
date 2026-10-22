namespace View
{
    partial class FrmCategorias
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
            lblNombreCategoria = new Label();
            txtNombreCategoria = new TextBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            panelContenido = new Panel();
            dgvCategorias = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            panelSuperior.SuspendLayout();
            panelInferior.SuspendLayout();
            panelDatos.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
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
            lblTitulo.Size = new Size(119, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Categorías";
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
            panelDatos.Controls.Add(btnEliminar);
            panelDatos.Controls.Add(btnModificar);
            panelDatos.Controls.Add(btnAgregar);
            panelDatos.Controls.Add(lblNombreCategoria);
            panelDatos.Controls.Add(txtNombreCategoria);
            panelDatos.Dock = DockStyle.Left;
            panelDatos.Location = new Point(0, 60);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(360, 513);
            panelDatos.TabIndex = 1;
            // 
            // lblNombreCategoria
            // 
            lblNombreCategoria.AutoSize = true;
            lblNombreCategoria.ForeColor = Color.FromArgb(30, 30, 30);
            lblNombreCategoria.Location = new Point(20, 20);
            lblNombreCategoria.Name = "lblNombreCategoria";
            lblNombreCategoria.Size = new Size(171, 20);
            lblNombreCategoria.TabIndex = 0;
            lblNombreCategoria.Text = "Nombre de la categoría";
            // 
            // txtNombreCategoria
            // 
            txtNombreCategoria.Location = new Point(20, 42);
            txtNombreCategoria.MaxLength = 50;
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.Size = new Size(320, 27);
            txtNombreCategoria.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 51, 73);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(20, 93);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(155, 38);
            btnAgregar.TabIndex = 2;
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
            btnModificar.Location = new Point(185, 93);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(155, 38);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(230, 235, 240);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(20, 141);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(155, 38);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(230, 235, 240);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(185, 141);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 38);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvCategorias);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(360, 60);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(10, 20, 20, 20);
            panelContenido.Size = new Size(722, 513);
            panelContenido.TabIndex = 2;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 30, 54);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCategorias.ColumnHeadersHeight = 40;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCategorias.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colCategoria });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCategorias.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCategorias.Dock = DockStyle.Fill;
            dgvCategorias.EnableHeadersVisualStyles = false;
            dgvCategorias.GridColor = Color.FromArgb(230, 235, 240);
            dgvCategorias.Location = new Point(10, 20);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.RowHeadersWidth = 51;
            dgvCategorias.RowTemplate.Height = 32;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(692, 473);
            dgvCategorias.TabIndex = 6;
            dgvCategorias.CellClick += dgvCategorias_CellClick;
            dgvCategorias.DataBindingComplete += dgvCategorias_DataBindingComplete;
            // 
            // colCodigo
            // 
            colCodigo.DataPropertyName = "CategoriaId";
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCodigo.FillWeight = 40F;
            colCodigo.HeaderText = "Código";
            colCodigo.MinimumWidth = 6;
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            // 
            // colCategoria
            // 
            colCategoria.DataPropertyName = "NombreCategoria";
            colCategoria.FillWeight = 200F;
            colCategoria.HeaderText = "Categoría";
            colCategoria.MinimumWidth = 90;
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            // 
            // FrmCategorias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 603);
            Controls.Add(panelContenido);
            Controls.Add(panelDatos);
            Controls.Add(panelInferior);
            Controls.Add(panelSuperior);
            MinimumSize = new Size(1000, 600);
            Name = "FrmCategorias";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NutriSport - Categorías";
            Load += FrmCategorias_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Label lblTitulo;
        private Label lblSeccion;
        private Panel panelInferior;
        private Label lblEstado;
        private Panel panelDatos;
        private Label lblNombreCategoria;
        private TextBox txtNombreCategoria;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Panel panelContenido;
        private DataGridView dgvCategorias;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colCategoria;
    }
}

using Entities;
using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmProductos : Form
    {
        private const string Titulo = "Productos";
        private short productoIdSeleccionado = 0;

        public FrmProductos()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProductos();
            LimpiarCampos();
        }

        private void CargarCategorias()
        {
            try
            {
                List<Categoria> categorias = Categoria_BL.ObtenerTodos();
                cboCategoria.DataSource = categorias;
                cboCategoria.DisplayMember = nameof(Categoria.NombreCategoria);
                cboCategoria.ValueMember = nameof(Categoria.CategoriaId);
                cboCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de categorías.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos()
        {
            try
            {
                string texto = txtBuscar.Text.Trim();
                List<Producto> productos = texto.Length == 0
                    ? Producto_BL.ObtenerTodos()
                    : Producto_BL.BuscarPorNombre(texto);
                dgvProductos.DataSource = productos;

                string cantidad = productos.Count == 1 ? "1 producto" : $"{productos.Count} productos";
                lblEstado.Text = texto.Length == 0 ? cantidad + " registrados" : $"{cantidad} encontrados para \"{texto}\"";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de productos. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Escribe el nombre del producto.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (nudPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que $0.00.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudPrecio.Focus();
                return false;
            }
            if (cboCategoria.SelectedValue == null)
            {
                MessageBox.Show("Selecciona la categoría del producto.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategoria.Focus();
                return false;
            }
            return true;
        }

        private Producto LeerCampos()
        {
            return new Producto
            {
                ProductoId = productoIdSeleccionado,
                NombreProducto = txtNombre.Text.Trim(),
                Precio = nudPrecio.Value,
                Existencia = (int)nudExistencia.Value,
                CategoriaId = Convert.ToInt32(cboCategoria.SelectedValue)
            };
        }

        private void LimpiarCampos()
        {
            productoIdSeleccionado = 0;
            txtNombre.Clear();
            nudPrecio.Value = 0;
            nudExistencia.Value = 0;
            cboCategoria.SelectedIndex = -1;
            btnModificar.Enabled = false;
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                Producto producto = LeerCampos();
                int filas = Producto_BL.Agregar(producto);
                if (filas > 0)
                {
                    MessageBox.Show("Producto agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("Ya existe un producto con ese nombre.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el producto.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (productoIdSeleccionado == 0)
            {
                MessageBox.Show("Selecciona en la lista el producto que quieres modificar.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCampos()) return;

            try
            {
                Producto producto = LeerCampos();
                int filas = Producto_BL.Modificar(producto);
                if (filas > 0)
                {
                    MessageBox.Show("Producto modificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("Ya existe otro producto con ese nombre.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar el producto.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CargarProductos();
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProductos.Rows[e.RowIndex].DataBoundItem is not Producto producto) return;

            productoIdSeleccionado = producto.ProductoId;
            txtNombre.Text = producto.NombreProducto;
            nudPrecio.Value = Math.Min(producto.Precio, nudPrecio.Maximum);
            nudExistencia.Value = Math.Min(producto.Existencia, nudExistencia.Maximum);
            if (producto.CategoriaId.HasValue)
                cboCategoria.SelectedValue = producto.CategoriaId.Value;
            else
                cboCategoria.SelectedIndex = -1;
            btnModificar.Enabled = true;
        }

        private void dgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProductos.ClearSelection();
        }
    }
}

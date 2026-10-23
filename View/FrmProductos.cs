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

        // Categorías y productos se consultan al mismo tiempo, en segundo plano
        private async void FrmProductos_Load(object sender, EventArgs e)
        {
            MostrarOcupado(true, "Cargando productos...");
            try
            {
                Task<List<Categoria>> tareaCategorias = Task.Run(() => Categoria_BL.ObtenerTodos());
                Task<List<Producto>> tareaProductos = Task.Run(() => Producto_BL.ObtenerTodos());
                await Task.WhenAll(tareaCategorias, tareaProductos);
                if (IsDisposed) return;

                cboCategoria.DataSource = tareaCategorias.Result;
                cboCategoria.DisplayMember = nameof(Categoria.NombreCategoria);
                cboCategoria.ValueMember = nameof(Categoria.CategoriaId);
                MostrarProductos(tareaProductos.Result, string.Empty);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudieron cargar los productos y categorías. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
            if (!IsDisposed) LimpiarCampos();
        }

        private async Task CargarProductosAsync()
        {
            string texto = txtBuscar.Text.Trim();
            MostrarOcupado(true, "Cargando productos...");
            try
            {
                List<Producto> productos = await Task.Run(() => texto.Length == 0
                    ? Producto_BL.ObtenerTodos()
                    : Producto_BL.BuscarPorNombre(texto));
                if (IsDisposed) return;
                MostrarProductos(productos, texto);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de productos. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private void MostrarProductos(List<Producto> productos, string texto)
        {
            dgvProductos.DataSource = productos;
            string cantidad = productos.Count == 1 ? "1 producto" : $"{productos.Count} productos";
            lblEstado.Text = texto.Length == 0 ? cantidad + " registrados" : $"{cantidad} encontrados para \"{texto}\"";
        }

        private void MostrarOcupado(bool ocupado, string? mensaje = null)
        {
            panelDatos.Enabled = !ocupado;
            panelBusqueda.Enabled = !ocupado;
            UseWaitCursor = ocupado;
            if (mensaje != null) lblEstado.Text = mensaje;
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
            VaciarSeleccion(cboCategoria);
            btnModificar.Enabled = false;
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }

        // En un ComboBox enlazado a datos, WinForms solo lo deja vacío si se asigna -1 dos veces
        private static void VaciarSeleccion(ComboBox combo)
        {
            combo.SelectedIndex = -1;
            combo.SelectedIndex = -1;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Producto producto = LeerCampos();
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await Task.Run(() => Producto_BL.Agregar(producto));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Producto agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarProductosAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ya existe un producto con ese nombre.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo agregar el producto.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (productoIdSeleccionado == 0)
            {
                MessageBox.Show("Selecciona en la lista el producto que quieres modificar.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCampos()) return;

            Producto producto = LeerCampos();
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await Task.Run(() => Producto_BL.Modificar(producto));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Producto modificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarProductosAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ya existe otro producto con ese nombre.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo modificar el producto.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await CargarProductosAsync();
        }

        private async void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await CargarProductosAsync();
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
                VaciarSeleccion(cboCategoria);
            btnModificar.Enabled = true;
        }

        private void dgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProductos.ClearSelection();
        }
    }
}

using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using Entities;
using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmProductos : Form
    {
        private const string Titulo = "Productos";
        private string productoSeleccionado = string.Empty;
        private short productoIdSeleccionado = 0;
        private List<Categoria> categorias = new List<Categoria>();

        public FrmProductos()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
        }

        private async void FrmProductos_Load(object sender, EventArgs e)
        {
            MostrarOcupado(true, "Cargando productos...");
            try
            {
                Task<List<Categoria>> tareaCategorias = EnSegundoPlano(() => Categoria_BL.ObtenerTodos());
                Task<List<Producto>> tareaProductos = EnSegundoPlano(() => Producto_BL.ObtenerTodos());
                await Task.WhenAll(tareaCategorias, tareaProductos);
                if (IsDisposed) return;

                categorias = tareaCategorias.Result;
                cboCategoria.DataSource = categorias;
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
                List<Producto> productos = await EnSegundoPlano(() => texto.Length == 0
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

        private static Task<T> EnSegundoPlano<T>(Func<T> consulta)
        {
            return Task.Run(() =>
            {
                try
                {
                    return Task.FromResult(consulta());
                }
                catch (Exception ex)
                {
                    return Task.FromException<T>(ex);
                }
            });
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
            if (string.IsNullOrWhiteSpace(txtCodigoBarras.Text))
            {
                MessageBox.Show("Escanea o escribe el código de barras del producto.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBarras.Focus();
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
                CategoriaId = Convert.ToInt32(cboCategoria.SelectedValue),
                CodigoBarras = txtCodigoBarras.Text.Trim()
            };
        }

        private void LimpiarCampos()
        {
            productoIdSeleccionado = 0;
            txtNombre.Clear();
            nudPrecio.Value = 0;
            nudExistencia.Value = 0;
            txtCodigoBarras.Clear();
            VaciarSeleccion(cboCategoria);
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }

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
                int filas = await EnSegundoPlano(() => Producto_BL.Agregar(producto));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Producto agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarProductosAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ya existe un producto con ese nombre o con ese código de barras.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                int filas = await EnSegundoPlano(() => Producto_BL.Modificar(producto));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Producto modificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarProductosAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ya existe otro producto con ese nombre o con ese código de barras.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (productoIdSeleccionado == 0)
            {
                MessageBox.Show("Selecciona en la lista el producto que quieres eliminar.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show($"¿Eliminar {productoSeleccionado}?",
                Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            int id = productoIdSeleccionado;
            MostrarOcupado(true, "Eliminando...");
            try
            {
                int filas = await EnSegundoPlano(() => Producto_BL.Eliminar(id));
                if (IsDisposed) return;
                MessageBox.Show(filas > 0 ? "Producto eliminado." : "El producto ya no existe. Se actualizará la lista.",
                    Titulo, MessageBoxButtons.OK, filas > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                await CargarProductosAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo eliminar el producto.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await BuscarAsync();
        }

        private async void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await BuscarAsync();
            }
        }

        private async Task BuscarAsync()
        {
            string texto = txtBuscar.Text.Trim();
            if (texto.Length == 0 || texto.Contains(' '))
            {
                await CargarProductosAsync();
                return;
            }

            MostrarOcupado(true, "Buscando...");
            Producto? producto = null;
            bool fallo = false;
            try
            {
                producto = await EnSegundoPlano(() => Producto_BL.BuscarPorCodigoBarras(texto));
                if (IsDisposed) return;
                if (producto != null)
                {
                    dgvProductos.DataSource = new List<Producto> { producto };
                    MostrarEnCampos(producto);
                    lblEstado.Text = $"Código {texto}: {producto.NombreProducto}";
                }
            }
            catch (Exception ex)
            {
                fallo = true;
                if (IsDisposed) return;
                MessageBox.Show("No se pudo buscar el código de barras.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                {
                    MostrarOcupado(false);
                    txtBuscar.SelectAll();
                    txtBuscar.Focus();
                }
            }

            if (producto == null && !fallo && !IsDisposed) await CargarProductosAsync();
        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }

        private void btnImprimirEtiqueta_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoBarras.Text.Trim();
            if (codigo.Length == 0)
            {
                MessageBox.Show("Selecciona un producto con código de barras para imprimir su etiqueta.",
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var generador = new ZXing.Windows.Compatibility.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions { Width = 400, Height = 140, Margin = 10, PureBarcode = false }
            };
            using Bitmap imagen = generador.Write(codigo);
            string nombre = txtNombre.Text.Trim();
            string precio = nudPrecio.Value.ToString("$#,##0.00");

            using var documento = new PrintDocument { DocumentName = $"Etiqueta {codigo}" };
            documento.PrintPage += (s, ev) =>
            {
                Graphics g = ev.Graphics!;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                using var fuente = new Font("Segoe UI", 9F);
                g.DrawString(nombre, fuente, Brushes.Black, 20, 20);
                g.DrawString(precio, fuente, Brushes.Black, 20, 38);
                g.DrawImage(imagen, 20, 60, 200, 70);
            };
            using var vistaPrevia = new PrintPreviewDialog { Document = documento, Width = 800, Height = 600, Icon = Icon };
            vistaPrevia.ShowDialog(this);
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProductos.Rows[e.RowIndex].DataBoundItem is not Producto producto) return;
            MostrarEnCampos(producto);
        }

        private void MostrarEnCampos(Producto producto)
        {
            productoIdSeleccionado = producto.ProductoId;
            txtNombre.Text = producto.NombreProducto;
            nudPrecio.Value = Math.Min(producto.Precio, nudPrecio.Maximum);
            nudExistencia.Value = Math.Min(producto.Existencia, nudExistencia.Maximum);
            txtCodigoBarras.Text = producto.CodigoBarras;
            if (producto.CategoriaId.HasValue)
                cboCategoria.SelectedValue = producto.CategoriaId.Value;
            else
                VaciarSeleccion(cboCategoria);
            btnModificar.Enabled = true;
            productoSeleccionado = $"el producto \"{producto.NombreProducto}\"";
            btnEliminar.Enabled = true;
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != colCategoria.Index || e.Value == null || e.Value == DBNull.Value) return;
            int id = Convert.ToInt32(e.Value);
            e.Value = categorias.FirstOrDefault(c => c.CategoriaId == id)?.NombreCategoria ?? id.ToString();
            e.FormattingApplied = true;
        }

        private void dgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProductos.ClearSelection();
        }
    }
}

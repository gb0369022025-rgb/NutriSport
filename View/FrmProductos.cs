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
                Task<List<Categoria>> tareaCategorias = EnSegundoPlano(() => Categoria_BL.ObtenerTodos());
                Task<List<Producto>> tareaProductos = EnSegundoPlano(() => Producto_BL.ObtenerTodos());
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

        // Ejecuta la consulta en segundo plano. Si falla, el error se entrega al formulario como resultado
        // en lugar de lanzarse dentro del hilo; así Visual Studio no pausa el programa y se muestra el mensaje.
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
                CodigoBarras = string.IsNullOrWhiteSpace(txtCodigoBarras.Text) ? null : txtCodigoBarras.Text.Trim()
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

        // Cierra esta ventana y regresa al formulario principal
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

        // Si el texto es un código de barras (lo que escribe el lector), lo busca por coincidencia exacta;
        // si es un nombre, hace la búsqueda por nombre de siempre
        private async Task BuscarAsync()
        {
            string texto = txtBuscar.Text.Trim();
            if (!EsCodigoDeBarras(texto))
            {
                await CargarProductosAsync();
                return;
            }

            MostrarOcupado(true, "Buscando código...");
            try
            {
                Producto? producto = await EnSegundoPlano(() => Producto_BL.BuscarPorCodigoBarras(texto));
                if (IsDisposed) return;
                if (producto == null)
                {
                    lblEstado.Text = $"Ningún producto tiene el código {texto}";
                    MessageBox.Show($"Ningún producto tiene el código de barras {texto}.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvProductos.DataSource = new List<Producto> { producto };
                MostrarEnCampos(producto);
                lblEstado.Text = $"Código {texto}: {producto.NombreProducto}";
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo buscar el código de barras.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                {
                    MostrarOcupado(false);
                    txtBuscar.SelectAll();  // el siguiente escaneo reemplaza el texto
                    txtBuscar.Focus();
                }
            }
        }

        // Un código de barras no tiene espacios y es solo números (códigos de fábrica) o empieza con NS (códigos internos)
        private static bool EsCodigoDeBarras(string texto)
        {
            return texto.Length >= 6 && !texto.Contains(' ') && (texto.All(char.IsDigit) || texto.StartsWith("NS"));
        }

        // El lector termina cada lectura con Enter; aquí se ignora para que no suene el aviso de Windows
        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }

        // Código interno para productos sin código de fábrica: NS + número del producto con 6 dígitos (NS000007)
        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
            if (productoIdSeleccionado == 0)
            {
                MessageBox.Show("Primero agrega el producto y selecciónalo en la lista: el código interno se forma con su número.",
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCodigoBarras.Text) &&
                MessageBox.Show($"Este producto ya tiene el código {txtCodigoBarras.Text.Trim()}. ¿Reemplazarlo por uno interno?",
                    Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            txtCodigoBarras.Text = $"NS{productoIdSeleccionado:D6}";
            MessageBox.Show("Código generado. Haz clic en Modificar para guardarlo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Dibuja la etiqueta (nombre, precio y código de barras Code 128) y abre la vista previa para imprimirla
        private void btnImprimirEtiqueta_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoBarras.Text.Trim();
            if (codigo.Length == 0)
            {
                MessageBox.Show("El producto no tiene código de barras. Escanéalo o genéralo, y guárdalo con Modificar.",
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
                g.InterpolationMode = InterpolationMode.NearestNeighbor;  // barras nítidas para que el lector las lea
                using var fuente = new Font("Segoe UI", 9F);
                g.DrawString(nombre, fuente, Brushes.Black, 20, 20);
                g.DrawString(precio, fuente, Brushes.Black, 20, 38);
                g.DrawImage(imagen, 20, 60, 200, 70);  // unidades de 1/100 de pulgada: 5 x 1.8 cm
            };
            using var vistaPrevia = new PrintPreviewDialog { Document = documento, Width = 800, Height = 600 };
            vistaPrevia.ShowDialog(this);
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProductos.Rows[e.RowIndex].DataBoundItem is not Producto producto) return;
            MostrarEnCampos(producto);
        }

        // Carga el producto en los campos; lo usan el clic en la tabla y la búsqueda por escaneo
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

        private void dgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProductos.ClearSelection();
        }
    }
}

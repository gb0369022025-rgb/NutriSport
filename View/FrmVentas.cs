using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using Entities;
using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmVentas : Form
    {
        private const string Titulo = "Ventas";
        private int ventaIdSeleccionado = 0;
        private string ventaSeleccionado = string.Empty;
        private List<Cliente> clientes = new List<Cliente>();
        private readonly SemaphoreSlim escaneo = new SemaphoreSlim(1, 1);
        private const string EmpresaNombre = "NutriSport El Salvador S.A. de C.V.";
        private const string EmpresaGiro = "Venta de Ropa, Calzado Deportivo y Suplementos";
        private const string EmpresaDireccion = "Bulevar de Los Héroes #125, San Salvador";
        private const string EmpresaTelefono = "2225-7000";
        private const string EmpresaCnr = "198234-5";
        private int ticketVenta;
        private DateTime ticketFecha;
        private string ticketCliente = string.Empty;
        private string ticketDui = string.Empty;
        private List<(string Producto, int Cantidad, decimal Precio, decimal Total)> ticketLineas = new List<(string Producto, int Cantidad, decimal Precio, decimal Total)>();
        private decimal ticketTotal;

        public string Vendedor { get; set; } = string.Empty;

        public FrmVentas()
        {
            InitializeComponent();
            dgvVentas.AutoGenerateColumns = false;
        }

        private async void FrmVentas_Load(object sender, EventArgs e)
        {
            MostrarOcupado(true, "Cargando ventas...");
            try
            {
                Task<List<Cliente>> tareaClientes = EnSegundoPlano(() => Cliente_BL.ObtenerTodos());
                Task<List<Venta>> tareaVentas = EnSegundoPlano(() => Venta_BL.ObtenerTodos());
                await Task.WhenAll(tareaClientes, tareaVentas);
                if (IsDisposed) return;

                clientes = tareaClientes.Result;
                cboCliente.DataSource = clientes
                    .Select(c => new { c.ClienteId, NombreCompleto = $"{c.Nombre} {c.Apellido}".Trim() })
                    .ToList();
                cboCliente.DisplayMember = "NombreCompleto";
                cboCliente.ValueMember = "ClienteId";
                MostrarVentas(tareaVentas.Result);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudieron cargar las ventas y los clientes. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
            if (!IsDisposed) LimpiarCampos();
        }

        private async Task CargarVentasAsync()
        {
            MostrarOcupado(true, "Cargando ventas...");
            try
            {
                List<Venta> ventas = await EnSegundoPlano(() => Venta_BL.ObtenerTodos());
                if (IsDisposed) return;
                MostrarVentas(ventas);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de ventas. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private void MostrarVentas(List<Venta> ventas)
        {
            dgvVentas.DataSource = ventas
                .Select(v => new
                {
                    v.IdVenta,
                    v.FechaVenta,
                    Cliente = NombreCliente(v.ClienteId),
                    v.Descripcion,
                    v.Estado
                })
                .ToList();
            lblEstado.Text = ventas.Count == 1 ? "1 venta registrada" : $"{ventas.Count} ventas registradas";
        }

        private string NombreCliente(int? clienteId)
        {
            if (!clienteId.HasValue) return "Sin cliente";
            Cliente? cliente = clientes.FirstOrDefault(c => c.ClienteId == clienteId.Value);
            return cliente == null ? $"Cliente {clienteId.Value}" : $"{cliente.Nombre} {cliente.Apellido}".Trim();
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
            panelDetalle.Enabled = !ocupado;
            UseWaitCursor = ocupado;
            if (mensaje != null) lblEstado.Text = mensaje;
        }

        private async void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;

            string codigo = txtCodigoBarras.Text.Trim();
            int cantidad = (int)nudCantidad.Value;
            txtCodigoBarras.Clear();
            nudCantidad.Value = nudCantidad.Minimum;
            if (codigo.Length == 0) return;

            await escaneo.WaitAsync();
            try
            {
                Producto? producto = await EnSegundoPlano(() => Producto_BL.BuscarPorCodigoBarras(codigo));
                if (IsDisposed) return;
                if (producto == null)
                {
                    MessageBox.Show($"Ningún producto tiene el código de barras {codigo}.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AgregarALaVenta(producto, cantidad);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo buscar el código de barras.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                escaneo.Release();
                if (!IsDisposed) txtCodigoBarras.Focus();
            }
        }

        private void AgregarALaVenta(Producto producto, int cantidad)
        {
            DataGridViewRow? fila = dgvDetalle.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Tag is Producto p && p.ProductoId == producto.ProductoId);
            int cantidadTotal = cantidad + (fila == null ? 0 : Convert.ToInt32(fila.Cells[colDetCantidad.Index].Value));

            if (cantidadTotal > producto.Existencia || cantidadTotal > short.MaxValue)
            {
                MessageBox.Show($"Solo hay {producto.Existencia} unidades de {producto.NombreProducto} en existencia.",
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fila == null)
            {
                int indice = dgvDetalle.Rows.Add(producto.NombreProducto, cantidadTotal, producto.Precio, cantidadTotal * producto.Precio);
                fila = dgvDetalle.Rows[indice];
            }
            else
            {
                fila.Cells[colDetCantidad.Index].Value = cantidadTotal;
                fila.Cells[colDetPrecio.Index].Value = producto.Precio;
                fila.Cells[colDetTotal.Index].Value = cantidadTotal * producto.Precio;
            }
            fila.Tag = producto;
            dgvDetalle.ClearSelection();
            ActualizarTotal();
            lblEstado.Text = $"{producto.NombreProducto}: {cantidadTotal} en la venta";
        }

        private decimal TotalVenta()
        {
            return dgvDetalle.Rows.Cast<DataGridViewRow>().Sum(r => Convert.ToDecimal(r.Cells[colDetTotal.Index].Value));
        }

        private void ActualizarTotal()
        {
            lblTotal.Text = $"Total: {TotalVenta():$#,##0.00}";
            btnImprimirTicket.Enabled = dgvDetalle.Rows.Count > 0 || ticketVenta != 0;
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona en la lista el producto que quieres quitar.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvDetalle.Rows.Remove(dgvDetalle.SelectedRows[0]);
            dgvDetalle.ClearSelection();
            ActualizarTotal();
            txtCodigoBarras.Focus();
        }

        private bool ValidarCampos()
        {
            if (cboCliente.SelectedValue == null)
            {
                MessageBox.Show("Selecciona el cliente de la venta.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCliente.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Escribe la descripción de la venta.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Escanea al menos un producto para registrar la venta.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBarras.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            ventaIdSeleccionado = 0;
            btnEliminar.Enabled = false;
            dtpFecha.Value = DateTime.Today;
            VaciarSeleccion(cboCliente);
            cboEstado.SelectedIndex = 0;
            txtDescripcion.Clear();
            txtCodigoBarras.Clear();
            nudCantidad.Value = nudCantidad.Minimum;
            dgvDetalle.Rows.Clear();
            ActualizarTotal();
            dgvVentas.ClearSelection();
            txtCodigoBarras.Focus();
        }

        private static void VaciarSeleccion(ComboBox combo)
        {
            combo.SelectedIndex = -1;
            combo.SelectedIndex = -1;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            await RegistrarVentaAsync(false);
        }

        private async void btnImprimirTicket_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                await RegistrarVentaAsync(true);
            }
            else if (ticketVenta != 0)
            {
                MostrarTicket();
            }
        }

        private async Task RegistrarVentaAsync(bool imprimirTicket)
        {
            if (!ValidarCampos()) return;

            dtpFecha.Value = DateTime.Today;
            var venta = new Venta
            {
                FechaVenta = DateTime.Today,
                ClienteId = Convert.ToInt32(cboCliente.SelectedValue),
                Estado = cboEstado.Text,
                Descripcion = txtDescripcion.Text.Trim()
            };
            var detalle = dgvDetalle.Rows.Cast<DataGridViewRow>()
                .Select(r => new Detalle_Venta
                {
                    ProductoId = ((Producto)r.Tag!).ProductoId,
                    Cantidad = Convert.ToInt16(r.Cells[colDetCantidad.Index].Value)
                })
                .ToList();
            decimal total = TotalVenta();
            string cliente = cboCliente.Text;
            int clienteId = Convert.ToInt32(cboCliente.SelectedValue);
            string dui = clientes.FirstOrDefault(c => c.ClienteId == clienteId)?.DUI ?? string.Empty;
            var lineas = dgvDetalle.Rows.Cast<DataGridViewRow>()
                .Select(r => (Producto: Convert.ToString(r.Cells[colDetProducto.Index].Value) ?? string.Empty,
                              Cantidad: Convert.ToInt32(r.Cells[colDetCantidad.Index].Value),
                              Precio: Convert.ToDecimal(r.Cells[colDetPrecio.Index].Value),
                              Total: Convert.ToDecimal(r.Cells[colDetTotal.Index].Value)))
                .ToList();

            int idVenta;
            MostrarOcupado(true, "Registrando venta...");
            try
            {
                idVenta = await EnSegundoPlano(() => Venta_BL.Registrar(venta, detalle));
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo registrar la venta. Si algún producto ya no tiene existencia suficiente, la venta no se guarda.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
            if (IsDisposed) return;

            ticketVenta = idVenta;
            ticketFecha = DateTime.Now;
            ticketCliente = cliente;
            ticketDui = dui;
            ticketLineas = lineas;
            ticketTotal = total;

            if (imprimirTicket)
            {
                MostrarTicket();
            }
            else if (MessageBox.Show($"Venta N° {idVenta} registrada por {total:$#,##0.00}.\n\n¿Deseas imprimir el ticket?",
                         Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MostrarTicket();
            }

            await CargarVentasAsync();
            LimpiarCampos();
        }

        private void MostrarTicket()
        {
            using PrintDocument documento = CrearTicket();
            using var vistaPrevia = new PrintPreviewDialog
            {
                Document = documento,
                Icon = Icon,
                Text = $"Ticket - Factura {ticketVenta:D6}",
                Width = 520,
                Height = 760,
                StartPosition = FormStartPosition.CenterParent
            };
            vistaPrevia.PrintPreviewControl.Zoom = 1.0;
            vistaPrevia.ShowDialog(this);
        }

        private PrintDocument CrearTicket()
        {
            var documento = new PrintDocument { DocumentName = $"Factura {ticketVenta:D6}" };
            documento.PrintPage += (s, ev) =>
            {
                Graphics g = ev.Graphics!;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                float x = 10;
                float y = 10;
                float ancho = Math.Min(ev.PageBounds.Width - 20, 280);
                using var fuenteTitulo = new Font("Segoe UI", 10F, FontStyle.Bold);
                using var fuente = new Font("Segoe UI", 8F);
                using var fuenteNegrita = new Font("Segoe UI", 8F, FontStyle.Bold);
                using var fuenteTotal = new Font("Segoe UI", 11F, FontStyle.Bold);
                using var centrado = new StringFormat { Alignment = StringAlignment.Center };
                using var derecha = new StringFormat { Alignment = StringAlignment.Far };
                using var separador = new Pen(Color.Black) { DashStyle = DashStyle.Dash };
                float alto = fuente.GetHeight(g);

                void Texto(string texto, Font letra, StringFormat? formato = null)
                {
                    SizeF tam = g.MeasureString(texto, letra, (int)ancho);
                    g.DrawString(texto, letra, Brushes.Black, new RectangleF(x, y, ancho, tam.Height), formato ?? StringFormat.GenericDefault);
                    y += tam.Height;
                }

                void Fila(string izquierda, string valor, Font letra)
                {
                    float altoFila = letra.GetHeight(g);
                    g.DrawString(izquierda, letra, Brushes.Black, x, y);
                    g.DrawString(valor, letra, Brushes.Black, new RectangleF(x, y, ancho, altoFila), derecha);
                    y += altoFila;
                }

                void Separador()
                {
                    y += 4;
                    g.DrawLine(separador, x, y, x + ancho, y);
                    y += 6;
                }

                using (Stream? recurso = typeof(Program).Assembly.GetManifestResourceStream("logo.png"))
                {
                    if (recurso != null)
                    {
                        using Image logo = Image.FromStream(recurso);
                        g.DrawImage(logo, x + (ancho - 45) / 2, y, 45, 45);
                        y += 50;
                    }
                }
                Texto(EmpresaNombre, fuenteTitulo, centrado);
                Texto(EmpresaGiro, fuente, centrado);
                Texto(EmpresaDireccion, fuente, centrado);
                Texto($"Tel.: {EmpresaTelefono}   CNR: {EmpresaCnr}", fuente, centrado);
                Separador();
                Texto("FACTURA DE VENTA", fuenteNegrita, centrado);
                Fila("Factura N°:", ticketVenta.ToString("D6"), fuente);
                Fila("Fecha:", ticketFecha.ToString("dd/MM/yyyy"), fuente);
                Fila("Hora:", ticketFecha.ToString("HH:mm"), fuente);
                if (Vendedor.Length > 0) Fila("Atendió:", Vendedor, fuente);
                Texto($"Cliente: {ticketCliente}", fuente);
                if (ticketDui.Length > 0) Texto($"DUI: {ticketDui}", fuente);
                Separador();
                Fila("Cant. x Precio", "Total", fuenteNegrita);
                y += 2;
                foreach (var linea in ticketLineas)
                {
                    Texto(linea.Producto, fuente);
                    Fila($"  {linea.Cantidad} x {linea.Precio:$#,##0.00}", linea.Total.ToString("$#,##0.00"), fuente);
                    y += 3;
                }
                Separador();
                decimal subtotal = Math.Round(ticketTotal / 1.13m, 2);
                Fila($"Artículos: {ticketLineas.Sum(l => l.Cantidad)}", string.Empty, fuente);
                Fila("Subtotal sin IVA:", subtotal.ToString("$#,##0.00"), fuente);
                Fila("IVA (13%):", (ticketTotal - subtotal).ToString("$#,##0.00"), fuente);
                y += 2;
                Fila("TOTAL:", ticketTotal.ToString("$#,##0.00"), fuenteTotal);
                Separador();
                Texto("¡Gracias por su compra!", fuenteNegrita, centrado);
                Texto("Conserve este comprobante", fuente, centrado);
            };
            return documento;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ventaIdSeleccionado == 0)
            {
                MessageBox.Show("Selecciona en la lista la venta que quieres eliminar.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show($"¿Eliminar {ventaSeleccionado}? Sus productos se devolverán a la existencia.",
                Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            int id = ventaIdSeleccionado;
            MostrarOcupado(true, "Eliminando...");
            try
            {
                int filas = await EnSegundoPlano(() => Venta_BL.Eliminar(id));
                if (IsDisposed) return;
                MessageBox.Show(filas > 0 ? "Venta eliminada." : "La venta ya no existe. Se actualizará la lista.",
                    Titulo, MessageBoxButtons.OK, filas > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                await CargarVentasAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo eliminar la venta.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvVentas.Rows[e.RowIndex];
            ventaIdSeleccionado = Convert.ToInt32(fila.Cells[colIdVenta.Index].Value);
            ventaSeleccionado = $"la venta N° {ventaIdSeleccionado} de {fila.Cells[colCliente.Index].Value}";
            btnEliminar.Enabled = true;
        }

        private void dgvVentas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvVentas.ClearSelection();
        }

        private void dgvDetalle_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDetalle.ClearSelection();
        }
    }
}

using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmVentas : Form
    {
        private const string Titulo = "Ventas";
        private List<Cliente> clientes = new List<Cliente>();

        public FrmVentas()
        {
            InitializeComponent();
            dgvVentas.AutoGenerateColumns = false;
        }

        // Clientes y ventas se consultan al mismo tiempo, en segundo plano
        private async void FrmVentas_Load(object sender, EventArgs e)
        {
            MostrarOcupado(true, "Cargando ventas...");
            try
            {
                Task<List<Cliente>> tareaClientes = Task.Run(() => Cliente_BL.ObtenerTodos());
                Task<List<Venta>> tareaVentas = Task.Run(() => Venta_BL.ObtenerTodos());
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
                List<Venta> ventas = await Task.Run(() => Venta_BL.ObtenerTodos());
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

        private void MostrarOcupado(bool ocupado, string? mensaje = null)
        {
            panelDatos.Enabled = !ocupado;
            UseWaitCursor = ocupado;
            if (mensaje != null) lblEstado.Text = mensaje;
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
            return true;
        }

        private void LimpiarCampos()
        {
            dtpFecha.Value = DateTime.Today;
            VaciarSeleccion(cboCliente);
            cboEstado.SelectedIndex = 0;
            txtDescripcion.Clear();
            dgvVentas.ClearSelection();
            dtpFecha.Focus();
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

            var venta = new Venta
            {
                FechaVenta = dtpFecha.Value.Date,
                ClienteId = Convert.ToInt32(cboCliente.SelectedValue),
                Estado = cboEstado.Text,
                Descripcion = txtDescripcion.Text.Trim()
            };
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await Task.Run(() => Venta_BL.Agregar(venta));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Venta agregada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarVentasAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se agregó la venta. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo agregar la venta.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvVentas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvVentas.ClearSelection();
        }
    }
}

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

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarVentas();
            LimpiarCampos();
        }

        private void CargarClientes()
        {
            try
            {
                clientes = Cliente_BL.ObtenerTodos();
                cboCliente.DataSource = clientes
                    .Select(c => new { c.ClienteId, NombreCompleto = $"{c.Nombre} {c.Apellido}".Trim() })
                    .ToList();
                cboCliente.DisplayMember = "NombreCompleto";
                cboCliente.ValueMember = "ClienteId";
                cboCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de clientes.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVentas()
        {
            try
            {
                List<Venta> ventas = Venta_BL.ObtenerTodos();
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
            catch (Exception ex)
            {
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de ventas. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string NombreCliente(int? clienteId)
        {
            if (!clienteId.HasValue) return "Sin cliente";
            Cliente? cliente = clientes.FirstOrDefault(c => c.ClienteId == clienteId.Value);
            return cliente == null ? $"Cliente {clienteId.Value}" : $"{cliente.Nombre} {cliente.Apellido}".Trim();
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
            cboCliente.SelectedIndex = -1;
            cboEstado.SelectedIndex = 0;
            txtDescripcion.Clear();
            dgvVentas.ClearSelection();
            dtpFecha.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var venta = new Venta
                {
                    FechaVenta = dtpFecha.Value.Date,
                    ClienteId = Convert.ToInt32(cboCliente.SelectedValue),
                    Estado = cboEstado.Text,
                    Descripcion = txtDescripcion.Text.Trim()
                };
                int filas = Venta_BL.Agregar(venta);
                if (filas > 0)
                {
                    MessageBox.Show("Venta agregada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarVentas();
                }
                else
                {
                    MessageBox.Show("No se agregó la venta. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar la venta.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

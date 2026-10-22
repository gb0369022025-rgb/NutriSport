using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmPedidos : Form
    {
        private const string Titulo = "Pedidos";

        public FrmPedidos()
        {
            InitializeComponent();
            dgvPedidos.AutoGenerateColumns = false;
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            CargarPedidos();
            LimpiarCampos();
        }

        private void CargarPedidos()
        {
            try
            {
                List<Pedido> pedidos = Pedido_BL.ObtenerTodos();
                dgvPedidos.DataSource = pedidos;
                int pendientes = pedidos.Count(p => p.Estado == "Pendiente");
                string total = pedidos.Count == 1 ? "1 pedido registrado" : $"{pedidos.Count} pedidos registrados";
                lblEstado.Text = pendientes == 1 ? $"{total}, 1 pendiente" : $"{total}, {pendientes} pendientes";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de pedidos. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            nudNumeroPedido.Value = nudNumeroPedido.Minimum;
            dtpFecha.Value = DateTime.Now;
            cboEstado.SelectedIndex = 0;
            dgvPedidos.ClearSelection();
            nudNumeroPedido.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var pedido = new Pedido
                {
                    NumeroPedido = (int)nudNumeroPedido.Value,
                    Fecha = dtpFecha.Value,
                    Estado = cboEstado.Text
                };
                int filas = Pedido_BL.Agregar(pedido);
                if (filas > 0)
                {
                    MessageBox.Show("Pedido agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarPedidos();
                }
                else
                {
                    MessageBox.Show("No se agregó el pedido. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el pedido.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvPedidos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPedidos.ClearSelection();
        }
    }
}

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

        private async void FrmPedidos_Load(object sender, EventArgs e)
        {
            await CargarPedidosAsync();
            LimpiarCampos();
        }

        // Las consultas se hacen en segundo plano para que la ventana no se congele mientras responde la BD
        private async Task CargarPedidosAsync()
        {
            MostrarOcupado(true, "Cargando pedidos...");
            try
            {
                List<Pedido> pedidos = await EnSegundoPlano(() => Pedido_BL.ObtenerTodos());
                if (IsDisposed) return;
                dgvPedidos.DataSource = pedidos;
                int pendientes = pedidos.Count(p => p.Estado == "Pendiente");
                string total = pedidos.Count == 1 ? "1 pedido registrado" : $"{pedidos.Count} pedidos registrados";
                lblEstado.Text = pendientes == 1 ? $"{total}, 1 pendiente" : $"{total}, {pendientes} pendientes";
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de pedidos. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
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
            UseWaitCursor = ocupado;
            if (mensaje != null) lblEstado.Text = mensaje;
        }

        private void LimpiarCampos()
        {
            nudNumeroPedido.Value = nudNumeroPedido.Minimum;
            cboEstado.SelectedIndex = 0;
            dgvPedidos.ClearSelection();
            nudNumeroPedido.Focus();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            // La fecha y hora del pedido las asigna SpInsertPedido al guardarlo
            var pedido = new Pedido
            {
                NumeroPedido = (int)nudNumeroPedido.Value,
                Estado = cboEstado.Text
            };
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await EnSegundoPlano(() => Pedido_BL.Agregar(pedido));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Pedido agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarPedidosAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se agregó el pedido. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo agregar el pedido.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvPedidos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPedidos.ClearSelection();
        }
    }
}

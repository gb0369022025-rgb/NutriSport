using Entities;
using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class NutriSport : Form
    {
        // Un producto con esta existencia o menos se cuenta como stock crítico
        private const int StockMinimo = 10;
        private bool primeraCarga = true;

        public NutriSport()
        {
            InitializeComponent();
        }

        private async void NutriSport_Load(object sender, EventArgs e)
        {
            await CargarDashboardAsync();
        }

        // Ventas de hoy, pedidos pendientes y stock crítico calculados con los datos reales de la BD
        private async Task CargarDashboardAsync()
        {
            lblEstado.Text = "Actualizando datos...";
            try
            {
                Task<List<Venta>> tareaVentas = EnSegundoPlano(() => Venta_BL.ObtenerTodos());
                Task<List<Pedido>> tareaPedidos = EnSegundoPlano(() => Pedido_BL.ObtenerTodos());
                Task<List<Producto>> tareaProductos = EnSegundoPlano(() => Producto_BL.ObtenerTodos());
                await Task.WhenAll(tareaVentas, tareaPedidos, tareaProductos);
                if (IsDisposed) return;

                int ventasHoy = tareaVentas.Result.Count(v => v.FechaVenta.Date == DateTime.Today);
                int pedidosPendientes = tareaPedidos.Result.Count(p => p.Estado == "Pendiente");
                int stockCritico = tareaProductos.Result.Count(p => p.Existencia <= StockMinimo);

                MostrarValor(label1, lblVentasTitulo, ventasHoy == 1 ? "1 venta" : $"{ventasHoy} ventas");
                MostrarValor(label3, lblPedidosTitulo, pedidosPendientes.ToString());
                MostrarValor(label2, label4, stockCritico == 1 ? "1 Producto" : $"{stockCritico} Productos");
                lblEstado.Text = $"Datos actualizados a las {DateTime.Now:HH:mm}";
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MostrarValor(label1, lblVentasTitulo, "—");
                MostrarValor(label3, lblPedidosTitulo, "—");
                MostrarValor(label2, label4, "—");
                lblEstado.Text = "Sin conexión con la base de datos";
                if (primeraCarga)
                {
                    MessageBox.Show("No se pudieron cargar los datos del dashboard. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                        "NutriSport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                primeraCarga = false;
            }
        }

        // Muestra la cifra centrada debajo del título de su tarjeta
        private static void MostrarValor(Label valor, Label titulo, string texto)
        {
            valor.Text = texto;
            valor.Left = titulo.Left + (titulo.Width - valor.Width) / 2;
        }

        // Ejecuta la consulta en segundo plano. Si falla, el error se entrega como resultado
        // en lugar de lanzarse dentro del hilo; así Visual Studio no pausa el programa.
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

        // Abre la ventana encima del menú y, al volver, actualiza el dashboard con los datos nuevos
        private async Task AbrirFormularioAsync(Form formulario)
        {
            using (formulario)
            {
                formulario.ShowDialog(this);
            }
            await CargarDashboardAsync();
        }

        private async void btnDashboard_Click(object sender, EventArgs e)
        {
            await CargarDashboardAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmVentas());
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmClientes());
        }

        private async void btnEmpleados_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmEmpleados());
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblVentasTitulo_Click(object sender, EventArgs e)
        {

        }

        private async void btnClientes_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmClientes());
        }

        private async void btnVentas_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmVentas());
        }

        private async void btnPedidos_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmPedidos());
        }

        private async void btnCategorias_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmCategorias());
        }

        private async void btnControlInventario_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmControlInventario());
        }

        private async void btnProductos_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmProductos());
        }

        private async void btnCompras_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmCompras());
        }

        private async void btnProveedores_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmProveedores());
        }

        private async void btnUsuarios_Click(object sender, EventArgs e)
        {
            await AbrirFormularioAsync(new FrmUsuarios());
        }
    }
}

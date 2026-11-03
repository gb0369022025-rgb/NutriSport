using System.Globalization;
using Entities;
using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class NutriSport : Form
    {
        private const int StockMinimo = 10;
        private bool primeraCarga = true;

        public NutriSport()
        {
            InitializeComponent();
            CargarLogo();
        }

        private void CargarLogo()
        {
            var ensamblado = typeof(Program).Assembly;
            using (Stream? icono = ensamblado.GetManifestResourceStream("logo.ico"))
            {
                if (icono != null) Icon = new Icon(icono);
            }
            using (Stream? imagen = ensamblado.GetManifestResourceStream("logo.png"))
            {
                if (imagen != null)
                {
                    using Image original = Image.FromStream(imagen);
                    picLogo.Image = new Bitmap(original);
                }
            }
        }

        public void MostrarUsuario(Usuario usuario)
        {
            string nombre = string.IsNullOrWhiteSpace(usuario.NombreEmpleado) ? usuario.Nombre : usuario.NombreEmpleado.Trim().Split(' ')[0];
            lblBienvenida.Text = $"Bienvenido, {nombre}";
            lblUsuario.Text = string.IsNullOrWhiteSpace(usuario.NombreEmpleado)
                ? $"{usuario.Nombre} ({usuario.Tipo})"
                : $"{usuario.NombreEmpleado} ({usuario.Tipo})";
            lblUsuario.Left = panelSuperior.ClientSize.Width - lblUsuario.PreferredWidth - 20;
            Text = $"NutriSport - Sistema de Gestión - {usuario.Nombre}";
        }

        private async void NutriSport_Load(object sender, EventArgs e)
        {
            await CargarDashboardAsync();
        }

        private async Task CargarDashboardAsync()
        {
            lblEstado.Text = "Actualizando datos...";
            lblResumen.Text = "Resumen del " + DateTime.Today.ToString("dddd, d 'de' MMMM 'de' yyyy", new CultureInfo("es"));
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

        private static void MostrarValor(Label valor, Label titulo, string texto)
        {
            valor.Text = texto;
            valor.Left = titulo.Left + (titulo.Width - valor.Width) / 2;
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

        private async Task AbrirFormularioAsync(Form formulario)
        {
            using (formulario)
            {
                formulario.Icon = Icon;
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

        private void Tarjeta_Paint(object sender, PaintEventArgs e)
        {
            if (sender is not Panel tarjeta) return;
            Color acento = tarjeta == panelCardPedidos ? Color.FromArgb(46, 204, 113)
                : tarjeta == panel1 ? Color.FromArgb(46, 51, 73)
                : Color.FromArgb(192, 57, 43);
            using var borde = new Pen(Color.FromArgb(230, 235, 240));
            using var franja = new SolidBrush(acento);
            e.Graphics.DrawRectangle(borde, 0, 0, tarjeta.Width - 1, tarjeta.Height - 1);
            e.Graphics.FillRectangle(franja, 0, 0, tarjeta.Width, Math.Max(3, tarjeta.Height / 25));
        }
    }
}

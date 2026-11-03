using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Entities;
using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class NutriSport : Form
    {
        private const int StockMinimo = 10;
        private bool primeraCarga = true;
        private Dictionary<DateTime, decimal> ventasPorDia = new Dictionary<DateTime, decimal>();
        private static readonly string[] DiasSemana = { "Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb" };

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
            try
            {
                Task<Dictionary<DateTime, decimal>> tareaVentas = EnSegundoPlano(() => Venta_BL.ObtenerTotalesPorDia(DateTime.Today.AddDays(-6)));
                Task<List<Pedido>> tareaPedidos = EnSegundoPlano(() => Pedido_BL.ObtenerTodos());
                Task<List<Producto>> tareaProductos = EnSegundoPlano(() => Producto_BL.ObtenerTodos());
                await Task.WhenAll(tareaVentas, tareaPedidos, tareaProductos);
                if (IsDisposed) return;

                ventasPorDia = tareaVentas.Result;
                decimal ventasHoy = ventasPorDia.TryGetValue(DateTime.Today, out decimal totalHoy) ? totalHoy : 0;
                int pedidosPendientes = tareaPedidos.Result.Count(p => p.Estado == "Pendiente");
                int stockCritico = tareaProductos.Result.Count(p => p.Existencia <= StockMinimo);

                MostrarValor(label1, lblVentasTitulo, ventasHoy.ToString("$#,##0.00"));
                MostrarValor(label3, lblPedidosTitulo, pedidosPendientes.ToString());
                MostrarValor(label2, label4, stockCritico == 1 ? "1 Producto" : $"{stockCritico} Productos");
                lblEstado.Text = $"Datos actualizados a las {DateTime.Now:HH:mm}";
                panelGrafico.Invalidate();
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MostrarValor(label1, lblVentasTitulo, "—");
                MostrarValor(label3, lblPedidosTitulo, "—");
                MostrarValor(label2, label4, "—");
                ventasPorDia = new Dictionary<DateTime, decimal>();
                panelGrafico.Invalidate();
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

        private void panelGrafico_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Rectangle area = panelGrafico.ClientRectangle;

            using var borde = new Pen(Color.FromArgb(230, 235, 240));
            using var fuente = new Font("Segoe UI", 9F);
            using var fuenteTitulo = new Font("Segoe UI", 10F, FontStyle.Bold);
            using var oscuro = new SolidBrush(Color.FromArgb(30, 30, 30));
            using var gris = new SolidBrush(Color.Gray);
            using var barra = new SolidBrush(Color.FromArgb(46, 51, 73));
            using var barraHoy = new SolidBrush(Color.FromArgb(46, 204, 113));
            using var centrado = new StringFormat { Alignment = StringAlignment.Center };
            using var derecha = new StringFormat { Alignment = StringAlignment.Far };
            g.DrawRectangle(borde, 0, 0, area.Width - 1, area.Height - 1);

            float margen = fuente.GetHeight(g);
            float altoTexto = fuente.GetHeight(g);
            decimal totalSemana = ventasPorDia.Values.Sum();
            g.DrawString("Ventas de los últimos 7 días", fuenteTitulo, oscuro, margen, margen * 0.6f);
            g.DrawString($"Total: {totalSemana:$#,##0.00}", fuente, gris, new RectangleF(margen, margen * 0.7f, area.Width - margen * 2, altoTexto), derecha);

            float arriba = margen * 0.6f + fuenteTitulo.GetHeight(g) + altoTexto + margen * 0.4f;
            float base_ = area.Height - margen * 0.6f - altoTexto - margen * 0.3f;
            float ancho = (area.Width - margen * 2) / 7f;
            decimal maximo = ventasPorDia.Values.DefaultIfEmpty(0).Max();
            g.DrawLine(borde, margen, base_, area.Width - margen, base_);

            for (int i = 0; i < 7; i++)
            {
                DateTime dia = DateTime.Today.AddDays(i - 6);
                decimal total = ventasPorDia.TryGetValue(dia, out decimal valor) ? valor : 0;
                float x = margen + ancho * i;
                float alto = maximo > 0 ? (float)(total / maximo) * (base_ - arriba) : 0;
                float anchoBarra = ancho * 0.5f;
                float xBarra = x + (ancho - anchoBarra) / 2;
                if (alto > 0) g.FillRectangle(i == 6 ? barraHoy : barra, xBarra, base_ - alto, anchoBarra, alto);
                if (total > 0) g.DrawString(total.ToString("$#,##0"), fuente, oscuro, new RectangleF(x, base_ - alto - altoTexto - 2, ancho, altoTexto), centrado);
                string etiqueta = i == 6 ? "Hoy" : $"{DiasSemana[(int)dia.DayOfWeek]} {dia.Day}";
                g.DrawString(etiqueta, fuente, i == 6 ? oscuro : gris, new RectangleF(x, base_ + margen * 0.3f, ancho, altoTexto), centrado);
            }

            if (maximo == 0)
            {
                g.DrawString("Sin ventas registradas en los últimos 7 días", fuente, gris,
                    new RectangleF(0, (arriba + base_) / 2 - altoTexto / 2, area.Width, altoTexto), centrado);
            }
        }
    }
}

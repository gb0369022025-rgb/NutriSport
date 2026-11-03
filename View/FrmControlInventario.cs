using Entities;
using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmControlInventario : Form
    {
        private const string Titulo = "Control de inventario";
        private List<Categoria> categorias = new List<Categoria>();
        private List<Producto> productos = new List<Producto>();

        public FrmControlInventario()
        {
            InitializeComponent();
            dgvCategorias.AutoGenerateColumns = false;
            dgvProductos.AutoGenerateColumns = false;
        }

        private async void FrmControlInventario_Load(object sender, EventArgs e)
        {
            MostrarOcupado(true, "Cargando inventario...");
            try
            {
                Task<List<Categoria>> tareaCategorias = EnSegundoPlano(() => Categoria_BL.ObtenerTodos());
                Task<List<Producto>> tareaProductos = EnSegundoPlano(() => Producto_BL.ObtenerTodos());
                await Task.WhenAll(tareaCategorias, tareaProductos);
                if (IsDisposed) return;

                categorias = tareaCategorias.Result;
                productos = tareaProductos.Result;
                MostrarCategorias();
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar el inventario. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private void MostrarCategorias()
        {
            dgvCategorias.DataSource = categorias
                .Select(c => new
                {
                    c.CategoriaId,
                    Categoria = c.NombreCategoria,
                    Productos = productos.Count(p => p.CategoriaId == c.CategoriaId),
                    Existencia = productos.Where(p => p.CategoriaId == c.CategoriaId).Sum(p => p.Existencia)
                })
                .ToList();
            dgvProductos.DataSource = null;
            lblProductos.Text = "Selecciona una categoría para ver sus productos";

            int unidades = productos.Sum(p => p.Existencia);
            string totalCategorias = categorias.Count == 1 ? "1 categoría" : $"{categorias.Count} categorías";
            string totalProductos = productos.Count == 1 ? "1 producto" : $"{productos.Count} productos";
            lblEstado.Text = $"{totalCategorias}, {totalProductos}, {unidades} unidades en inventario";
        }

        private void MostrarProductos(int categoriaId, string categoria)
        {
            List<Producto> lista = productos
                .Where(p => p.CategoriaId == categoriaId)
                .OrderBy(p => p.NombreProducto)
                .ToList();
            dgvProductos.DataSource = lista;
            lblProductos.Text = $"Productos de {categoria}";

            string cantidad = lista.Count == 1 ? "1 producto" : $"{lista.Count} productos";
            lblEstado.Text = $"{categoria}: {cantidad}, {lista.Sum(p => p.Existencia)} unidades en existencia";
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
            UseWaitCursor = ocupado;
            if (mensaje != null) lblEstado.Text = mensaje;
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0) return;
            MostrarProductos(dgvCategorias.SelectedRows[0]);
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            MostrarProductos(dgvCategorias.Rows[e.RowIndex]);
        }

        private void MostrarProductos(DataGridViewRow fila)
        {
            MostrarProductos(Convert.ToInt32(fila.Cells[colCategoriaId.Index].Value), Convert.ToString(fila.Cells[colCategoria.Index].Value) ?? string.Empty);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCategorias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCategorias.ClearSelection();
        }

        private void dgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProductos.ClearSelection();
        }
    }
}

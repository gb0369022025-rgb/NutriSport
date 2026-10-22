using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmCategorias : Form
    {
        private const string Titulo = "Categorías";
        private int categoriaIdSeleccionada = 0;

        public FrmCategorias()
        {
            InitializeComponent();
            dgvCategorias.AutoGenerateColumns = false;
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            LimpiarCampos();
        }

        private void CargarCategorias()
        {
            try
            {
                List<Categoria> categorias = Categoria_BL.ObtenerTodos();
                dgvCategorias.DataSource = categorias;
                lblEstado.Text = categorias.Count == 1 ? "1 categoría registrada" : $"{categorias.Count} categorías registradas";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de categorías. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
            {
                MessageBox.Show("Escribe el nombre de la categoría.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCategoria.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            categoriaIdSeleccionada = 0;
            txtNombreCategoria.Clear();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvCategorias.ClearSelection();
            txtNombreCategoria.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var categoria = new Categoria { NombreCategoria = txtNombreCategoria.Text.Trim() };
                int filas = Categoria_BL.Agregar(categoria);
                if (filas > 0)
                {
                    MessageBox.Show("Categoría agregada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarCategorias();
                }
                else
                {
                    MessageBox.Show("Ya existe una categoría con ese nombre.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar la categoría.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (categoriaIdSeleccionada == 0)
            {
                MessageBox.Show("Selecciona en la lista la categoría que quieres modificar.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCampos()) return;

            try
            {
                var categoria = new Categoria
                {
                    CategoriaId = categoriaIdSeleccionada,
                    NombreCategoria = txtNombreCategoria.Text.Trim()
                };
                int filas = Categoria_BL.Modificar(categoria);
                if (filas > 0)
                {
                    MessageBox.Show("Categoría modificada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarCategorias();
                }
                else
                {
                    MessageBox.Show("Ya existe otra categoría con ese nombre.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar la categoría.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (categoriaIdSeleccionada == 0)
            {
                MessageBox.Show("Selecciona en la lista la categoría que quieres eliminar.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show($"¿Eliminar la categoría \"{txtNombreCategoria.Text.Trim()}\"?",
                Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            try
            {
                int filas = Categoria_BL.Eliminar(categoriaIdSeleccionada);
                if (filas > 0)
                {
                    MessageBox.Show("Categoría eliminada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarCategorias();
                }
                else
                {
                    MessageBox.Show("La categoría ya no existe. Se actualizará la lista.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarCampos();
                    CargarCategorias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la categoría.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCategorias.Rows[e.RowIndex].DataBoundItem is not Categoria categoria) return;

            categoriaIdSeleccionada = categoria.CategoriaId;
            txtNombreCategoria.Text = categoria.NombreCategoria;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void dgvCategorias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCategorias.ClearSelection();
        }
    }
}

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

        private async void FrmCategorias_Load(object sender, EventArgs e)
        {
            await CargarCategoriasAsync();
            LimpiarCampos();
        }

        // Las consultas se hacen en segundo plano para que la ventana no se congele mientras responde la BD
        private async Task CargarCategoriasAsync()
        {
            MostrarOcupado(true, "Cargando categorías...");
            try
            {
                List<Categoria> categorias = await Task.Run(() => Categoria_BL.ObtenerTodos());
                if (IsDisposed) return;
                dgvCategorias.DataSource = categorias;
                lblEstado.Text = categorias.Count == 1 ? "1 categoría registrada" : $"{categorias.Count} categorías registradas";
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de categorías. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private void MostrarOcupado(bool ocupado, string? mensaje = null)
        {
            panelDatos.Enabled = !ocupado;
            UseWaitCursor = ocupado;
            if (mensaje != null) lblEstado.Text = mensaje;
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

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var categoria = new Categoria { NombreCategoria = txtNombreCategoria.Text.Trim() };
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await Task.Run(() => Categoria_BL.Agregar(categoria));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Categoría agregada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarCategoriasAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ya existe una categoría con ese nombre.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo agregar la categoría.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (categoriaIdSeleccionada == 0)
            {
                MessageBox.Show("Selecciona en la lista la categoría que quieres modificar.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCampos()) return;

            var categoria = new Categoria
            {
                CategoriaId = categoriaIdSeleccionada,
                NombreCategoria = txtNombreCategoria.Text.Trim()
            };
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await Task.Run(() => Categoria_BL.Modificar(categoria));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Categoría modificada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarCategoriasAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ya existe otra categoría con ese nombre.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo modificar la categoría.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (categoriaIdSeleccionada == 0)
            {
                MessageBox.Show("Selecciona en la lista la categoría que quieres eliminar.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show($"¿Eliminar la categoría \"{txtNombreCategoria.Text.Trim()}\"?",
                Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            int id = categoriaIdSeleccionada;
            MostrarOcupado(true, "Eliminando...");
            try
            {
                int filas = await Task.Run(() => Categoria_BL.Eliminar(id));
                if (IsDisposed) return;
                MessageBox.Show(filas > 0 ? "Categoría eliminada." : "La categoría ya no existe. Se actualizará la lista.",
                    Titulo, MessageBoxButtons.OK, filas > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                await CargarCategoriasAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo eliminar la categoría.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

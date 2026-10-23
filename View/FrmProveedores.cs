using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmProveedores : Form
    {
        private const string Titulo = "Proveedores";

        public FrmProveedores()
        {
            InitializeComponent();
            dgvProveedores.AutoGenerateColumns = false;
        }

        private async void FrmProveedores_Load(object sender, EventArgs e)
        {
            await CargarProveedoresAsync();
            LimpiarCampos();
        }

        // Las consultas se hacen en segundo plano para que la ventana no se congele mientras responde la BD
        private async Task CargarProveedoresAsync()
        {
            MostrarOcupado(true, "Cargando proveedores...");
            try
            {
                List<Proveedor> proveedores = await EnSegundoPlano(() => Proveedor_BL.ObtenerTodos());
                if (IsDisposed) return;
                dgvProveedores.DataSource = proveedores;
                lblEstado.Text = proveedores.Count == 1 ? "1 proveedor registrado" : $"{proveedores.Count} proveedores registrados";
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de proveedores. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
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

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Escribe el nombre del proveedor.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Escribe la dirección del proveedor.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            dgvProveedores.ClearSelection();
            txtNombre.Focus();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var proveedor = new Proveedor
            {
                Nombre = txtNombre.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim()
            };
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await EnSegundoPlano(() => Proveedor_BL.Agregar(proveedor));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Proveedor agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarProveedoresAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ya existe un proveedor con ese nombre.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo agregar el proveedor.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvProveedores_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProveedores.ClearSelection();
        }
    }
}

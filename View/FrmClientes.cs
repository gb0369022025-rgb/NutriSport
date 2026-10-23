using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmClientes : Form
    {
        private const string Titulo = "Clientes";
        private int clienteIdSeleccionado = 0;

        public FrmClientes()
        {
            InitializeComponent();
            dgvClientes.AutoGenerateColumns = false;
        }

        private async void FrmClientes_Load(object sender, EventArgs e)
        {
            await CargarClientesAsync();
            LimpiarCampos();
        }

        // Las consultas se hacen en segundo plano para que la ventana no se congele mientras responde la BD
        private async Task CargarClientesAsync()
        {
            MostrarOcupado(true, "Cargando clientes...");
            try
            {
                List<Cliente> clientes = await Task.Run(() => Cliente_BL.ObtenerTodos());
                if (IsDisposed) return;
                dgvClientes.DataSource = clientes;
                lblEstado.Text = clientes.Count == 1 ? "1 cliente registrado" : $"{clientes.Count} clientes registrados";
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de clientes. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Escribe el nombre del cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private Cliente LeerCampos()
        {
            return new Cliente
            {
                ClienteId = clienteIdSeleccionado,
                Nombre = TextoONulo(txtNombre.Text),
                Apellido = TextoONulo(txtApellido.Text),
                Telefono = TextoONulo(txtTelefono.Text),
                Email = TextoONulo(txtEmail.Text),
                DUI = TextoONulo(txtDUI.Text)
            };
        }

        private static string? TextoONulo(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();
        }

        private void LimpiarCampos()
        {
            clienteIdSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtDUI.Clear();
            txtEmail.Clear();
            btnModificar.Enabled = false;
            dgvClientes.ClearSelection();
            txtNombre.Focus();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Cliente cliente = LeerCampos();
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await Task.Run(() => Cliente_BL.Agregar(cliente));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Cliente agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarClientesAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ya existe un cliente registrado con ese DUI.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo agregar el cliente.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (clienteIdSeleccionado == 0)
            {
                MessageBox.Show("Selecciona en la lista el cliente que quieres modificar.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCampos()) return;

            Cliente cliente = LeerCampos();
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await Task.Run(() => Cliente_BL.Modificar(cliente));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Cliente modificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarClientesAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El DUI escrito ya pertenece a otro cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo modificar el cliente.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvClientes.Rows[e.RowIndex].DataBoundItem is not Cliente cliente) return;

            clienteIdSeleccionado = cliente.ClienteId;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono;
            txtDUI.Text = cliente.DUI;
            txtEmail.Text = cliente.Email;
            btnModificar.Enabled = true;
        }

        private void dgvClientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvClientes.ClearSelection();
        }
    }
}

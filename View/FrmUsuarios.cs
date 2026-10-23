using Entities;
using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmUsuarios : Form
    {
        private const string Titulo = "Usuarios";

        public FrmUsuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }

        // Empleados y usuarios se consultan al mismo tiempo, en segundo plano
        private async void FrmUsuarios_Load(object sender, EventArgs e)
        {
            MostrarOcupado(true, "Cargando usuarios...");
            try
            {
                Task<List<Empleado>> tareaEmpleados = Task.Run(() => Empleado_BL.ObtenerTodos());
                Task<List<Usuario>> tareaUsuarios = Task.Run(() => Usuario_BL.ObtenerTodos());
                await Task.WhenAll(tareaEmpleados, tareaUsuarios);
                if (IsDisposed) return;

                cboEmpleado.Items.Clear();
                foreach (Empleado empleado in tareaEmpleados.Result)
                {
                    cboEmpleado.Items.Add($"{empleado.Nombre} {empleado.Apellido}".Trim());
                }
                MostrarUsuarios(tareaUsuarios.Result);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudieron cargar los usuarios y empleados. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
            if (!IsDisposed) LimpiarCampos();
        }

        private async Task CargarUsuariosAsync()
        {
            MostrarOcupado(true, "Cargando usuarios...");
            try
            {
                List<Usuario> usuarios = await Task.Run(() => Usuario_BL.ObtenerTodos());
                if (IsDisposed) return;
                MostrarUsuarios(usuarios);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de usuarios. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private void MostrarUsuarios(List<Usuario> usuarios)
        {
            dgvUsuarios.DataSource = usuarios;
            lblEstado.Text = usuarios.Count == 1 ? "1 usuario registrado" : $"{usuarios.Count} usuarios registrados";
        }

        private void MostrarOcupado(bool ocupado, string? mensaje = null)
        {
            panelDatos.Enabled = !ocupado;
            UseWaitCursor = ocupado;
            if (mensaje != null) lblEstado.Text = mensaje;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("Escribe el nombre de usuario.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cboEmpleado.Text))
            {
                MessageBox.Show("Selecciona o escribe el nombre del empleado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEmpleado.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Escribe la clave del usuario.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return false;
            }
            if (cboTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona el tipo de usuario.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipo.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtNombreUsuario.Clear();
            cboEmpleado.SelectedIndex = -1;
            cboEmpleado.Text = string.Empty;
            txtClave.Clear();
            cboTipo.SelectedIndex = -1;
            cboEstado.SelectedIndex = 0;
            dgvUsuarios.ClearSelection();
            txtNombreUsuario.Focus();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var usuario = new Usuario
            {
                Nombre = txtNombreUsuario.Text.Trim(),
                NombreEmpleado = cboEmpleado.Text.Trim(),
                Clave = txtClave.Text,
                Tipo = cboTipo.Text,
                Estado = cboEstado.Text
            };
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await Task.Run(() => Usuario_BL.Agregar(usuario));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Usuario agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarUsuariosAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ese nombre de usuario ya está ocupado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo agregar el usuario.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUsuarios.ClearSelection();
        }
    }
}

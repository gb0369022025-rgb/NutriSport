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

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarUsuarios();
            LimpiarCampos();
        }

        private void CargarEmpleados()
        {
            try
            {
                List<Empleado> empleados = Empleado_BL.ObtenerTodos();
                cboEmpleado.Items.Clear();
                foreach (Empleado empleado in empleados)
                {
                    cboEmpleado.Items.Add($"{empleado.Nombre} {empleado.Apellido}".Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de empleados. Puedes escribir el nombre del empleado a mano.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                List<Usuario> usuarios = Usuario_BL.ObtenerTodos();
                dgvUsuarios.DataSource = usuarios;
                lblEstado.Text = usuarios.Count == 1 ? "1 usuario registrado" : $"{usuarios.Count} usuarios registrados";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de usuarios. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var usuario = new Usuario
                {
                    Nombre = txtNombreUsuario.Text.Trim(),
                    NombreEmpleado = cboEmpleado.Text.Trim(),
                    Clave = txtClave.Text,
                    Tipo = cboTipo.Text,
                    Estado = cboEstado.Text
                };
                int filas = Usuario_BL.Agregar(usuario);
                if (filas > 0)
                {
                    MessageBox.Show("Usuario agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se agregó el usuario. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el usuario.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

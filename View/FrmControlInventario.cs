using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmControlInventario : Form
    {
        private const string Titulo = "Control de inventario";
        private List<Usuario> usuarios = new List<Usuario>();

        public FrmControlInventario()
        {
            InitializeComponent();
            dgvControlInventario.AutoGenerateColumns = false;
        }

        private void FrmControlInventario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarControles();
            LimpiarCampos();
        }

        private void CargarUsuarios()
        {
            try
            {
                usuarios = Usuario_BL.ObtenerTodos();
                cboUsuario.DataSource = usuarios;
                cboUsuario.DisplayMember = nameof(Usuario.Nombre);
                cboUsuario.ValueMember = nameof(Usuario.UsuarioId);
                cboUsuario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de usuarios.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarControles()
        {
            try
            {
                List<Ctrl_Inventario> controles = Ctrl_Inventario_BL.ObtenerTodos();
                dgvControlInventario.DataSource = controles
                    .Select(c => new
                    {
                        c.ControlInvId,
                        c.FechaHora,
                        Usuario = usuarios.FirstOrDefault(u => u.UsuarioId == c.NombreUsuario)?.Nombre ?? $"Usuario {c.NombreUsuario}",
                        c.CantProducto,
                        c.Observacion,
                        c.Estado
                    })
                    .ToList();
                lblEstado.Text = controles.Count == 1 ? "1 control registrado" : $"{controles.Count} controles registrados";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar el historial de control de inventario. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (cboUsuario.SelectedValue == null)
            {
                MessageBox.Show("Selecciona el usuario responsable del control.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboUsuario.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            cboUsuario.SelectedIndex = -1;
            dtpFechaHora.Value = DateTime.Now;
            nudCantProducto.Value = 0;
            cboEstado.SelectedIndex = 0;
            txtObservacion.Clear();
            dgvControlInventario.ClearSelection();
            cboUsuario.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var control = new Ctrl_Inventario
                {
                    NombreUsuario = Convert.ToInt32(cboUsuario.SelectedValue),
                    FechaHora = dtpFechaHora.Value,
                    CantProducto = (int)nudCantProducto.Value,
                    Observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text.Trim(),
                    Estado = cboEstado.Text
                };
                int filas = Ctrl_Inventario_BL.Agregar(control);
                if (filas > 0)
                {
                    MessageBox.Show("Control de inventario agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarControles();
                }
                else
                {
                    MessageBox.Show("No se agregó el control de inventario. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el control de inventario.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvControlInventario_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvControlInventario.ClearSelection();
        }
    }
}

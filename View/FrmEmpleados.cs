using Entities;
using NutriSport.BL;

namespace View
{
    public partial class FrmEmpleados : Form
    {
        private const string Titulo = "Empleados";

        public FrmEmpleados()
        {
            InitializeComponent();
            dgvEmpleados.AutoGenerateColumns = false;
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            LimpiarCampos();
        }

        private void CargarEmpleados()
        {
            try
            {
                List<Empleado> empleados = Empleado_BL.ObtenerTodos();
                dgvEmpleados.DataSource = empleados;
                lblEstado.Text = empleados.Count == 1 ? "1 empleado registrado" : $"{empleados.Count} empleados registrados";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de empleados. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            (TextBox campo, string mensaje)[] obligatorios =
            {
                (txtNombre, "Escribe el nombre del empleado."),
                (txtApellido, "Escribe el apellido del empleado."),
                (txtTelefono, "Escribe el teléfono del empleado."),
                (txtDUI, "Escribe el DUI del empleado."),
                (txtEmail, "Escribe el correo electrónico del empleado."),
                (txtDireccion, "Escribe la dirección del empleado.")
            };

            foreach (var (campo, mensaje) in obligatorios)
            {
                if (string.IsNullOrWhiteSpace(campo.Text))
                {
                    MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    campo.Focus();
                    return false;
                }
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtDUI.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            nudRolId.Value = nudRolId.Minimum;
            nudCargoId.Value = nudCargoId.Minimum;
            dgvEmpleados.ClearSelection();
            txtNombre.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var empleado = new Empleado
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    DUI = txtDUI.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    RolId = (short)nudRolId.Value,
                    CargoId = (short)nudCargoId.Value
                };
                int filas = Empleado_BL.Agregar(empleado);
                if (filas > 0)
                {
                    MessageBox.Show("Empleado agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarEmpleados();
                }
                else
                {
                    MessageBox.Show("No se agregó el empleado. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el empleado. Revisa que el DUI no esté repetido y que los códigos de rol y cargo existan.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvEmpleados_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvEmpleados.ClearSelection();
        }
    }
}

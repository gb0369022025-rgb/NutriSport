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

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            LimpiarCampos();
        }

        private void CargarProveedores()
        {
            try
            {
                List<Proveedor> proveedores = Proveedor_BL.ObtenerTodos();
                dgvProveedores.DataSource = proveedores;
                lblEstado.Text = proveedores.Count == 1 ? "1 proveedor registrado" : $"{proveedores.Count} proveedores registrados";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de proveedores. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var proveedor = new Proveedor
                {
                    Nombre = txtNombre.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim()
                };
                int filas = Proveedor_BL.Agregar(proveedor);
                if (filas > 0)
                {
                    MessageBox.Show("Proveedor agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarProveedores();
                }
                else
                {
                    MessageBox.Show("No se agregó el proveedor. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el proveedor.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

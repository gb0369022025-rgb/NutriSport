using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmCompras : Form
    {
        private const string Titulo = "Compras";
        private List<Proveedor> proveedores = new List<Proveedor>();
        private List<Usuario> usuarios = new List<Usuario>();

        public FrmCompras()
        {
            InitializeComponent();
            dgvCompras.AutoGenerateColumns = false;
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarUsuarios();
            CargarCompras();
            LimpiarCampos();
        }

        private void CargarProveedores()
        {
            try
            {
                proveedores = Proveedor_BL.ObtenerTodos();
                cboProveedor.DataSource = proveedores;
                cboProveedor.DisplayMember = nameof(Proveedor.Nombre);
                cboProveedor.ValueMember = nameof(Proveedor.ProveedorId);
                cboProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de proveedores.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void CargarCompras()
        {
            try
            {
                List<Compra> compras = Compra_BL.ObtenerTodos();
                dgvCompras.DataSource = compras
                    .Select(c => new
                    {
                        c.CompraId,
                        c.FechaHora,
                        Proveedor = proveedores.FirstOrDefault(p => p.ProveedorId == c.NombreProveedor)?.Nombre ?? $"Proveedor {c.NombreProveedor}",
                        c.NumFact,
                        Usuario = usuarios.FirstOrDefault(u => u.UsuarioId == c.NombreUsuario)?.Nombre ?? $"Usuario {c.NombreUsuario}",
                        c.SubTotal,
                        c.TotalPagar,
                        c.Estado
                    })
                    .ToList();
                lblEstado.Text = compras.Count == 1 ? "1 compra registrada" : $"{compras.Count} compras registradas";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de compras. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (cboProveedor.SelectedValue == null)
            {
                MessageBox.Show("Selecciona el proveedor de la compra.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProveedor.Focus();
                return false;
            }
            if (cboUsuario.SelectedValue == null)
            {
                MessageBox.Show("Selecciona el usuario que registra la compra.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboUsuario.Focus();
                return false;
            }
            if (nudSubTotal.Value <= 0)
            {
                MessageBox.Show("El subtotal debe ser mayor que $0.00.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudSubTotal.Focus();
                return false;
            }
            if (nudTotalPagar.Value <= 0)
            {
                MessageBox.Show("El total a pagar debe ser mayor que $0.00.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudTotalPagar.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            dtpFechaHora.Value = DateTime.Now;
            cboProveedor.SelectedIndex = -1;
            nudNumFact.Value = nudNumFact.Minimum;
            cboEstado.SelectedIndex = 0;
            cboUsuario.SelectedIndex = -1;
            nudSubTotal.Value = 0;
            nudTotalPagar.Value = 0;
            dgvCompras.ClearSelection();
            dtpFechaHora.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var compra = new Compra
                {
                    FechaHora = dtpFechaHora.Value,
                    NombreProveedor = Convert.ToInt16(cboProveedor.SelectedValue),
                    NumFact = (int)nudNumFact.Value,
                    NombreUsuario = Convert.ToInt32(cboUsuario.SelectedValue),
                    SubTotal = nudSubTotal.Value,
                    TotalPagar = nudTotalPagar.Value,
                    Estado = cboEstado.Text
                };
                int filas = Compra_BL.Agregar(compra);
                if (filas > 0)
                {
                    MessageBox.Show("Compra agregada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarCompras();
                }
                else
                {
                    MessageBox.Show("No se agregó la compra. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar la compra.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvCompras_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCompras.ClearSelection();
        }
    }
}

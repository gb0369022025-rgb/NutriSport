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

        // Proveedores, usuarios y compras se consultan al mismo tiempo, en segundo plano
        private async void FrmCompras_Load(object sender, EventArgs e)
        {
            MostrarOcupado(true, "Cargando compras...");
            try
            {
                Task<List<Proveedor>> tareaProveedores = EnSegundoPlano(() => Proveedor_BL.ObtenerTodos());
                Task<List<Usuario>> tareaUsuarios = EnSegundoPlano(() => Usuario_BL.ObtenerTodos());
                Task<List<Compra>> tareaCompras = EnSegundoPlano(() => Compra_BL.ObtenerTodos());
                await Task.WhenAll(tareaProveedores, tareaUsuarios, tareaCompras);
                if (IsDisposed) return;

                proveedores = tareaProveedores.Result;
                cboProveedor.DataSource = proveedores;
                cboProveedor.DisplayMember = nameof(Proveedor.Nombre);
                cboProveedor.ValueMember = nameof(Proveedor.ProveedorId);

                usuarios = tareaUsuarios.Result;
                cboUsuario.DataSource = usuarios;
                cboUsuario.DisplayMember = nameof(Usuario.Nombre);
                cboUsuario.ValueMember = nameof(Usuario.UsuarioId);

                MostrarCompras(tareaCompras.Result);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudieron cargar las compras, proveedores y usuarios. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
            if (!IsDisposed) LimpiarCampos();
        }

        private async Task CargarComprasAsync()
        {
            MostrarOcupado(true, "Cargando compras...");
            try
            {
                List<Compra> compras = await EnSegundoPlano(() => Compra_BL.ObtenerTodos());
                if (IsDisposed) return;
                MostrarCompras(compras);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar la lista de compras. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private void MostrarCompras(List<Compra> compras)
        {
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
            VaciarSeleccion(cboProveedor);
            nudNumFact.Value = nudNumFact.Minimum;
            cboEstado.SelectedIndex = 0;
            VaciarSeleccion(cboUsuario);
            nudSubTotal.Value = 0;
            nudTotalPagar.Value = 0;
            dgvCompras.ClearSelection();
            dtpFechaHora.Focus();
        }

        // En un ComboBox enlazado a datos, WinForms solo lo deja vacío si se asigna -1 dos veces
        private static void VaciarSeleccion(ComboBox combo)
        {
            combo.SelectedIndex = -1;
            combo.SelectedIndex = -1;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

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
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await EnSegundoPlano(() => Compra_BL.Agregar(compra));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Compra agregada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarComprasAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se agregó la compra. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo agregar la compra.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvCompras_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCompras.ClearSelection();
        }
    }
}

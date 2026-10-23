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

        // Usuarios y controles se consultan al mismo tiempo, en segundo plano
        private async void FrmControlInventario_Load(object sender, EventArgs e)
        {
            MostrarOcupado(true, "Cargando controles...");
            try
            {
                Task<List<Usuario>> tareaUsuarios = EnSegundoPlano(() => Usuario_BL.ObtenerTodos());
                Task<List<Ctrl_Inventario>> tareaControles = EnSegundoPlano(() => Ctrl_Inventario_BL.ObtenerTodos());
                await Task.WhenAll(tareaUsuarios, tareaControles);
                if (IsDisposed) return;

                usuarios = tareaUsuarios.Result;
                cboUsuario.DataSource = usuarios;
                cboUsuario.DisplayMember = nameof(Usuario.Nombre);
                cboUsuario.ValueMember = nameof(Usuario.UsuarioId);
                MostrarControles(tareaControles.Result);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar el historial de control de inventario y los usuarios. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
            if (!IsDisposed) LimpiarCampos();
        }

        private async Task CargarControlesAsync()
        {
            MostrarOcupado(true, "Cargando controles...");
            try
            {
                List<Ctrl_Inventario> controles = await EnSegundoPlano(() => Ctrl_Inventario_BL.ObtenerTodos());
                if (IsDisposed) return;
                MostrarControles(controles);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblEstado.Text = "Sin conexión con la base de datos";
                MessageBox.Show("No se pudo cargar el historial de control de inventario. Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }
        }

        private void MostrarControles(List<Ctrl_Inventario> controles)
        {
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
            VaciarSeleccion(cboUsuario);
            dtpFechaHora.Value = DateTime.Now;
            nudCantProducto.Value = 0;
            cboEstado.SelectedIndex = 0;
            txtObservacion.Clear();
            dgvControlInventario.ClearSelection();
            cboUsuario.Focus();
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

            var control = new Ctrl_Inventario
            {
                NombreUsuario = Convert.ToInt32(cboUsuario.SelectedValue),
                FechaHora = dtpFechaHora.Value,
                CantProducto = (int)nudCantProducto.Value,
                Observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text.Trim(),
                Estado = cboEstado.Text
            };
            MostrarOcupado(true, "Guardando...");
            try
            {
                int filas = await EnSegundoPlano(() => Ctrl_Inventario_BL.Agregar(control));
                if (IsDisposed) return;
                if (filas > 0)
                {
                    MessageBox.Show("Control de inventario agregado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarControlesAsync();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se agregó el control de inventario. Intenta de nuevo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                MessageBox.Show("No se pudo agregar el control de inventario.\n\nDetalle: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvControlInventario_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvControlInventario.ClearSelection();
        }
    }
}

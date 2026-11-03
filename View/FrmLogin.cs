using NutriSport.BL;
using NutriSport.Entities;

namespace View
{
    public partial class FrmLogin : Form
    {
        public Usuario? UsuarioActual { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            CargarLogo();
        }

        private void CargarLogo()
        {
            var ensamblado = typeof(Program).Assembly;
            using (Stream? icono = ensamblado.GetManifestResourceStream("logo.ico"))
            {
                if (icono != null) Icon = new Icon(icono);
            }
            using (Stream? imagen = ensamblado.GetManifestResourceStream("logo.png"))
            {
                if (imagen != null)
                {
                    using Image original = Image.FromStream(imagen);
                    picLogo.Image = new Bitmap(original);
                }
            }
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text.Trim();
            string clave = txtClave.Text;
            if (nombre.Length == 0)
            {
                lblMensaje.Text = "Escribe tu usuario.";
                txtUsuario.Focus();
                return;
            }
            if (clave.Length == 0)
            {
                lblMensaje.Text = "Escribe tu contraseña.";
                txtClave.Focus();
                return;
            }

            Usuario? usuario;
            MostrarOcupado(true);
            try
            {
                usuario = await EnSegundoPlano(() => Usuario_BL.IniciarSesion(nombre, clave));
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                lblMensaje.Text = "No se pudo conectar con la base de datos.";
                MessageBox.Show("Revisa la conexión con la base de datos.\n\nDetalle: " + ex.Message,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (!IsDisposed) MostrarOcupado(false);
            }

            if (IsDisposed) return;
            if (usuario == null)
            {
                txtClave.Clear();
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
                txtClave.Focus();
                return;
            }

            UsuarioActual = usuario;
            DialogResult = DialogResult.OK;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtCampo_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
        }

        private void MostrarOcupado(bool ocupado)
        {
            panelAcceso.Enabled = !ocupado;
            UseWaitCursor = ocupado;
            btnIngresar.Text = ocupado ? "Verificando..." : "Iniciar sesión";
        }

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
    }
}

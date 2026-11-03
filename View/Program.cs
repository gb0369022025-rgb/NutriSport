using NutriSport.Entities;

namespace View
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Usuario? usuario;
            using (var login = new FrmLogin())
            {
                if (login.ShowDialog() != DialogResult.OK) return;
                usuario = login.UsuarioActual;
            }
            if (usuario == null) return;

            var principal = new NutriSport();
            principal.MostrarUsuario(usuario);
            Application.Run(principal);
        }
    }
}
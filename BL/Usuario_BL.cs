using System.Collections.Generic;
using NutriSport.Entities;
using NutriSport.DAL;

namespace NutriSport.BL
{
    public class Usuario_BL
    {
        public static List<Usuario> ObtenerTodos()
        {
            return Usuario_DAL.ObtenerTodos();
        }

        public static int Agregar(Usuario entidad)
        {
            return Usuario_DAL.Agregar(entidad);
        }

        public static int Eliminar(int id)
        {
            return Usuario_DAL.Eliminar(id);
        }

        public static Usuario? IniciarSesion(string nombre, string clave)
        {
            return Usuario_DAL.IniciarSesion(nombre, clave);
        }
    }
}

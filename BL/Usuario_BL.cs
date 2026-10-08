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
    }
}

using System.Collections.Generic;
using NutriSport.Entities;
using NutriSport.DAL;

namespace NutriSport.BL
{
    public class Cliente_BL
    {
        public static List<Cliente> ObtenerTodos()
        {
            return Cliente_DAL.ObtenerTodos();
        }

        public static int Agregar(Cliente entidad)
        {
            return Cliente_DAL.Agregar(entidad);
        }

        public static int Modificar(Cliente entidad)
        {
            return Cliente_DAL.Modificar(entidad);
        }
    }
}

using System.Collections.Generic;
using NutriSport.Entities;
using NutriSport.DAL;

namespace NutriSport.BL
{
    public class Proveedor_BL
    {
        public static List<Proveedor> ObtenerTodos()
        {
            return Proveedor_DAL.ObtenerTodos();
        }

        public static int Agregar(Proveedor entidad)
        {
            return Proveedor_DAL.Agregar(entidad);
        }
    }
}

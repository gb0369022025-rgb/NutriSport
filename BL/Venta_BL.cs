using System.Collections.Generic;
using NutriSport.Entities;
using NutriSport.DAL;

namespace NutriSport.BL
{
    public class Venta_BL
    {
        public static List<Venta> ObtenerTodos()
        {
            return Venta_DAL.ObtenerTodos();
        }

        public static int Agregar(Venta entidad)
        {
            return Venta_DAL.Agregar(entidad);
        }
    }
}

using System.Collections.Generic;
using NutriSport.Entities;
using NutriSport.DAL;

namespace NutriSport.BL
{
    public class Compra_BL
    {
        public static List<Compra> ObtenerTodos()
        {
            return Compra_DAL.ObtenerTodos();
        }

        public static int Agregar(Compra entidad)
        {
            return Compra_DAL.Agregar(entidad);
        }
    }
}

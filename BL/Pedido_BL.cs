using System.Collections.Generic;
using NutriSport.Entities;
using NutriSport.DAL;

namespace NutriSport.BL
{
    public class Pedido_BL
    {
        public static List<Pedido> ObtenerTodos()
        {
            return Pedido_DAL.ObtenerTodos();
        }

        public static int Agregar(Pedido entidad)
        {
            return Pedido_DAL.Agregar(entidad);
        }
    }
}

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

        public static int Eliminar(int id)
        {
            return Venta_DAL.Eliminar(id);
        }

        public static int Registrar(Venta entidad, List<Detalle_Venta> detalle)
        {
            return Venta_DAL.Registrar(entidad, detalle);
        }

        public static Dictionary<DateTime, decimal> ObtenerTotalesPorDia(DateTime desde)
        {
            return Venta_DAL.ObtenerTotalesPorDia(desde);
        }
    }
}

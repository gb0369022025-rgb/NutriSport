using System.Collections.Generic;
using NutriSport.Entities;
using NutriSport.DAL;

namespace NutriSport.BL
{
    public class Ctrl_Inventario_BL
    {
        public static List<Ctrl_Inventario> ObtenerTodos()
        {
            return Ctrl_Inventario_DAL.ObtenerTodos();
        }

        public static int Agregar(Ctrl_Inventario entidad)
        {
            return Ctrl_Inventario_DAL.Agregar(entidad);
        }
    }
}

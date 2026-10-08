using System.Collections.Generic;
using Entities;
using NutriSport.DAL;

namespace NutriSport.BL
{
    public class Empleado_BL
    {
        public static List<Empleado> ObtenerTodos()
        {
            return Empleado_DAL.ObtenerTodos();
        }

        public static int Agregar(Empleado entidad)
        {
            return Empleado_DAL.Agregar(entidad);
        }
    }
}

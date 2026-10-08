using System.Collections.Generic;
using Entities;
using NutriSport.DAL;

namespace NutriSport.BL
{
    public class Producto_BL
    {
        public static List<Producto> ObtenerTodos()
        {
            return Producto_DAL.ObtenerTodos();
        }

        public static List<Producto> BuscarPorNombre(string nombre)
        {
            return Producto_DAL.BuscarPorNombre(nombre);
        }

        public static int Agregar(Producto entidad)
        {
            return Producto_DAL.Agregar(entidad);
        }

        public static int Modificar(Producto entidad)
        {
            return Producto_DAL.Modificar(entidad);
        }
    }
}

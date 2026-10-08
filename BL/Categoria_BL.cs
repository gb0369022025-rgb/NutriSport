using System.Collections.Generic;
using NutriSport.Entities;
using NutriSport.DAL;

namespace NutriSport.BL
{
    public class Categoria_BL
    {
        public static List<Categoria> ObtenerTodos()
        {
            return Categoria_DAL.ObtenerTodos();
        }

        public static int Agregar(Categoria entidad)
        {
            return Categoria_DAL.Agregar(entidad);
        }

        public static int Modificar(Categoria entidad)
        {
            return Categoria_DAL.Modificar(entidad);
        }

        public static int Eliminar(int id)
        {
            return Categoria_DAL.Eliminar(id);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Rol_DAL
    {
        public static List<Rol> ObtenerTodos()
        {
            var lista = new List<Rol>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllRol", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Rol
                            {
                                RolId = Convert.ToInt16(reader["Código"]),
                                Nombre = reader["Rol"].ToString() ?? string.Empty,
                                Descripcion = reader["Descripción"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Rol entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertRol", conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

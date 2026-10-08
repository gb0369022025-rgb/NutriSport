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
                string query = "SELECT RolId, Nombre, Descripcion, Estado FROM ROL WHERE Estado = 1";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Rol
                            {
                                RolId = Convert.ToInt16(reader["RolId"]),
                                Nombre = reader["Nombre"].ToString() ?? string.Empty,
                                Descripcion = reader["Descripcion"].ToString() ?? string.Empty,
                                Estado = Convert.ToInt32(reader["Estado"])
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
                string query = "INSERT INTO ROL (Nombre, Descripcion, Estado) VALUES (@Nombre, @Descripcion, @Estado)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
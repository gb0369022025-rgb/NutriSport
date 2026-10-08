using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Proveedor_DAL
    {
        public static List<Proveedor> ObtenerTodos()
        {
            var lista = new List<Proveedor>();
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "SELECT ProveedorId, Nombre, Direccion, Telefono, Estado FROM PROVEEDOR WHERE Estado = 1";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Proveedor
                            {
                                ProveedorId = Convert.ToInt16(reader["ProveedorId"]),
                                Nombre = reader["Nombre"].ToString() ?? string.Empty,
                                Direccion = reader["Direccion"].ToString() ?? string.Empty,
                                Telefono = reader["Telefono"]?.ToString(),
                                Estado = Convert.ToInt32(reader["Estado"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Proveedor entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "INSERT INTO PROVEEDOR (Nombre, Direccion, Telefono, Estado) VALUES (@Nombre, @Direccion, @Telefono, @Estado)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", entidad.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", (object?)entidad.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
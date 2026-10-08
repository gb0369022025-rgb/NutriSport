using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Venta_DAL
    {
        public static List<Venta> ObtenerTodos()
        {
            var lista = new List<Venta>();
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "SELECT IdVenta, FechaVenta, Estado, Descripcion, ClienteId FROM VENTA";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Venta
                            {
                                IdVenta = Convert.ToInt32(reader["IdVenta"]),
                                FechaVenta = Convert.ToDateTime(reader["FechaVenta"]),
                                Estado = reader["Estado"].ToString() ?? string.Empty,
                                Descripcion = reader["Descripcion"].ToString() ?? string.Empty,
                                ClienteId = reader["ClienteId"] != DBNull.Value ? Convert.ToInt32(reader["ClienteId"]) : null
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Venta entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "INSERT INTO VENTA (FechaVenta, Estado, Descripcion, ClienteId) VALUES (@FechaVenta, @Estado, @Descripcion, @ClienteId)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FechaVenta", entidad.FechaVenta);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                    cmd.Parameters.AddWithValue("@ClienteId", (object?)entidad.ClienteId ?? DBNull.Value);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
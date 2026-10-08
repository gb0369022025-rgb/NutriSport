using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Cargo_DAL
    {
        public static List<Cargo> ObtenerTodos()
        {
            var lista = new List<Cargo>();
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "SELECT CargoId, Nombre, Estado FROM CARGO WHERE Estado = 1";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cargo
                            {
                                CargoId = Convert.ToInt16(reader["CargoId"]),
                                Nombre = reader["Nombre"].ToString() ?? string.Empty,
                                Estado = Convert.ToInt32(reader["Estado"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Cargo entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "INSERT INTO CARGO (Nombre, Estado) VALUES (@Nombre, @Estado)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Estado_DAL
    {
        public static List<Estado> ObtenerTodos()
        {
            var lista = new List<Estado>();
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "SELECT EstadoId, Nombre FROM ESTADO";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Estado
                            {
                                EstadoId = Convert.ToInt32(reader["EstadoId"]),
                                Nombre = reader["Nombre"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
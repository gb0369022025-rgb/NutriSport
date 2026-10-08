using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Ctrl_Inventario_DAL
    {
        public static List<Ctrl_Inventario> ObtenerTodos()
        {
            var lista = new List<Ctrl_Inventario>();
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "SELECT ControlInvId, NombreUsuario, FechaHora, CantProducto, Observacion, Estado FROM CTRL_INVENTARIO";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Ctrl_Inventario
                            {
                                ControlInvId = Convert.ToInt32(reader["ControlInvId"]),
                                NombreUsuario = Convert.ToInt32(reader["NombreUsuario"]),
                                FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                                CantProducto = Convert.ToInt32(reader["CantProducto"]),
                                Observacion = reader["Observacion"]?.ToString(),
                                Estado = reader["Estado"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Ctrl_Inventario entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "INSERT INTO CTRL_INVENTARIO (NombreUsuario, FechaHora, CantProducto, Observacion, Estado) " +
                               "VALUES (@NombreUsuario, @FechaHora, @CantProducto, @Observacion, @Estado)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", entidad.NombreUsuario);
                    cmd.Parameters.AddWithValue("@FechaHora", entidad.FechaHora);
                    cmd.Parameters.AddWithValue("@CantProducto", entidad.CantProducto);
                    cmd.Parameters.AddWithValue("@Observacion", (object?)entidad.Observacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
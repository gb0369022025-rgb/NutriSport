using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Det_Ctrl_Iventario_DAL
    {
        public static List<Det_Ctrl_Iventario> ObtenerTodos()
        {
            var lista = new List<Det_Ctrl_Iventario>();
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "SELECT DetControlInvId, Cantidad, Observacion, NombreControlInv FROM DET_CTRL_INVENTARIO";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Det_Ctrl_Iventario
                            {
                                DetControlInvId = Convert.ToInt32(reader["DetControlInvId"]),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Observacion = reader["Observacion"].ToString() ?? string.Empty,
                                NombreControlInv = reader["NombreControlInv"] != DBNull.Value ? Convert.ToInt32(reader["NombreControlInv"]) : null
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Det_Ctrl_Iventario entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                string query = "INSERT INTO DET_CTRL_INVENTARIO (Cantidad, Observacion, NombreControlInv) " +
                               "VALUES (@Cantidad, @Observacion, @NombreControlInv)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cantidad", entidad.Cantidad);
                    cmd.Parameters.AddWithValue("@Observacion", entidad.Observacion);
                    cmd.Parameters.AddWithValue("@NombreControlInv", (object?)entidad.NombreControlInv ?? DBNull.Value);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
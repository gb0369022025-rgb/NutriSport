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
                using (var cmd = BDComun.ObtenerComando("SpSelectAllDetControlInv", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Det_Ctrl_Iventario
                            {
                                DetControlInvId = Convert.ToInt32(reader["Código"]),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Observacion = reader["Observación"].ToString() ?? string.Empty,
                                NombreControlInv = reader["Código Control"] != DBNull.Value ? Convert.ToInt32(reader["Código Control"]) : null
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
                using (var cmd = BDComun.ObtenerComando("SpInsertDetControlInv", conn))
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

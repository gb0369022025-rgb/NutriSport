using System;
using System.Collections.Generic;
using System.Data;
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
                using (var cmd = BDComun.ObtenerComando("SpSelectAllControlInventario", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string usuario = reader["Usuario"].ToString() ?? string.Empty;

                            lista.Add(new Ctrl_Inventario
                            {
                                ControlInvId = Convert.ToInt32(reader["Código Control"]),
                                NombreUsuario = Convert.ToInt32(usuario.Substring(0, usuario.IndexOf(" - "))),
                                FechaHora = Convert.ToDateTime(reader["Fecha Hora"]),
                                CantProducto = Convert.ToInt32(reader["Cantidad Productos"]),
                                Observacion = reader["Observación"] != DBNull.Value ? reader["Observación"].ToString() : null,
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
                using (var cmd = BDComun.ObtenerComando("SpInsertControlInventario", conn))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", entidad.NombreUsuario);
                    cmd.Parameters.AddWithValue("@FechaHora", entidad.FechaHora);
                    cmd.Parameters.AddWithValue("@CantProducto", entidad.CantProducto);
                    cmd.Parameters.AddWithValue("@Observacion", (object?)entidad.Observacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    cmd.Parameters.Add(new SqlParameter("@ControlInvIdGenerado", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

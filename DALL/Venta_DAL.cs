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
                using (var cmd = BDComun.ObtenerComando("SpSelectAllVenta", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 'Cliente' viene como "Código - Nombre Apellido" (NULL si la venta no tiene cliente)
                            string cliente = reader["Cliente"] != DBNull.Value ? reader["Cliente"].ToString() ?? string.Empty : string.Empty;

                            lista.Add(new Venta
                            {
                                IdVenta = Convert.ToInt32(reader["Código Venta"]),
                                FechaVenta = Convert.ToDateTime(reader["Fecha"]),
                                Estado = reader["Estado"].ToString() ?? string.Empty,
                                Descripcion = reader["Descripción"].ToString() ?? string.Empty,
                                ClienteId = cliente.Contains(" - ") ? Convert.ToInt32(cliente.Substring(0, cliente.IndexOf(" - "))) : null
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
                using (var cmd = BDComun.ObtenerComando("SpInsertVenta", conn))
                {
                    cmd.Parameters.AddWithValue("@FechaVenta", entidad.FechaVenta);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                    cmd.Parameters.AddWithValue("@ClienteId", (object?)entidad.ClienteId ?? DBNull.Value);
                    cmd.Parameters.Add(new SqlParameter("@IdVentaGenerado", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

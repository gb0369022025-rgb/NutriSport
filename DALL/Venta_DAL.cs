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

        public static int Eliminar(int id)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpDeleteVenta", conn))
                {
                    cmd.Parameters.AddWithValue("@IdVenta", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int Registrar(Venta entidad, List<Detalle_Venta> detalle)
        {
            var productos = new List<string>();
            foreach (Detalle_Venta linea in detalle)
            {
                productos.Add("{\"ProductoId\":" + linea.ProductoId + ",\"Cantidad\":" + linea.Cantidad + "}");
            }

            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpRegistrarVenta", conn))
                {
                    cmd.Parameters.AddWithValue("@FechaVenta", entidad.FechaVenta);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                    cmd.Parameters.AddWithValue("@ClienteId", (object?)entidad.ClienteId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Detalle", "[" + string.Join(",", productos) + "]");
                    var idGenerado = new SqlParameter("@IdVentaGenerado", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(idGenerado);
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(idGenerado.Value);
                }
            }
        }

        public static Dictionary<DateTime, decimal> ObtenerTotalesPorDia(DateTime desde)
        {
            var totales = new Dictionary<DateTime, decimal>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectVentasPorDia", conn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde.Date);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            totales[Convert.ToDateTime(reader["Fecha"]).Date] = Convert.ToDecimal(reader["Total"]);
                        }
                    }
                }
            }
            return totales;
        }
    }
}

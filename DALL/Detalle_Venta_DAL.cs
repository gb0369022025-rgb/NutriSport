using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Detalle_Venta_DAL
    {
        public static List<Detalle_Venta> ObtenerPorVentaId(int idVenta)
        {
            var lista = new List<Detalle_Venta>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectDetalleVenta", conn))
                {
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Detalle_Venta
                            {
                                DetalleVentaId = Convert.ToInt32(reader["Código Detalle"]),
                                Cantidad = Convert.ToInt16(reader["Cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["Precio Unitario"]),
                                TotalPagar = Convert.ToDecimal(reader["Total Pagar"]),
                                IdVenta = reader["Código Venta"] != DBNull.Value ? Convert.ToInt32(reader["Código Venta"]) : null,
                                ProductoId = reader["Código Producto"] != DBNull.Value ? Convert.ToInt16(reader["Código Producto"]) : null
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Detalle_Venta entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertDetalleVenta", conn))
                {
                    cmd.Parameters.AddWithValue("@Cantidad", entidad.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", entidad.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@TotalPagar", entidad.TotalPagar);
                    cmd.Parameters.AddWithValue("@IdVenta", (object?)entidad.IdVenta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProductoId", (object?)entidad.ProductoId ?? DBNull.Value);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

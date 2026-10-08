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
                string query = "SELECT DetalleVentaId, Cantidad, PrecioUnitario, TotalPagar, IdVenta, ProductoId FROM DETALLE_VENTA WHERE IdVenta = @IdVenta";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Detalle_Venta
                            {
                                DetalleVentaId = Convert.ToInt32(reader["DetalleVentaId"]),
                                Cantidad = Convert.ToInt16(reader["Cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                                TotalPagar = Convert.ToDecimal(reader["TotalPagar"]),
                                IdVenta = reader["IdVenta"] != DBNull.Value ? Convert.ToInt32(reader["IdVenta"]) : null,
                                ProductoId = reader["ProductoId"] != DBNull.Value ? Convert.ToInt16(reader["ProductoId"]) : null
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
                string query = "INSERT INTO DETALLE_VENTA (Cantidad, PrecioUnitario, TotalPagar, IdVenta, ProductoId) " +
                               "VALUES (@Cantidad, @PrecioUnitario, @TotalPagar, @IdVenta, @ProductoId)";
                using (var cmd = new SqlCommand(query, conn))
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
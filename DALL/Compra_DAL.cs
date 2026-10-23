using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Compra_DAL
    {
        public static List<Compra> ObtenerTodos()
        {
            var lista = new List<Compra>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllCompra", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 'Proveedor' y 'Usuario' vienen como "Código - Nombre"
                            string proveedor = reader["Proveedor"].ToString() ?? string.Empty;
                            string usuario = reader["Usuario"].ToString() ?? string.Empty;

                            lista.Add(new Compra
                            {
                                CompraId = Convert.ToInt32(reader["Código Compra"]),
                                FechaHora = Convert.ToDateTime(reader["Fecha Hora"]),
                                NombreProveedor = Convert.ToInt16(proveedor.Substring(0, proveedor.IndexOf(" - "))),
                                NumFact = Convert.ToInt32(reader["N° Factura"]),
                                NombreUsuario = Convert.ToInt32(usuario.Substring(0, usuario.IndexOf(" - "))),
                                SubTotal = Convert.ToDecimal(reader["SubTotal"]),
                                TotalPagar = Convert.ToDecimal(reader["Total Pagar"]),
                                Estado = reader["Estado"].ToString() ?? "Completada"
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Compra entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertCompra", conn))
                {
                    cmd.Parameters.AddWithValue("@FechaHora", entidad.FechaHora);
                    cmd.Parameters.AddWithValue("@NombreProveedor", entidad.NombreProveedor);
                    cmd.Parameters.AddWithValue("@NumFact", entidad.NumFact);
                    cmd.Parameters.AddWithValue("@NombreUsuario", entidad.NombreUsuario);
                    cmd.Parameters.AddWithValue("@SubTotal", entidad.SubTotal);
                    cmd.Parameters.AddWithValue("@TotalPagar", entidad.TotalPagar);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    cmd.Parameters.Add(new SqlParameter("@CompraIdGenerada", SqlDbType.Int) { Direction = ParameterDirection.Output });
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

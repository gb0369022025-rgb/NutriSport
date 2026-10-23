using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Pedido_DAL
    {
        public static List<Pedido> ObtenerTodos()
        {
            var lista = new List<Pedido>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllPedido", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Pedido
                            {
                                PedidoId = Convert.ToInt32(reader["Código"]),
                                NumeroPedido = reader["N° Pedido"] != DBNull.Value ? Convert.ToInt32(reader["N° Pedido"]) : null,
                                Fecha = reader["Fecha Registro"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha Registro"]) : null,
                                Estado = reader["Estado"].ToString() ?? "Pendiente"
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Pedido entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertPedido", conn))
                {
                    cmd.Parameters.AddWithValue("@NumeroPedido", (object?)entidad.NumeroPedido ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

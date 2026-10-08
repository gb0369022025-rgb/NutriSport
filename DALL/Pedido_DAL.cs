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
                string query = "SELECT PedidoId, NumeroPedido, Fecha, Estado FROM PEDIDO";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Pedido
                            {
                                PedidoId = Convert.ToInt32(reader["PedidoId"]),
                                NumeroPedido = reader["NumeroPedido"] != DBNull.Value ? Convert.ToInt32(reader["NumeroPedido"]) : null,
                                Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : null,
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
                string query = "INSERT INTO PEDIDO (NumeroPedido, Fecha, Estado) VALUES (@NumeroPedido, @Fecha, @Estado)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NumeroPedido", (object?)entidad.NumeroPedido ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fecha", (object?)entidad.Fecha ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
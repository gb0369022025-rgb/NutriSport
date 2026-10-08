using System;
using System.Collections.Generic;
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
                string query = "SELECT CompraId, FechaHora, NombreProveedor, NumFact, NombreUsuario, SubTotal, TotalPagar, Estado FROM COMPRA";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Compra
                            {
                                CompraId = Convert.ToInt32(reader["CompraId"]),
                                FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                                NombreProveedor = Convert.ToInt16(reader["NombreProveedor"]),
                                NumFact = Convert.ToInt32(reader["NumFact"]),
                                NombreUsuario = Convert.ToInt32(reader["NombreUsuario"]),
                                SubTotal = Convert.ToDecimal(reader["SubTotal"]),
                                TotalPagar = Convert.ToDecimal(reader["TotalPagar"]),
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
                string query = "INSERT INTO COMPRA (FechaHora, NombreProveedor, NumFact, NombreUsuario, SubTotal, TotalPagar, Estado) " +
                               "VALUES (@FechaHora, @NombreProveedor, @NumFact, @NombreUsuario, @SubTotal, @TotalPagar, @Estado)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FechaHora", entidad.FechaHora);
                    cmd.Parameters.AddWithValue("@NombreProveedor", entidad.NombreProveedor);
                    cmd.Parameters.AddWithValue("@NumFact", entidad.NumFact);
                    cmd.Parameters.AddWithValue("@NombreUsuario", entidad.NombreUsuario);
                    cmd.Parameters.AddWithValue("@SubTotal", entidad.SubTotal);
                    cmd.Parameters.AddWithValue("@TotalPagar", entidad.TotalPagar);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
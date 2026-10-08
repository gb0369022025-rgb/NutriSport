using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Cliente_DAL
    {
        public static List<Cliente> ObtenerTodos()
        {
            var lista = new List<Cliente>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllCliente", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente
                            {
                                ClienteId = Convert.ToInt32(reader["Código"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Telefono = reader["Teléfono"].ToString(),
                                Email = reader["Correo"].ToString(),
                                DUI = reader["DUI"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Cliente entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertCliente", conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", (object?)entidad.Nombre ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Apellido", (object?)entidad.Apellido ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", (object?)entidad.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object?)entidad.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DUI", (object?)entidad.DUI ?? DBNull.Value);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int Modificar(Cliente entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpUpdateCliente", conn))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", entidad.ClienteId);
                    cmd.Parameters.AddWithValue("@Nombre", (object?)entidad.Nombre ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Apellido", (object?)entidad.Apellido ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", (object?)entidad.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object?)entidad.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DUI", (object?)entidad.DUI ?? DBNull.Value);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
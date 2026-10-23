using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Proveedor_DAL
    {
        public static List<Proveedor> ObtenerTodos()
        {
            var lista = new List<Proveedor>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllProveedor", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Proveedor
                            {
                                ProveedorId = Convert.ToInt16(reader["Código"]),
                                Nombre = reader["Nombre"].ToString() ?? string.Empty,
                                Direccion = reader["Dirección"].ToString() ?? string.Empty,
                                Telefono = reader["Teléfono"] != DBNull.Value ? reader["Teléfono"].ToString() : null
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Proveedor entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertProveedor", conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", entidad.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", (object?)entidad.Telefono ?? DBNull.Value);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

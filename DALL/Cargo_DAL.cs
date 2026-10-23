using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Cargo_DAL
    {
        public static List<Cargo> ObtenerTodos()
        {
            var lista = new List<Cargo>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllCargo", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cargo
                            {
                                CargoId = Convert.ToInt16(reader["Código"]),
                                Nombre = reader["Cargo"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Cargo entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertCargo", conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

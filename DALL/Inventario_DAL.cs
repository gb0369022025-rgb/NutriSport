using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Inventario_DAL
    {
        public static List<Inventario> ObtenerTodos()
        {
            var lista = new List<Inventario>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllInventario", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Inventario
                            {
                                InventarioId = Convert.ToInt32(reader["Código"]),
                                Existencias = Convert.ToInt32(reader["Existencias"]),
                                FechaActualizacion = Convert.ToDateTime(reader["Fecha Actualización"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}

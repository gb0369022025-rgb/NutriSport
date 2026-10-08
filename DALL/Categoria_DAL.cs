using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Categoria_DAL
    {
        public static List<Categoria> ObtenerTodos()
        {
            var lista = new List<Categoria>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllCategoria", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Categoria
                            {
                                CategoriaId = Convert.ToInt32(reader["Código"]),
                                NombreCategoria = reader["Nombre Categoria"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Categoria entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertCategoria", conn))
                {
                    cmd.Parameters.AddWithValue("@Categoria", entidad.NombreCategoria);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int Modificar(Categoria entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpUpdateCategoria", conn))
                {
                    cmd.Parameters.AddWithValue("@CategoriaId", entidad.CategoriaId);
                    cmd.Parameters.AddWithValue("@Categoria", entidad.NombreCategoria);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int Eliminar(int id)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpDeleteCategoria", conn))
                {
                    cmd.Parameters.AddWithValue("@CategoriaId", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
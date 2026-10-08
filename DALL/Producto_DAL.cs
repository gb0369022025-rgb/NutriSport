using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Entities;

namespace NutriSport.DAL
{
    public class Producto_DAL
    {
        public static List<Producto> ObtenerTodos()
        {
            var lista = new List<Producto>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllProducto", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto
                            {
                                ProductoId = Convert.ToInt16(reader["Cod."]),
                                NombreProducto = reader["Producto"].ToString() ?? string.Empty,
                                Precio = Convert.ToDecimal(reader["P. Unitario"]),
                                Existencia = Convert.ToInt32(reader["Existencia"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static List<Producto> BuscarPorNombre(string nombre)
        {
            var lista = new List<Producto>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectNombreProducto", conn))
                {
                    cmd.Parameters.AddWithValue("@Producto", nombre);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto
                            {
                                ProductoId = Convert.ToInt16(reader["Codigo"]),
                                NombreProducto = reader["Producto"].ToString() ?? string.Empty,
                                Precio = Convert.ToDecimal(reader["Precio"]),
                                Existencia = Convert.ToInt32(reader["Existencia"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Producto entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertProducto", conn))
                {
                    cmd.Parameters.AddWithValue("@Producto", entidad.NombreProducto);
                    cmd.Parameters.AddWithValue("@Precio", entidad.Precio);
                    cmd.Parameters.AddWithValue("@Existencia", entidad.Existencia);
                    cmd.Parameters.AddWithValue("@CategoriaId", (object?)entidad.CategoriaId ?? DBNull.Value);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int Modificar(Producto entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpUpdateProducto", conn))
                {
                    cmd.Parameters.AddWithValue("@ProductoId", entidad.ProductoId);
                    cmd.Parameters.AddWithValue("@Producto", entidad.NombreProducto);
                    cmd.Parameters.AddWithValue("@Precio", entidad.Precio);
                    cmd.Parameters.AddWithValue("@Existencia", entidad.Existencia);
                    cmd.Parameters.AddWithValue("@CategoriaId", (object?)entidad.CategoriaId ?? DBNull.Value);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
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
                            string categoria = reader["Categoria"].ToString() ?? string.Empty;

                            lista.Add(new Producto
                            {
                                ProductoId = Convert.ToInt16(reader["Cod."]),
                                NombreProducto = reader["Producto"].ToString() ?? string.Empty,
                                Precio = Convert.ToDecimal(reader["P. Unitario"]),
                                Existencia = Convert.ToInt32(reader["Existencia"]),
                                CategoriaId = Convert.ToInt32(categoria.Substring(0, categoria.IndexOf(" - "))),
                                CodigoBarras = reader["Codigo Barras"] != DBNull.Value ? reader["Codigo Barras"].ToString() : null
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
                                Existencia = Convert.ToInt32(reader["Existencia"]),
                                CodigoBarras = reader["Codigo Barras"] != DBNull.Value ? reader["Codigo Barras"].ToString() : null
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
                    cmd.Parameters.AddWithValue("@CodigoBarras", (object?)entidad.CodigoBarras ?? DBNull.Value);
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
                    cmd.Parameters.AddWithValue("@CodigoBarras", (object?)entidad.CodigoBarras ?? DBNull.Value);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int Eliminar(int id)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpDeleteProducto", conn))
                {
                    cmd.Parameters.AddWithValue("@ProductoId", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static Producto? BuscarPorCodigoBarras(string codigoBarras)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectProductoCodigoBarras", conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoBarras", codigoBarras);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        string categoria = reader["Categoria"].ToString() ?? string.Empty;
                        return new Producto
                        {
                            ProductoId = Convert.ToInt16(reader["Cod."]),
                            NombreProducto = reader["Producto"].ToString() ?? string.Empty,
                            Precio = Convert.ToDecimal(reader["P. Unitario"]),
                            Existencia = Convert.ToInt32(reader["Existencia"]),
                            CategoriaId = Convert.ToInt32(categoria.Substring(0, categoria.IndexOf(" - "))),
                            CodigoBarras = reader["Codigo Barras"].ToString()
                        };
                    }
                }
            }
        }
    }
}

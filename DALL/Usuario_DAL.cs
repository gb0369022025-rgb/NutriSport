using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using NutriSport.Entities;

namespace NutriSport.DAL
{
    public class Usuario_DAL
    {
        public static List<Usuario> ObtenerTodos()
        {
            var lista = new List<Usuario>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllUsuario", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario
                            {
                                UsuarioId = Convert.ToInt32(reader["Código"]),
                                Nombre = reader["Usuario"].ToString() ?? string.Empty,
                                NombreEmpleado = reader["Empleado"].ToString() ?? string.Empty,
                                Tipo = reader["Tipo Usuario"].ToString() ?? string.Empty,
                                Estado = reader["Estado"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Usuario entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertUsuario", conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("@NombreEmpleado", entidad.NombreEmpleado);
                    cmd.Parameters.AddWithValue("@Clave", entidad.Clave);
                    cmd.Parameters.AddWithValue("@Tipo", entidad.Tipo);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

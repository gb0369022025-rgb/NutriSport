using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Entities;

namespace NutriSport.DAL
{
    public class Empleado_DAL
    {
        public static List<Empleado> ObtenerTodos()
        {
            var lista = new List<Empleado>();
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpSelectAllEmpleado", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 'Rol' y 'Cargo' vienen como "Código - Nombre"
                            string rol = reader["Rol"].ToString() ?? string.Empty;
                            string cargo = reader["Cargo"].ToString() ?? string.Empty;

                            lista.Add(new Empleado
                            {
                                EmpleadoId = Convert.ToInt32(reader["Código"]),
                                Nombre = reader["Nombre"].ToString() ?? string.Empty,
                                Apellido = reader["Apellido"].ToString() ?? string.Empty,
                                Telefono = reader["Teléfono"].ToString() ?? string.Empty,
                                Email = reader["Correo"].ToString() ?? string.Empty,
                                DUI = reader["DUI"].ToString() ?? string.Empty,
                                Direccion = reader["Dirección"].ToString() ?? string.Empty,
                                RolId = Convert.ToInt16(rol.Substring(0, rol.IndexOf(" - "))),
                                CargoId = Convert.ToInt16(cargo.Substring(0, cargo.IndexOf(" - ")))
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static int Agregar(Empleado entidad)
        {
            using (var conn = BDComun.ObtenerConexion())
            {
                using (var cmd = BDComun.ObtenerComando("SpInsertEmpleado", conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", entidad.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", entidad.Telefono);
                    cmd.Parameters.AddWithValue("@Email", entidad.Email);
                    cmd.Parameters.AddWithValue("@DUI", entidad.DUI);
                    cmd.Parameters.AddWithValue("@Direccion", entidad.Direccion);
                    cmd.Parameters.AddWithValue("@RolId", entidad.RolId);
                    cmd.Parameters.AddWithValue("@CargoId", entidad.CargoId);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
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
                string query = "SELECT EmpleadoId, Nombre, Apellido, Telefono, Email, DUI, Direccion, RolId, CargoId, Estado FROM EMPLEADO";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Empleado
                            {
                                EmpleadoId = Convert.ToInt32(reader["EmpleadoId"]),
                                Nombre = reader["Nombre"].ToString() ?? string.Empty,
                                Apellido = reader["Apellido"].ToString() ?? string.Empty,
                                Telefono = reader["Telefono"].ToString() ?? string.Empty,
                                Email = reader["Email"].ToString() ?? string.Empty,
                                DUI = reader["DUI"].ToString() ?? string.Empty,
                                Direccion = reader["Direccion"].ToString() ?? string.Empty,
                                RolId = Convert.ToInt16(reader["RolId"]),
                                CargoId = Convert.ToInt16(reader["CargoId"]),
                                Estado = Convert.ToInt32(reader["Estado"])
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
                string query = "INSERT INTO EMPLEADO (Nombre, Apellido, Telefono, Email, DUI, Direccion, RolId, CargoId, Estado) " +
                               "VALUES (@Nombre, @Apellido, @Telefono, @Email, @DUI, @Direccion, @RolId, @CargoId, @Estado)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", entidad.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", entidad.Telefono);
                    cmd.Parameters.AddWithValue("@Email", entidad.Email);
                    cmd.Parameters.AddWithValue("@DUI", entidad.DUI);
                    cmd.Parameters.AddWithValue("@Direccion", entidad.Direccion);
                    cmd.Parameters.AddWithValue("@RolId", entidad.RolId);
                    cmd.Parameters.AddWithValue("@CargoId", entidad.CargoId);
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
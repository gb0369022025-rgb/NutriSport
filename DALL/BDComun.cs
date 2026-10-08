using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace NutriSport.DAL
{
    public static class BDComun
    {
        // OPCIÓN A: Si la computadora remota usa Autenticación de Windows (Misma red local / Dominio)
        // Reemplaza '192.168.1.50' por la IP real del servidor o equipo de tu compañero.
        private const string CadenaConexion = "Server=192.168.1.50;Database=NUTRISPORT;Trusted_Connection=True;TrustServerCertificate=True;";

        // OPCIÓN B: Si la computadora remota usa Autenticación de SQL Server (Usuario y Contraseña de SQL)
        // private const string CadenaConexion = "Server=192.168.1.50;Database=NUTRISPORT;User Id=miUsuarioSql;Password=miPassword123;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            return conexion;
        }

        public static SqlCommand ObtenerComando(string comando, SqlConnection conexion)
        {
            SqlCommand cmd = new SqlCommand(comando, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
    }
}
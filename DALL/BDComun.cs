using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace NutriSport.DAL
{
    public static class BDComun
    {
        //OPCIÓN A: SQL Server instalado en esta misma laptop (Autenticación de Windows)
        private const string CadenaConexion = "Server=(localdb)\\MSSQLLocalDB;Database=NUTRISPORTS;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30;";
        // OPCIÓN B: Laptop servidor en la red con el usuario sa (Autenticación de SQL Server)
        // Reemplaza la IP y la contraseña por las de tu servidor (ver la guía de conexión remota).
        //private const string CadenaConexion = "Server=192.168.1.200,1433;Database=NUTRISPORTS;User Id=sa;Password=NutriSport2026*;TrustServerCertificate=True;Connect Timeout=5;";

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
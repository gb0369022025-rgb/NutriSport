using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace NutriSport.DAL
{
    public static class BDComun
    {
        private const string CadenaConexion = "Server=(localdb)\\MSSQLLocalDB;Database=NUTRISPORTS;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30;";

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
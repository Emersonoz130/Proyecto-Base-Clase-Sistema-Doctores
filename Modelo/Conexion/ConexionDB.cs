using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Conexion
{
    public class ConexionDB
    {
        private static string servidor = "LAB03-DS-EQ01\\SQLEXPRESS";
        private static string baseDeDatos = "dbHospi";

        public static SqlConnection Conectar() {
            string cadena = $"Data Source={servidor};Initial Catalog={baseDeDatos};Integrated Security =true;";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            return conexion;
        }
    }
}

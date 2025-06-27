using Modelo.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Doctor
    {
        private int idDoctor;
        private string nombre;
        private string apellido;
        private string especialidad;
        private string cargo;

        public int IdDoctor { get => idDoctor; set => idDoctor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        //Metodo para mostrar la informacion
        public static DataTable CargarDoctores() {
            //Necesito una conexion
            SqlConnection conexion = ConexionDB.Conectar();
            //Creamos el Query
            string consultaQuery = "select  Nombre,APELLIDO,Especialidad,Cargo from Doctores;";
            //Y ahora creamos un objeto DataAdapter con el fin  de que se pase la peticion al servidor
            SqlDataAdapter add = new SqlDataAdapter(consultaQuery,conexion);
            //Ahora como mi metodo retorna una DataTable debo crear un objeto de tipo DataTable
            DataTable dataVirtual = new DataTable();
            add.Fill(dataVirtual);
            return dataVirtual;
        
        }
        #region
        public bool InsertarDoctores() { 
        //Siempre hay que hacer una conexion
        SqlConnection conexion=ConexionDB.Conectar();
            string consultaQueryInsertar = "INSERT INTO doctores (nombre,apellido,especialidad,cargo) values (@nombre,@apellido,@especialidad,@cargo);";
            SqlCommand insertar = new SqlCommand(consultaQueryInsertar,conexion);
            insertar.Parameters.AddWithValue("@nombre",nombre);
            insertar.Parameters.AddWithValue("@apellido",apellido);
            insertar.Parameters.AddWithValue("@especialidad",especialidad);
            insertar.Parameters.AddWithValue("@cargo",cargo);
            //Ahora ya insertamos los valores que se reciben desde el form por medio
            // de un objeto y el Set nos ayuda a darle esos valores
            //Hay que validar si al meno una fila se afecto
            if (insertar.ExecuteNonQuery()>0) {
                return true;
            }
            else { 
            return false;
            }
            #endregion
        }

    }
}

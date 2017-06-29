using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InmDAL
{
    public class DALUsuarios
    {
        protected DALSqlServerConnection conexion;
        protected string sql;

        public bool LogueoUsuario(string nombreUsuario, string Password)
        {
            Usuarios oUsuario = null;
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();                
                sql = @"SELECT Codigo, Apellido, Nombre, Contraseña, Bloqueado, FechaAlta, FechaBaja, NombreUsuario, Email, Rol
                        FROM Usuarios WHERE NombreUsuario = @nameusuario";

                command.Connection = conexion.Conexion;
                command.CommandText = sql;
                command.Parameters.AddWithValue("@nameusuario", nombreUsuario);

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    oUsuario = new Usuarios();
                    oUsuario.UserName = reader["UserName"].ToString();



                }        
                reader.Close();
                command.Connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                throw new DALException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DALUsuarios()
        {
            this.conexion = new DALSqlServerConnection();
        }

        public DALUsuarios(string empresa)
        {
            this.conexion = new DALSqlServerConnection(empresa);
        }

    }
}

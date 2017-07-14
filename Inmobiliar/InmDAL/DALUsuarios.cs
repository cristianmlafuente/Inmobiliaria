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
                sql = @"SELECT IdUser, UserName, FirstName, SecondName, Pass, Locked, DateAdded, LowDate, Email
                        FROM Usuarios 
                        WHERE UserName = @nameusuario";

                command.Connection = conexion.Conexion;
                command.CommandText = sql;
                command.Parameters.AddWithValue("@nameusuario", nombreUsuario);

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    oUsuario = new Usuarios();
                    oUsuario.UserName = reader["UserName"].ToString();
                    oUsuario.FirstName = reader["FirstName"].ToString();
                    oUsuario.SecondName = reader["SecondName"].ToString();
                    oUsuario.IdUser = int.Parse(reader["IdUser"].ToString());
                    oUsuario.Pass = reader["Pass"].ToString();
                    oUsuario.Locked = long.Parse(reader["Locked"].ToString());
                    oUsuario.DateAdded = DateTime.Parse(reader["DateAdded"].ToString());
                    oUsuario.LowDate = DateTime.Parse(reader["LowDate"].ToString());
                    oUsuario.Email = reader["Email"].ToString();                    
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

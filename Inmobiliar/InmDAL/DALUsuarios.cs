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
            SqlCommand command = null;
            try
            {
                command = new SqlCommand();
                sql = @"SELECT IdUser, UserName, FirstName, SecondName, Pass, Locked, DateAdded, LowDate, Email
                        FROM Usuarios 
                        WHERE UserName = @nameusuario";

                command.Connection = conexion.Conexion;
                command.CommandText = sql;
                command.Parameters.AddWithValue("@nameusuario", nombreUsuario);

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        if (Encriptador.encriptarCadena(Password) != reader["Pass"].ToString())
                            throw new Exception("La contraseña ingresada no es correcta. ");
                        oUsuario = new Usuarios();
                        oUsuario.UserName = reader["UserName"].ToString();
                        oUsuario.FirstName = reader["FirstName"].ToString();
                        oUsuario.SecondName = reader["SecondName"].ToString();
                        oUsuario.IdUser = int.Parse(reader["IdUser"].ToString());
                        oUsuario.Pass = reader["Pass"].ToString();
                        oUsuario.Locked = long.Parse(reader["Locked"].ToString());
                        if (oUsuario.Locked == 1)
                            throw new Exception("El usuario ingresado esta dado de baja.");
                        oUsuario.DateAdded = DateTime.Parse(reader["DateAdded"].ToString());
                        if (!string.IsNullOrEmpty(reader["LowDate"].ToString())) oUsuario.LowDate = DateTime.Parse(reader["LowDate"].ToString());                                           
                        oUsuario.Email = reader["Email"].ToString();
                    }
                }
                else
                    throw new Exception("El usuario ingresado no es valido, ingrese el usuario correctamente.");
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
            finally
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                if (command != null && command.Connection != null)
                {
                    command.Connection.Close();
                    command.Connection.Dispose();
                }
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

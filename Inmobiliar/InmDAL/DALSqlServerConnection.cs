using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace InmDAL
{
    public class DALSqlServerConnection
    {
        private SqlConnection miConexion;

        private string cadenaConexion;
        private string entornoEjecucion;
        private string empresa;

        #region Constructores
        public DALSqlServerConnection(string Empresa)
        {
            this.empresa = Empresa;
            this.entornoEjecucion = ConfigurationManager.AppSettings["EntornoEjecucion"];
            this.cadenaConexion = getCadenaConexion(this.empresa);
        }

        public DALSqlServerConnection()
        {
            this.empresa = "AyS";
            this.entornoEjecucion = ConfigurationManager.AppSettings["EntornoEjecucion"];
            this.cadenaConexion = getCadenaConexion(this.empresa);
        }

        #endregion

        #region Propiedades
        public SqlConnection Conexion
        {
            get { return this.getConexion(); }
        }    

        public string Servidor
        {
            get { return this.getServidor(); }
        }

        public string UsuarioBD
        {
            get { return this.getUsuarioDB(); }
        }

        public string ContraseniaBD
        {
            get { return this.getContraseniaDB(); }
        }

        public string BaseDatos
        {
            get { return this.getBaseDatos(); }
        }

        public string CadenaConexion
        {
            get { return this.getCadenaConexion(empresa); }
        }
        #endregion

        #region Metodos

        private string getServidor()
        {
            string[] componentesCadena = cadenaConexion.Split(new char[] { ';' });
            return componentesCadena[0].Replace("data source=", "").Trim();
        }

        private string getBaseDatos()
        {
            string[] componentesCadena = cadenaConexion.Split(new char[] { ';' });
            return componentesCadena[3].Replace("initial catalog=", "").Trim();
        }

        private SqlConnection getConexion()
        {
            cadenaConexion = this.getCadenaConexion(this.empresa);
            miConexion = new SqlConnection(cadenaConexion);

            try
            {
                miConexion.Open();
            }
            catch (SqlException ex)
            {
                throw new DALException("No se pudo conectar a la Base de Datos. " + ex.Message);
            }

            return miConexion;
        }

        private string getCadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings[entornoEjecucion].ConnectionString;
        }
        private string getCadenaConexion(string empresa)
        {
            return ConfigurationManager.ConnectionStrings[empresa.ToUpper() + "Conexion" + entornoEjecucion].ConnectionString;
        }

        private string getUsuarioDB()
        {
            string[] componentesCadena = cadenaConexion.Split(new char[] { ';' });
            return componentesCadena[1].Replace("user id=", "").Trim();
        }

        private string getContraseniaDB()
        {
            string[] componentesCadena = cadenaConexion.Split(new char[] { ';' });
            return componentesCadena[2].Replace("password=", "").Trim();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using InmBLL.Entities;
using System.IO;

namespace InmBLL
{
    public class AdministradoraAlquileres
    {
        #region "Recibos Alquileres"

        public void RegistrarPagoAlquiler()
        {

        }

        public byte[] GenerarRecibo(PagoAlquiler Pago)
        {
            OleDbConnection conexion = null;
            string PATH_DIRECTORIO_ARCHIVOS = ConfigurationManager.AppSettings["PathArchivosOriginal"];
            string ReciboAlquiler = ConfigurationManager.AppSettings["ArchivoReciboAlquiler"];
            string PATH_DIRECTORIO_TEMP = ConfigurationManager.AppSettings["PathArchivosTemp"];
            try
            {

                string ArchivoOriginalRecibo = PATH_DIRECTORIO_ARCHIVOS + ReciboAlquiler;
                string ArchivoFinalRecibo = PATH_DIRECTORIO_TEMP + ReciboAlquiler.Split('.')[0] + Pago.Periodo.ToString("MMyy") + Pago.idInquilino.ToString() + Pago.idPropiedad.ToString() + "." + ReciboAlquiler.Split('.')[1];
                if (File.Exists(ArchivoFinalRecibo))
                    File.Delete(ArchivoFinalRecibo);
                File.Copy(ArchivoOriginalRecibo, ArchivoFinalRecibo);
                string cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ArchivoFinalRecibo + ";Extended Properties='Excel 12.0 Xml;HDR=NO';";
                using (conexion = new OleDbConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (OleDbCommand comando = conexion.CreateCommand())
                    {



                    }

                    conexion.Close();
                    conexion.Dispose();
                    conexion = null;
                }


                var arr = new byte[40];
                return arr;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }            
        }

        #endregion
    }
}


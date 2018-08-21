using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using InmBLL.Entities;
using System.IO;
using Common.Emum;
using Common.Funciones;
using SautinSoft;
using System.Web;

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
            string NombreArchFinal = ReciboAlquiler.Split('.')[0] + Pago.Periodo.Value.ToString("MMyy") + Pago.InquilinoId.ToString() + Pago.PropiedadId.ToString();
            try
            {
                string ArchivoOriginalRecibo = PATH_DIRECTORIO_ARCHIVOS + ReciboAlquiler;
                string ArchivoFinalRecibo = PATH_DIRECTORIO_TEMP + NombreArchFinal + "." + ReciboAlquiler.Split('.')[1];                
                if (File.Exists(HttpContext.Current.Server.MapPath(ArchivoFinalRecibo)))
                    File.Delete(HttpContext.Current.Server.MapPath(ArchivoFinalRecibo));
                File.Copy(HttpContext.Current.Server.MapPath(ArchivoOriginalRecibo), HttpContext.Current.Server.MapPath(ArchivoFinalRecibo));
                string cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath(ArchivoFinalRecibo) + ";Extended Properties='Excel 12.0 Xml;HDR=NO';";
                using (conexion = new OleDbConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (OleDbCommand comando = conexion.CreateCommand())
                    {
                        comando.CommandText = "UPDATE [Hoja1$E2:E2] SET F1= '" + Pago.FechaPago.Value.ToShortDateString() + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$L2:L2] SET F1= '" + Pago.FechaPago.Value.ToShortDateString() + "'";
                        comando.ExecuteNonQuery();
                        var dom = string.IsNullOrWhiteSpace(Pago.Propiedad.Domicilio.Calle) ? "" : Pago.Propiedad.Domicilio.Calle.ToUpper();
                        if (Pago.Propiedad.Domicilio.Piso != null) dom += " Piso " + Pago.Propiedad.Domicilio.Piso + " " + Pago.Propiedad.Domicilio.Dto; 
                        dom += string.IsNullOrWhiteSpace(Pago.Propiedad.Domicilio.Barrio) ? "" : " " + Pago.Propiedad.Domicilio.Barrio.ToUpper();
                        
                        comando.CommandText = "UPDATE [Hoja1$B7:B7] SET F1= '" + dom + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$I7:I7] SET F1= '" + dom + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$B8:B8] SET F1= '" + Pago.Inquilino.Apellido.ToUpper() + " " + Pago.Inquilino.Nombre.ToUpper() + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$I8:I8] SET F1= '" + Pago.Inquilino.Apellido.ToUpper() + " " + Pago.Inquilino.Nombre.ToUpper() + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$C12:C12] SET F1= '" + Pago.Inquilino.Apellido.ToUpper() + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$J12:J12] SET F1= '" + Pago.Inquilino.Apellido.ToUpper() + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$A13:A13] SET F1= '" + Funciones.NumeroALetras(Pago.MontoTotal.ToString()).ToUpper() + ".---'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$H13:H13] SET F1= '" + Funciones.NumeroALetras(Pago.MontoTotal.ToString()).ToUpper() + ".---'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$D14:D14] SET F1= '" + Enum.GetName(typeof(Meses), Pago.Periodo.Value.Month).ToUpper() + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$K14:K14] SET F1= '" + Enum.GetName(typeof(Meses), Pago.Periodo.Value.Month).ToUpper() + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$A29:A29] SET F1= '" + Pago.Observaciones + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$H29:H29] SET F1= '" + Pago.Observaciones + "'";
                        comando.ExecuteNonQuery();
                        foreach (PagoAlquiler_Detalle item in Pago.DetallePago)
                        {
                            int fila;
                            switch (item.TipoId)
                            {
                                case 1:
                                    fila = 20;
                                    break;
                                case 2:
                                    fila = 19;
                                    break;
                                case 3:
                                    fila = 19;
                                    break;
                                case 4:
                                    fila = 27;
                                    break;
                                case 5:
                                    fila = 27;
                                    break;
                                case 6:
                                    fila = 17;
                                    break;
                                case 7:
                                    fila = 26;
                                    break;
                                case 8:
                                    fila = 21;
                                    break;
                                case 9:
                                    fila = 22;
                                    break;
                                case 10:
                                    fila = 23;
                                    break;
                                case 11:
                                    fila = 24;
                                    break;
                                case 12:
                                    fila = 25;
                                    break;
                                case 13:
                                    fila = 18;
                                    break;
                                default:
                                    fila = 27;
                                    break;
                            }
                            comando.CommandText = string.Format("UPDATE [Hoja1$C{0}:C{0}] SET F1= '" + Enum.GetName(typeof(Meses), item.PeriodoPago.Month).ToUpper() + "'", fila);
                            comando.ExecuteNonQuery();
                            comando.CommandText = string.Format("UPDATE [Hoja1$E{0}:E{0}] SET F1= '" + decimal.Round(item.Monto, 2, MidpointRounding.AwayFromZero) + "'", fila);
                            comando.ExecuteNonQuery();
                            comando.CommandText = string.Format("UPDATE [Hoja1$J{0}:J{0}] SET F1= '" + Enum.GetName(typeof(Meses), item.PeriodoPago.Month).ToUpper() + "'", fila);
                            comando.ExecuteNonQuery();
                            comando.CommandText = string.Format("UPDATE [Hoja1$L{0}:L{0}] SET F1= '" + decimal.Round(item.Monto, 2, MidpointRounding.AwayFromZero) + "'", fila);
                            comando.ExecuteNonQuery();
                        }
                        comando.CommandText = "UPDATE [Hoja1$E28:E28] SET F1= '" + Pago.MontoTotal + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1$L28:L28] SET F1= '" + Pago.MontoTotal + "'";
                        comando.ExecuteNonQuery();
                    }

                    conexion.Close();
                    conexion.Dispose();
                    conexion = null;
                }
                byte[] bytes = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(ArchivoFinalRecibo));

                //SautinSoft.ExcelToPdf pdf = new ExcelToPdf();
                //pdf.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;
                //pdf.ConvertFile(ArchivoFinalRecibo, "C:\\work\\Temp\\prueba.pdf");
                //var response = pdf.ConvertFiletoBytes(ArchivoFinalRecibo);
                //pdf.ConvertByteToFile(response, "C:\\work\\Temp\\");
                return bytes;                
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }            
        }


        public byte[] GenerarReciboPropietario(PagoAlquiler Pago, Contratos Contrato)
        {
            OleDbConnection conexion = null;
            string PATH_DIRECTORIO_ARCHIVOS = ConfigurationManager.AppSettings["PathArchivosOriginal"];
            string ReciboPropietario = ConfigurationManager.AppSettings["ArchivoReciboPropietario"];
            string PATH_DIRECTORIO_TEMP = ConfigurationManager.AppSettings["PathArchivosTemp"];
            string NombreArchFinal = ReciboPropietario.Split('.')[0] + Pago.Periodo.Value.ToString("MMyy") + Pago.InquilinoId.ToString() + Pago.PropiedadId.ToString();
            try
            {
                string ArchivoOriginalRecibo = PATH_DIRECTORIO_ARCHIVOS + ReciboPropietario;
                string ArchivoFinalRecibo = PATH_DIRECTORIO_TEMP + NombreArchFinal + "." + ReciboPropietario.Split('.')[1];
                if (File.Exists(ArchivoFinalRecibo))
                    File.Delete(ArchivoFinalRecibo);
                File.Copy(ArchivoOriginalRecibo, ArchivoFinalRecibo);
                string cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ArchivoFinalRecibo + ";Extended Properties='Excel 12.0 Xml;HDR=NO';";
                using (conexion = new OleDbConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (OleDbCommand comando = conexion.CreateCommand())
                    {
                        comando.CommandText = "UPDATE [Hoja1 0$E2:E2] SET F1= '" + Pago.FechaPago.Value.ToShortDateString() + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$L2:L2] SET F1= '" + Pago.FechaPago.Value.ToShortDateString() + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$B7:B7] SET F1= '" + Pago.Propiedad.Domicilio.Calle + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$I7:I7] SET F1= '" + Pago.Propiedad.Domicilio.Calle + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$B8:B8] SET F1= '" + Pago.Propiedad.Personas.Apellido + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$I8:I8] SET F1= '" + Pago.Propiedad.Personas.Apellido + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$A13:A13] SET F1= '" + Funciones.NumeroALetras(Pago.MontoTotal.ToString()) + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$H13:H13] SET F1= '" + Funciones.NumeroALetras(Pago.MontoTotal.ToString()) + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$D14:D14] SET F1= '" + Enum.GetName(typeof(Meses), Pago.Periodo.Value.Month) + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$K14:K14] SET F1= '" + Enum.GetName(typeof(Meses), Pago.Periodo.Value.Month) + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$A28:A28] SET F1= '" + Pago.Observaciones + "'";
                        comando.ExecuteNonQuery();
                        comando.CommandText = "UPDATE [Hoja1 0$H28:H28] SET F1= '" + Pago.Observaciones + "'";
                        comando.ExecuteNonQuery();
                        if (Pago.DetallePago.Any(xx => xx.TipoId == (int)TipoImpuestoServicio.Alquiler))
                        {
                            var alquiler = Pago.DetallePago.First(x => x.TipoId == (int)TipoImpuestoServicio.Alquiler);
                            comando.CommandText = "UPDATE [Hoja1 0$C17:C17] SET F1= '" + Enum.GetName(typeof(Meses), alquiler.PeriodoPago.Month) + "'";
                            comando.ExecuteNonQuery();
                            comando.CommandText = "UPDATE [Hoja1 0$J17:J17] SET F1= '" + Enum.GetName(typeof(Meses), alquiler.PeriodoPago.Month) + "'";
                            comando.ExecuteNonQuery();
                            comando.CommandText = "UPDATE [Hoja1 0$C18:C18] SET F1= '" + Contrato.PorcentajeInmobiliaria + "'";
                            comando.ExecuteNonQuery();
                            comando.CommandText = "UPDATE [Hoja1 0$J18:J18] SET F1= '" + Contrato.PorcentajeInmobiliaria + "'";
                            comando.ExecuteNonQuery();

                        }
                    }
                    conexion.Close();
                    conexion.Dispose();
                    conexion = null;
                }

                SautinSoft.ExcelToPdf pdf = new ExcelToPdf();
                pdf.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;
                var response = pdf.ConvertFiletoBytes(ArchivoFinalRecibo);
                return response;                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}


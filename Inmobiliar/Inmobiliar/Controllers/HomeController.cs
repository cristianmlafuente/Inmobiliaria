using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmBLL;
using InmDAL;
using Common.Emum;
using System.Reflection;
using System.Configuration;
using Inmobiliar.Models;

namespace Inmobiliar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new DatosInmobiliariaModel();
            try
            {
                model.NombreInmobiliaria = NombreEmpresa();
                model.InmueblesEnAlquiler = InmueblesEnAlquiler();
                model.InmueblesEnVenta = InmueblesEnVenta();
                model.Impagos = AlquileresImpagos();
                model.TareasDiarias = TareasDiarias();
                model.Pendientes = PendientesDeInquilinos();
                var tipomsj = Request.QueryString["TipoMsj"];
                var Message = Request.QueryString["Message"];
                if (!string.IsNullOrWhiteSpace(tipomsj))
                {
                    ViewBag.TipoMsj = tipomsj;
                    ViewBag.Message = Message;                
                }
                if (Session["Usuario"] != null)
                    ViewBag.UsuarioLogueado = true;
                else
                    ViewBag.UsuarioLogueado = false;

                return View(model);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Login failed for user") && ex.Message.Contains("locked out"))
                {
                    ViewBag.TipoMsj = "Info";
                    ViewBag.Message = "Error de conexion con la base de datos. Contacte con el administrador del sistema.-";
                }                
                return View(model);
            }            
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [PermisoAtribute(Rol = RolesPermisos.Rol_Alta_Propiedades)]
        public ActionResult Propiedades()
        {            
            return View();                
        }

        [PermisoAtribute(Rol = RolesPermisos.Rol_Alta_Clientes)]
        public ActionResult Clientes()
        {
            return View();                
        }

        [PermisoAtribute(Rol = RolesPermisos.Rol_Cobro_Alquiler)]
        public ActionResult CobroAlquiler()
        {
            return View();
        }

        [PermisoAtribute(Rol = RolesPermisos.Rol_AltaContratos)]
        public ActionResult Contratos()
        {
            return View();
        }

        private string NombreEmpresa()
        {
            try
            {            
                var codEmpresa = ConfigurationManager.AppSettings["CodEmpresa"];
                var empresaBLL = new EmpresasBLL();
                var miEmpresa = empresaBLL.GetById(codEmpresa);
                return miEmpresa.Nombre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string InmueblesEnAlquiler()
        {
            try
            {
                var lstContratos = new ContratosBLL().GetAll();
                lstContratos = lstContratos.Where(x => x.IdEstate.Value == 0 && x.Propiedades.Tipo == "1").ToList();
                if (lstContratos == null)
                    return "0";
                else
                    return lstContratos.Count().ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string InmueblesEnVenta()
        {
            try
            {
                var lstPropie = new PropiedadesBLL().GetAll();
                lstPropie = lstPropie.Where(y => y.Tipo == "2").ToList();
                if (lstPropie == null)
                    return "0";
                else
                    return lstPropie.Count().ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string AlquileresImpagos()
        {
            try
            {
                var PagoPendie = new CobrosBLL().GetPagosPendientes();
                string AlquileresImpagos = "";
                if (PagoPendie == null || PagoPendie.Count() == 0)
                    AlquileresImpagos = "<tr><td></td><td></td><td></td><td></td><td></td></tr>";
                else
                {
                    foreach (var item in PagoPendie)
                    {
                        AlquileresImpagos += "<tr><td>" + item.Nombre + "</td><td>" + item.Fecha + "</td><td>" + item.Telefono + "</td><td>name@site.com</td><td>$ 6.000</td></tr>";
                    }
                }
                return AlquileresImpagos;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string TareasDiarias()
        {
            try
            {
                string Tareas = "";
                if (DateTime.Now.Day <= 10)
                    Tareas += "<a href='#' class='list-group-item' data-toggle='modal' data-target='#myModal' data-message='Cobrar alquileres a clientes. Verificar clientes con deudas de documentos. '><span class='badge'>Principio de mes</span><i class='fa fa-fw fa-comment'></i> Cobro de alquileres</a>";
                if (DateTime.Now.Day > 20 )
                    Tareas += "<a href='#' class='list-group-item' data-toggle='modal' data-target='#myModal' data-message='Llamar a clientes que poseen deudas de meses anteriores y recordar su pago. '><span class='badge'>Recordar Pagos</span><i class='fa fa-fw fa-comment'></i> Clientes Deudores</a>";                
                return Tareas;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string PendientesDeInquilinos()
        {            
            try
            {
                string Pendientes = "";

                Pendientes = @"<tr>
                                        <td>1</td>
                                        <td>John</td>
                                        <td>Doe</td>
                                        <td>John15482</td>
                                        <td>name@site.com</td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>Kimsila</td>
                                        <td>Marriye</td>
                                        <td>Kim1425</td>
                                        <td>name@site.com</td>
                                    </tr>
                                    <tr>
                                        <td>3</td>
                                        <td>Rossye</td>
                                        <td>Nermal</td>
                                        <td>Rossy1245</td>
                                        <td>name@site.com</td>
                                    </tr>
                                    <tr>
                                        <td>4</td>
                                        <td>Richard</td>
                                        <td>Orieal</td>
                                        <td>Rich5685</td>
                                        <td>name@site.com</td>
                                    </tr>
                                    <tr>
                                        <td>5</td>
                                        <td>Jacob</td>
                                        <td>Hielsar</td>
                                        <td>Jac4587</td>
                                        <td>name@site.com</td>
                                    </tr>
                                    <tr>
                                        <td>6</td>
                                        <td>Wrapel</td>
                                        <td>Dere</td>
                                        <td>Wrap4585</td>
                                        <td>name@site.com</td>
                                    </tr>";

                return Pendientes;
            }
            catch (Exception ex)
            {                
                throw new Exception();
            }
        }
    }
}
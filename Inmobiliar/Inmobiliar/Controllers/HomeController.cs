using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmBLL;
using InmDAL;

namespace Inmobiliar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            if (Session["Usuario"] != null)
                ViewBag.UsuarioLogueado = true;
            else
                ViewBag.UsuarioLogueado = false;
            return View();
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
        public ActionResult Propiedades()
        {
            if (Session["Usuario"] != null)
            {
                Usuarios usuario = (Usuarios)Session["Usuario"];

                if (usuario.Roles.Contains(new Roles(){IdRol = 3 , Description = "Propiedades"}))
                    return View();                
                else
                {
                    
                    ViewBag.TipoMsj = "Info";
                    ViewBag.Message = "No tiene autorización para trabajar con esta funcionalidad.";
                    return RedirectToAction("Index", "Home");
                }    
            }
            else
            {
                ViewBag.TipoMsj = "Error";
                ViewBag.Message = "Usuario no logueado.";
                return RedirectToAction("Index");
            }            
        }
        public ActionResult Clientes()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
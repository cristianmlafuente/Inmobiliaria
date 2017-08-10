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
        [PermisoAtribute(Rol = 3)]
        public ActionResult Propiedades()
        {            
            return View();                
        }

        [PermisoAtribute(Rol = 4)]
        public ActionResult Clientes()
        {
            return View();                
        }
    }
}
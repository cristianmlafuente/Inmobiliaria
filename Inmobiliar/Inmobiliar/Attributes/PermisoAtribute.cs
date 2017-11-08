using InmDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Common.Emum;

namespace Inmobiliar.Controllers
{
    public class PermisoAtribute : ActionFilterAttribute
    {
        public RolesPermisos Rol { get; set; }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            HttpContext _contex = System.Web.HttpContext.Current;
            Usuarios user = (Usuarios)_contex.Session["Usuario"];
            

            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index",
                    TipoMsj = "Error",
                    Message = "Debe estar logueado para poder acceder a esta funcionalidad. "                   
    
                }));
            }
            else
            {
                if (!user.Roles.Any(xx => xx.IdRol == (int)this.Rol))
                {
                                            
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Index",
                        TipoMsj = "Error",
                        Message = "No tiene permiso para acceder a esta funcionalidad. "
                    }));
                    //filterContext.HttpContext.Request.Headers.Add("TipoMsj", "Info");
                    //filterContext.HttpContext.Request.Headers.Add("Message", "No tiene permiso");
                    //filterContext.HttpContext.Response.Headers.Add("TipoMsj", "Info");
                    //filterContext.HttpContext.Response.Headers.Add("Message", "No tiene permiso");
                    //filterContext.Controller.ViewBag.TipoMsj = "Info";
                    //filterContext.Controller.ViewBag.Message = "No tiene permiso.";
                }
            }
        }
    }
}

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
                    action = "Index"
                }));
            }
            else
            {
                if (!user.Roles.Any(xx => xx.IdRol == (int)this.Rol))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Index"
                    }));
                }
            }
        }
    }
}

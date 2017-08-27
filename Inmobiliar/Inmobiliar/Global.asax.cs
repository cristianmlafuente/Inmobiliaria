using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using InmoIoC.Services.Configuration;

namespace Inmobiliar
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var _configuration = new ConfigurationIoCAPI();
            var _container = _configuration.ConfigurationIoC();
            var _dependencyResolver = new Inmobiliar.Resolvers.UnityDependencyResolver(_container);
        }
    }
}

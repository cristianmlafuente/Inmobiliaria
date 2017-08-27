using InmBLL;
using InmBLL.Entities;
using InmDAL;
using InmDAL.Contracts;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc5;

namespace Inmobiliar.App_Start
{
    public static class DependencyInjector
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IGenericBLL<InmBLL.Entities.Propiedades>, PropiedadesBLL>(new HierarchicalLifetimeManager());
            return container;
        }

    }
}
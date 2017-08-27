using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.Practices.Unity;

namespace Inmobiliar.Resolvers
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer unity;
        private const string CONTROLLER_FACTORY_TYPE = "system.web.mvc.icontrollerfactory";
        private const string CONTROLLER_ACTIVATOR_TYPE = "system.web.mvc.icontrolleractivator";
        private const string MODEL_METADATA_PROVIDER_TYPE = "system.web.mvc.modelmetadataprovider";
        private const string PAGE_ACTIVATOR_TYPE = "system.web.mvc.iviewpageactivator";


        public UnityDependencyResolver(IUnityContainer unity)
        {
            this.unity = unity;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                var service = this.unity.Resolve(serviceType);
                return service;
            }
            catch (Exception ex)
            {
                LogException(ex, serviceType);
                // By definition of IDependencyResolver contract, this should return null if it cannot be found.
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.unity.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                LogException(ex, serviceType);
                // By definition of IDependencyResolver contract, this should return null if it cannot be found.
                return null;
            }
        }


        private static void LogException(Exception ex, Type serviceType)
        {
            string serviceTypeName = serviceType.ToString().ToLower();

            switch (serviceTypeName)
            {
                case CONTROLLER_FACTORY_TYPE: break;
                case CONTROLLER_ACTIVATOR_TYPE: break;
                case MODEL_METADATA_PROVIDER_TYPE: break;
                case PAGE_ACTIVATOR_TYPE: break;
                default:
                    // Log Exception
                    break;
            }
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op.
        }
    }
}
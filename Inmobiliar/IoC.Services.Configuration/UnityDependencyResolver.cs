
using Inm.IoC;
﻿using Microsoft.Practices.Unity;
using System.Web.Http.Dependencies;
using Microsoft.Practices.ServiceLocation;

namespace Inm.IoC.Services.Configuration
{
    public class UnityDependencyResolver : UnityDependencyScope, IDependencyResolver, IServiceLocator
    {
        public UnityDependencyResolver(IUnityContainer container)
            : base(container)
        {
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = Container.CreateChildContainer();

            return new UnityDependencyScope(childContainer);
        }

        public System.Collections.Generic.IEnumerable<TService> GetAllInstances<TService>()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<object> GetAllInstances(System.Type serviceType)
        {
            throw new System.NotImplementedException();
        }

        public TService GetInstance<TService>(string key)
        {
            throw new System.NotImplementedException();
        }

        public TService GetInstance<TService>()
        {
            throw new System.NotImplementedException();
        }

        public object GetInstance(System.Type serviceType, string key)
        {
            throw new System.NotImplementedException();
        }

        public object GetInstance(System.Type serviceType)
        {
            throw new System.NotImplementedException();
        }
    }
}

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
//using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.InterceptionExtension;
using Inm.IoC;



namespace InmoIoC.Services.Configuration
{
    public class ConfigurationIoCAPI
    {
        public IUnityContainer ConfigurationIoC()
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            Dependency.Register(container);
            return container;
        }
    }
}

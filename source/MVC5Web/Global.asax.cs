using BoService;
using IronFramework.Utility.EntLib.IoC;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WCFServiceClient;

namespace MVC5Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IUnityContainer container = this.GetUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        /// <summary>
        /// The get unity container.
        /// </summary>
        /// <returns>
        /// </returns>
        private IUnityContainer GetUnityContainer()
        {
            // Create UnityContainer          
            IUnityContainer container = new UnityContainer()
                .RegisterType<IControllerActivator, CustomControllerActivator>() // No need to a controller activator
                //.RegisterType<IControllerFactory, UnityControllerFactory>()
                .RegisterType<IEmployeeBoService, EmployeeServiceClient>(
                    new HttpContextLifetimeManager<IEmployeeBoService>(), new InjectionConstructor());

            return container;
        }

    }
}

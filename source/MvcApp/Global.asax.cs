// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The mvc application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcApp
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Microsoft.Practices.Unity;

    using IronFramework.Utility.EntLib.IoC;
    using ServicePoxry.AWServiceReference;

    public class MvcApplication : HttpApplication
    {
        #region Public Methods

        /// <summary>
        /// The register global filters.
        /// </summary>
        /// <param name="filters">
        /// The filters.
        /// </param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary>
        /// The register routes.
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", 
                // Route name
                "{controller}/{action}/{id}", 
                // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
        }

        #endregion

        #region Methods

        /// <summary>
        /// The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

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
                .RegisterType<IEmployeeBoService, EmployeeBoServiceClient>(
                    new HttpContextLifetimeManager<IEmployeeBoService>(), new InjectionConstructor());

            return container;
        }

        #endregion
    }
}
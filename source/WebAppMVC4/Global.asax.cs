// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Meagotnet">
//    Copyright (c) 2010-2012 Peter Liu.  All rights reserved.
// </copyright>
// <summary>
//   WebApiApplication
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WebAppMVC4
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Microsoft.Practices.Unity;
    using ServicePoxry.AWServiceReference;
    using Controllers;
    using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

    /// <summary>
    /// WebApiApplication
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Application the start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureApi(GlobalConfiguration.Configuration);
        }

        /// <summary>
        /// Configures the API.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        private void ConfigureApi(HttpConfiguration config)
        {
            IUnityContainer container = GetUnityContainer();
            config.DependencyResolver = new UnityContainerDependencyResolver(container);
        }


        /// <summary>
        /// Gets the unity container.
        /// </summary>
        /// <returns>
        /// IUnityContainer
        /// </returns>
        private IUnityContainer GetUnityContainer()
        {
            // Create UnityContainer          
            IUnityContainer container = new UnityContainer()
                .RegisterType<EmployeeWCFController>()
                .RegisterType<IEmployeeBoService, EmployeeBoServiceClient>(
                    new HierarchicalLifetimeManager(), new InjectionConstructor());

            return container;
        }
    }

    #region UnityContainerDependencyResolver

    /// <summary>
    /// ScopeContainer
    /// </summary>
    public class ScopeContainer : IDependencyScope
    {
        /// <summary>
        /// The container.
        /// </summary>
        protected IUnityContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopeContainer"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public ScopeContainer(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        #region IDependencyScope Members

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="serviceType">
        /// Type of the service.
        /// </param>
        /// <returns>
        /// object
        /// </returns>
        public object GetService(Type serviceType)
        {
            if (container.IsRegistered(serviceType))
            {
                return container.Resolve(serviceType);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (container.IsRegistered(serviceType))
            {
                return container.ResolveAll(serviceType);
            }
            else
            {
                return new List<object>();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            container.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// UnityContainerDependencyResolver 
    /// </summary>
    /// <remarks>
    /// Asp.net MVC 4
    /// </remarks>
    /// <seealso cref="http://www.asp.net/web-api/overview/extensibility/using-the-web-api-dependency-resolver"/>
    public class UnityContainerDependencyResolver : ScopeContainer, IDependencyResolver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityContainerDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public UnityContainerDependencyResolver(IUnityContainer container)
            : base(container)
        {
        }

        #region IDependencyResolver Members

        /// <summary>
        /// The begin scope.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDependencyScope BeginScope()
        {
            IUnityContainer child = container.CreateChildContainer();
            return new ScopeContainer(child);
        }

        #endregion
    }

    #endregion
}
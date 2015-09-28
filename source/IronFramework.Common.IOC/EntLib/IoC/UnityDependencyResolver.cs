// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityDependencyResolver.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The unity dependency resolver.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Common.IOC.EntLib.IoC
{
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// The Unity container with dependency resolver for asp.net MVC 3
    /// </summary>
    /// <seealso cref="http://www.devtrends.co.uk/blog/integrating-the-unity.mvc3-1.1-nuget-package-from-scratch"/>
    public class UnityDependencyResolver : IDependencyResolver
    {
        #region Constants and Fields

        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public UnityDependencyResolver(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container should not be null");
            this.container = container;
        }

        #endregion

        #region Implemented Interfaces

        #region IDependencyResolver


        /// <summary>
        /// Resolves singly registered services that support arbitrary object creation.
        /// </summary>
        /// <param name="serviceType">The type of the requested service or object.</param>
        /// <returns>
        /// The requested service or object.
        /// </returns>
        public object GetService(Type serviceType)
        {
            if (typeof(IController).IsAssignableFrom(serviceType))
            {
                return this.container.Resolve(serviceType);
            }

            return this.IsRegistered(serviceType) ? this.container.Resolve(serviceType) : null;
        }


        /// <summary>
        /// Resolves multiply registered services.
        /// </summary>
        /// <param name="serviceType">The type of the requested services.</param>
        /// <returns>
        /// The requested services.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this.IsRegistered(serviceType))
            {
                yield return this.container.Resolve(serviceType);
            }

            foreach (var service in this.container.ResolveAll(serviceType))
            {
                yield return service;
            }
        }

        #endregion

        /// <summary>
        /// Determines whether the specified type to check is registered.
        /// </summary>
        /// <param name="typeToCheck">The type to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified type to check is registered; otherwise, <c>false</c>.
        /// </returns>
        private bool IsRegistered(Type typeToCheck)
        {
            var isRegistered = true;

            if (typeToCheck.IsInterface || typeToCheck.IsAbstract)
            {
                isRegistered = this.container.IsRegistered(typeToCheck);

                if (!isRegistered && typeToCheck.IsGenericType)
                {
                    var openGenericType = typeToCheck.GetGenericTypeDefinition();

                    isRegistered = this.container.IsRegistered(openGenericType);
                }
            }

            return isRegistered;
        }

        #endregion
    }
}
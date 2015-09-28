// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityControllerFactory .cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The unity controller factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Common.IOC.EntLib.IoC
{
    using Microsoft.Practices.Unity;
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The unity controller factory.
    /// </summary>
    public class UnityControllerFactory : DefaultControllerFactory
    {
        #region Constants and Fields

        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityControllerFactory"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public UnityControllerFactory(IUnityContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get controller instance.
        /// </summary>
        /// <param name="reqContext">
        /// The req context.
        /// </param>
        /// <param name="controllerType">
        /// The controller type.
        /// </param>
        /// <returns>IController </returns>
        protected override IController GetControllerInstance(RequestContext reqContext, Type controllerType)
        {
            IController controller;
            if (controllerType == null)
            {
                throw new HttpException(
                    404,
                    string.Format(
                        "The controller for path '{0}' could not be found" + "or it does not implement IController.",
                        reqContext.HttpContext.Request.Path));
            }

            if (!typeof(IController).IsAssignableFrom(controllerType))
            {
                throw new ArgumentException(
                    string.Format("Type requested is not a controller: {0}", controllerType.Name), "controllerType");
            }

            try
            {
                controller = this.container.Resolve(controllerType) as IController;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    string.Format("Error resolving controller {0}", controllerType.Name), ex);
            }

            return controller;
        }

        #endregion
    }
}
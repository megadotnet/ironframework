// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomControllerActivator.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The custom controller activator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.EntLib.IoC
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The custom controller activator.
    /// </summary>
    public class CustomControllerActivator : IControllerActivator
    {
        #region Implemented Interfaces

        #region IControllerActivator

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="requestContext">
        /// The request context.
        /// </param>
        /// <param name="controllerType">
        /// The controller type.
        /// </param>
        /// <returns>
        /// </returns>
        IController IControllerActivator.Create(RequestContext requestContext, Type controllerType)
        {
            return DependencyResolver.Current.GetService(controllerType) as IController;
        }

        #endregion

        #endregion
    }
}
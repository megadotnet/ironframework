// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseHttpModule.cs" company="Megadotnet">
//    Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   BaseHttpModule
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IronFramework.Utility.Web.HttpModule
{
    using System.Web;

    /// <summary>
    /// BaseHttpModule
    /// </summary>
    public abstract class BaseHttpModule : IHttpModule
    {
        #region IHttpModule Members

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">
        /// An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application
        /// </param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest +=
                (sender, e) => OnBeginRequest(new HttpContextWrapper(((HttpApplication) sender).Context));

            context.Error += (sender, e) => OnError(new HttpContextWrapper(((HttpApplication) sender).Context));
           
            context.EndRequest +=
                (sender, e) => OnEndRequest(new HttpContextWrapper(((HttpApplication) sender).Context));

            context.PreSendRequestHeaders +=
                (sender, e) => OnPreSendRequestHeaders(new HttpContextWrapper(((HttpApplication) sender).Context));
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        /// <summary>
        /// Called when [begin request].
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public virtual void OnBeginRequest(HttpContextBase context)
        {
        }

        /// <summary>
        /// Called when [error].
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public virtual void OnError(HttpContextBase context)
        {
        }

        /// <summary>
        /// Called when [end request].
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public virtual void OnEndRequest(HttpContextBase context)
        {
        }

        /// <summary>
        /// Called when [pre send request headers].
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public virtual void OnPreSendRequestHeaders(HttpContextBase context)
        {
        }
    }
}
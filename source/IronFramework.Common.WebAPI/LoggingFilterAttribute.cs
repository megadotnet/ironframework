// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingFilterAttribute.cs" company="Megadotnet">
// Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//  LoggingFilterAttribute
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
namespace IronFramework.Common.WebAPI
{
    using IronFramework.Common.Logging.Logger;
    using System.Web.Http.Filters;

    /// <summary>
    /// LoggingFilterAttribute
    /// </summary>
    /// <seealso cref="http://blog.evizija.si/rest-web-api-logging-using-nlog/"/>
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// logger name
        /// </summary>
        private static readonly ILogger log = new Logger("LoggingFilterAttribute");

        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //int? userId = null;
            string functionname = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName + "\\" +
                actionContext.ActionDescriptor.ActionName;

            log.Info(functionname);
            base.OnActionExecuting(actionContext);
        }

    }
}
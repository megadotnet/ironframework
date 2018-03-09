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
    using System.Diagnostics;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    /// <summary>
    /// WebApiProfileActionAttribute
    /// </summary>
    public class WebApiProfileActionAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// timer
        /// </summary>
        private Stopwatch timer;

        /// <summary>
        /// The log
        /// </summary>
        private static readonly ILogger log = new Logger(typeof(WebApiProfileActionAttribute));

        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            this.timer = Stopwatch.StartNew();
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            this.timer.Stop();
            if (filterContext.Exception == null)
            {
                log.DebugFormat("webapi method {2}-{1} execute timespan：{0}", this.timer.Elapsed.TotalSeconds
                    , filterContext.ActionContext.ActionDescriptor.ActionName, filterContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName);
            }
        }
    }
}

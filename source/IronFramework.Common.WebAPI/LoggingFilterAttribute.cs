using IronFramework.Common.Logging.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace IronFramework.Common.WebAPI
{
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
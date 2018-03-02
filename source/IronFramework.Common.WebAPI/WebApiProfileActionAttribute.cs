using IronFramework.Common.Logging.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace IronFramework.Common.WebAPI
{
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
                log.DebugFormat("webapi方法{2}-{1}执行时间：{0}", this.timer.Elapsed.TotalSeconds
                    , filterContext.ActionContext.ActionDescriptor.ActionName, filterContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName);
            }
        }
    }
}

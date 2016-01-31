using IronFramework.Common.Logging.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi2.App_Start
{
    /// <summary>
    /// LogActionWebApiFilterAttribute
    /// </summary>
    public class LogActionWebApiFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Instance of the  log.
        /// </summary>
        private static readonly ILogger log = new Logger("LogActionWebApiFilter");


        /// <summary>
        /// Called when [action executing asynchronous].
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public override async System.Threading.Tasks.Task OnActionExecutingAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            string rawRequest;
            using (var stream = new StreamReader(await actionContext.Request.Content.ReadAsStreamAsync()))
            {
                stream.BaseStream.Position = 0;
                rawRequest = stream.ReadToEnd();
            }
            string body = rawRequest;
            log.DebugFormat("Request {0} {1} {2}"
                , actionContext.Request.Method.ToString()
                      , actionContext.Request.RequestUri.ToString(),
                    body);

            await base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        /// <summary>
        /// Called when [action executed asynchronous].
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public override async System.Threading.Tasks.Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, System.Threading.CancellationToken cancellationToken)
        {

            log.DebugFormat("Response {0} {1} {2}"
               , actionExecutedContext.Request.Method.ToString()
                     , actionExecutedContext.Request.RequestUri.ToString(),
                   await actionExecutedContext.Response.Content.ReadAsStringAsync());

            await base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }



    }
}
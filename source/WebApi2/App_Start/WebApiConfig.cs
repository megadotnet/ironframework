using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Tracing;
using WebApi2.App_Start;
using WebApi2.Areas.HelpPage;
using WebApiThrottle;

namespace WebApi2
{
    /// <summary>
    /// WebApiConfig
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //EnableCors http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api
            config.EnableCors();

            //Documents
            config.SetDocumentationProvider(new XmlDocumentationProvider(
             HttpContext.Current.Server.MapPath("~/App_Data/WebApi2.XML")));

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //http://stackoverflow.com/a/9521363
            FilterConfig.RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters);

            //http://www.asp.net/web-api/overview/testing-and-debugging/tracing-in-aspnet-web-api
            //IsVerbose: If false, each trace contains minimal information. If true, traces include more information.
            //MinimumLevel: Sets the minimum trace level. Trace levels, in order, are Debug, Info, Warn, Error, and Fatal.
            SystemDiagnosticsTraceWriter traceWriter = config.EnableSystemDiagnosticsTracing();
            traceWriter.IsVerbose = false;
            traceWriter.MinimumLevel = TraceLevel.Info;

            config.EnableSystemDiagnosticsTracing();
            config.Services.Replace(typeof(ITraceWriter), new  LoggingTracer());

            //WebAPI Throttle //https://github.com/stefanprodan/WebApiThrottle
            config.MessageHandlers.Add(new ThrottlingHandler()
            {
                Policy = ThrottlePolicy.FromStore(new PolicyConfigurationProvider()),
                Repository = new CacheRepository(),
                Logger = new CommonTracingThrottleLogger()
            });
        }
    }
}

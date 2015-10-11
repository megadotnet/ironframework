using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using WebApi2.Areas.HelpPage;

namespace WebApi2
{
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

            //http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api
            config.EnableCors();

            config.SetDocumentationProvider(new XmlDocumentationProvider(
             HttpContext.Current.Server.MapPath("~/App_Data/WebApi2.XML")));

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //http://stackoverflow.com/a/9521363
            FilterConfig.RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters);
        }
    }
}

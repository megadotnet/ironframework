using BusinessEntities;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ODataWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // New code:
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: GetModel());
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <returns></returns>
        /// <seealso cref="http://stackoverflow.com/questions/24829422/handling-dates-with-odata-v4-ef6-and-web-api-v2-2"/>
        public static IEdmModel GetModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            EntityTypeConfiguration<Address> titleType = builder.EntityType<Address>();
            //http://stackoverflow.com/questions/24829422/handling-dates-with-odata-v4-ef6-and-web-api-v2-2
            titleType.Ignore(t => t.ModifiedDate);
            //titleType.Property(t => t.EdmModifiedDate).Name = "ModifiedDate";


            builder.EntitySet<Address>("Addresses");

            builder.Namespace = typeof(Address).Namespace;

            return builder.GetEdmModel();
        }
    }
}

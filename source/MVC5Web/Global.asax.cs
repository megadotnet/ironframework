using BoService;
using Microsoft.Practices.Unity;
using MVC5Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WCFServiceClient;

namespace MVC5Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //http://www.cnblogs.com/xuanhun/p/3611768.html
            MvcHandler.DisableMvcResponseHeader = true;
            
            //Remove all view engine
            ViewEngines.Engines.Clear();

            //Add Razor view Engine
            //ViewEngines.Engines.Add(new RazorViewEngine());

            //Add Custom view Engine Derived from Razor
            ViewEngines.Engines.Add(new CSharpRazorViewEngine());

        }


    }
}

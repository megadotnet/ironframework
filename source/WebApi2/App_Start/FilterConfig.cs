using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace WebApi2
{
    public class FilterConfig
    {
        /// <summary>
        /// RegisterGlobalFilters
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary>
        /// RegisterWebApiFilters
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection filters)
        {
            //HAMC Auth
            filters.Add(new AuthenticateAttribute());
            //filters.Add(new ExceptionFilterAttribute());
        }
    }


}

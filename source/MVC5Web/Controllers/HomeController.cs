using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC5Web.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// UserName
        /// </summary>
        /// <see cref="http://stackoverflow.com/a/13749788/709066"/>
        /// <seealso cref="http://trycatchfail.com/blog/post/Using-HttpContext-Safely-After-Async-in-ASPNET-MVC-Applications.aspx"/>
        /// <seealso cref="http://stackoverflow.com/a/18384253/709066"/>
        /// <seealso cref="http://stackoverflow.com/questions/28427675/correct-way-to-use-httpcontext-current-user-with-async-await?rq=1"/>
        /// <returns></returns>
        public async Task<string> UserName()
        {

            return await Task.Factory.StartNew<string>((ctx) =>
            {
                return base.User.Identity.Name;
            }, base.User.Identity.Name);

        }

        /// <summary>
        /// UserName
        /// </summary>
        /// <see cref="http://stackoverflow.com/a/10662486/709066"/>
        /// <returns></returns>

        public ActionResult Others()
        {
            var task = Task.Factory.StartNew(
     state =>
     {
         var context = (HttpContext)state;
         //use context
     },
     System.Web.HttpContext.Current);

           return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Iron framewok";

            return View();
        }

    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Megadotnet">
//    Copyright (c) 2010-2012 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebAppMVC4.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
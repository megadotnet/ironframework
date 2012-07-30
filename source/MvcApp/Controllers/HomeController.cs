// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcApp.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        #region Public Methods

        /// <summary>
        /// The about.
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult About()
        {
            return this.View();
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Index()
        {
            this.ViewBag.Message = "Welcome to ASP.NET MVC!";

            return this.View();
        }

        #endregion
    }
}
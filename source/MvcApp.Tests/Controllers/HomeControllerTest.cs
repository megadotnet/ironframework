// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeControllerTest.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The home controller test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcApp.Tests.Controllers
{
    using System.Web.Mvc;

    using MvcApp.Controllers;
    using Xunit;

    /// <summary>
    /// The home controller test.
    /// </summary>
    public class HomeControllerTest
    {
        #region Public Methods

        /// <summary>
        /// The about.
        /// </summary>
        [Fact]
        public void About()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// The index.
        /// </summary>
        [Fact]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Welcome to ASP.NET MVC!", result.ViewBag.Message);
        }

        #endregion
    }
}
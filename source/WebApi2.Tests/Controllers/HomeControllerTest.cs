using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi2;
using WebApi2.Controllers;

namespace WebApi2.Tests.Controllers
{
    /// <summary>
    /// HomeControllerTest
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}

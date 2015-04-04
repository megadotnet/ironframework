using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ODataWebAPI.Tests.BusinessEntities;

namespace ODataWebAPI.Tests
{
    /// <summary>
    /// ODataWebAPIMain
    /// </summary>
    /// <seealso cref="http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/create-an-odata-v4-client-app"/>
    [TestClass]
    public class ODataWebAPIMain
    {
        /// <summary>
        /// Shoulds the get first address from o data API.
        /// </summary>
        [TestMethod]
        public void ShouldGetFirstAddressFromODataAPI()
        {
            string serviceUri = "http://localhost:14437/";
            var container = new Container(new Uri(serviceUri));

            var model=container.Addresses.FirstOrDefault();

            Assert.IsNotNull(model);
        
        }
    }
}

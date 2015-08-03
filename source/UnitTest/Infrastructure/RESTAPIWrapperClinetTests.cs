using DataServiceClient;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Infrastructure
{
    /// <summary>
    /// RESTAPIWrapperClinetTests
    /// </summary>
    public class RESTAPIWrapperClinetTests
    {

        /// <summary>
        /// Clients the HTTP get string test.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ClientHTTPGetStringTest()
        {
            var mockClient = new Mock<IRESTAPIWrapperClinet>();
            mockClient.Setup(c => c.ClientHTTPGetString<Customer>(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(Task.FromResult<string>("success"));

            var client = mockClient.Object;
            string resultstr=await client.ClientHTTPGetString<Customer>("id=1", "GetId", true);

            Assert.Equal("success", resultstr);
        }

        /// <summary>
        /// Clients the HTTP get list test.
        /// </summary>
        /// <returns></returns>
         [Fact]
        public async Task ClientHTTPGetListTest()
        {
            var returnobj = new Customer();
            var mockClient = new Mock<IRESTAPIWrapperClinet>();
            mockClient.Setup(d => d.ClientHTTPGetList<Customer,Customer>(It.IsAny<string>(), It.IsAny<string>(), true))
                .Returns(Task.FromResult<Customer>(returnobj));


            var client = mockClient.Object;
            var result = await client.ClientHTTPGetList<Customer, Customer>("GetData", "Id=100", true);

            Assert.Equal(returnobj, result);
        }

         /// <summary>
         /// Clients the client HTTP put_ return boolean test.
         /// </summary>
         /// <returns></returns>
         [Fact]
         public async Task ClientClientHTTPPut_ReturnBooleanTest()
         {
             var queryObj = new Customer();
             var mockClient = new Mock<IRESTAPIWrapperClinet>();
             mockClient.Setup(d => d.ClientHTTPPut<Customer, Customer>(It.IsAny<Customer>(), It.IsAny<string>()))
                 .Returns(Task.FromResult<bool>(true));


             var client = mockClient.Object;
             var result = await client.ClientHTTPPut<Customer, Customer>(queryObj,"UpdateData");

             Assert.True(result);
         }

    }
}

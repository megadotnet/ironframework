using DataServiceClient;
using DataTransferObject;
using IronFramework.Utility;
using MVC5Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace MvcApp.Tests.Controllers
{
    /// <summary>
    /// NewEmployeeControllerTests
    /// </summary>
    public class NewEmployeeControllerTests
    {
        /// <summary>
        /// Tests the update entity.
        /// </summary>
        /// <returns></returns>
        [Fact]
        //[AutoRollback]
        public async Task TestUpdateEntity()
        {
            var controller = new EmployeeController();
            controller.rESTAPIWrapperClinet = new RESTAPIWrapperClinet(ServiceConfig.URI);
            var results=await controller.Get(1);

            var dto=results.Data as EmployeeDto;
            Assert.NotNull(dto);
            dto.Title = dto.Title + "1";

            var controller2 = new EmployeeController();
            controller2.rESTAPIWrapperClinet = new RESTAPIWrapperClinet(ServiceConfig.URI);
            bool updateflag = await controller2.Put(dto);

            Assert.True(updateflag);
        }

    }
}

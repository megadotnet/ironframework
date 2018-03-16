using BusinessObject;
using BusinessObject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi2.Controllers;
using Xunit;

namespace UnitTest.WebAPI
{
    /// <summary>
    /// EmployeeControllerTests
    /// </summary>
    public class EmployeeControllerTests
    {
        /// <summary>
        /// Tests the get EmployeeController
        /// </summary>
        [Fact]
        public void TestGet()
        {
            var employeeController = new EmployeeController(new EmployeeBO(new EmployeeConverter()));
            Assert.NotNull(employeeController);

        }
    }
}

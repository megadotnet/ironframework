using BusinessEntiies;
using Ploeh.AutoFixture.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi2.Controllers;
using Xunit;
using Xunit.Extensions;

namespace WebApi2.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        /// <summary>
        /// AutoFixture test
        /// </summary>
        /// <seealso cref="https://github.com/AutoFixture/AutoFixture"/>
        /// <param name="employeeDto"></param>
        [Theory, AutoData]
        public void TestMethod(EmployeeDto employeeDto)
        {
            var controller = new EmployeeController();
            var result=controller.Get(employeeDto);

            Assert.NotNull(result);
        }
    }
}

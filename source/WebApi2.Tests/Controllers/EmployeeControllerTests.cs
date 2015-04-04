using BusinessEntities;
using DataTransferObject;
using Ploeh.AutoFixture;
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
    /// <summary>
    ///  EmployeeControllerTests
    /// </summary>
    /// <seealso cref="https://github.com/AutoFixture/AutoFixture"/>
    /// <example>
    /// <code>          
    ////var fixture = new Fixture();
    ///var employeeDto = fixture.Build<EmployeeDto>()
    ///   // .With(e => e.NationalIDNumber, "2342")
    ///     .With(e => e.MaritalStatus, "M")
    ///     .With(e=>e.Gender,"F")
    ///     .With(e=>e.BirthDate,new DateTime(1983,1,1))
    ///    .Create();
    /// </code>
    /// </example>
    /// <remark>Sometime will break by database logic The INSERT statement conflicted with the CHECK constraint "CK_Employee_BirthDate". The conflict occurred in database "AdventureWorks", table "HumanResources.Employee", column 'BirthDate'.
    ///The statement has been terminated.</remark>
    public class EmployeeControllerTests
    {

        /// <summary>
        /// TestAddEmployeeDto
        /// </summary>
        /// <param name="employeeDto"></param>
         [Theory, AutoData, AutoRollback]

        public void TestAddEmployeeDto(EmployeeDto employeeDto)
        {
            var controller = new EmployeeController();
           controller.Post(employeeDto);
        }


        /// <summary>
        /// AutoFixture test
        /// </summary>
        /// <param name="employeeDto"></param>
        [Theory, AutoData]
        public void TestGeEmployeeDto(EmployeeDto employeeDto)
        {
            var controller = new EmployeeController();
            var result=controller.Get(employeeDto);

            Assert.NotNull(result);
        }

        /// <summary>
        /// TestUpdateEmployeeDto
        /// </summary>
        /// <param name="employeeDto"></param>
        [Theory, AutoData, AutoRollback]

        public void TestUpdateEmployeeDto(EmployeeDto employeeDto)
        {
            var controller = new EmployeeController();
            controller.Put(employeeDto);
        }

        /// <summary>
        /// TestDelEmployeeDto
        /// </summary>
        /// <param name="employeeDto"></param>
        [Theory, AutoData, AutoRollback]

        public void TestDelEmployeeDto(EmployeeDto employeeDto)
        {
            var controller = new EmployeeController();
            controller.Delete(employeeDto.EmployeeID);
        }
    }
}

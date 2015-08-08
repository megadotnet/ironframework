using DataServiceClient;
using DataTransferObject;
using DataTransferObject.Model;
using IronFramework.Utility;
using MVC5Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;
using MvcApp.Tests.Controllers;

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
        public async Task GetEntityTest()
        {
            var controller = new EmployeeController();
            controller.rESTAPIWrapperClinet = new RESTAPIWrapperClinet(ServiceConfig.URI);
            var results=await controller.Get(1);

            var dto=results.Data as EmployeeDto;
            Assert.NotNull(dto);
        }

        /// <summary>
        /// Updates the entity tests.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateEntityTests()
        {
            var controller2 = new EmployeeController();
            controller2.SetFakeAuthenticatedControllerContext();
            controller2.rESTAPIWrapperClinet = new RESTAPIWrapperClinet(ServiceConfig.URI);
            var dto = CreateDTO();
            //create
            bool flag = await controller2.Post(dto);
            Assert.True(flag);

            //Get and Find it
            var getDto=await controller2.Find(dto, 1, 1);
            Assert.NotNull(getDto.Data);
            var dbEntity=getDto.Data as EasyuiDatagridData<EmployeeDto>;
            Assert.NotNull(dbEntity);
            Assert.NotEmpty(dbEntity.Rows);

            var pendingUpdateDto = dbEntity.Rows.FirstOrDefault();
            pendingUpdateDto.Title = "xxxx";

            //Update
            bool updateflag=await controller2.Put(pendingUpdateDto);
            Assert.True(updateflag);

            //Delete
             bool deleteflag=await controller2.Delete(pendingUpdateDto.EmployeeID);
             Assert.True(deleteflag);
        }

        /// <summary>
        /// Creates the dto.
        /// </summary>
        /// <returns></returns>
        private EmployeeDto CreateDTO()
        {
            var employee = new EmployeeDto
            {
                ManagerID = 2,
                ContactID = 3,
                Title = "Developer",
                BirthDate = new DateTime(1965, 1, 1, 0, 0, 0),
                HireDate = DateTime.Now,
                Gender = "M",
                MaritalStatus = "M",
                ModifiedDate = DateTime.Now,
                NationalIDNumber = DateTime.Now.ToString("hhmmddss"),
                rowguid = Guid.NewGuid(),
                CurrentFlag = true,
                VacationHours = 2,
                SickLeaveHours = 3,
                SalariedFlag = false,
                LoginID = "peter"+DateTime.Now.Ticks.ToString()
            };
            return employee;
        }

    }
}

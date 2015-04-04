using System;
using BusinessEntities;
using IronFramework.Utility;
using Xunit;
using DataTransferObject;

namespace WebApi2.Tests
{
    public class AutoMapperTest
    {
        /// <summary>
        ///     SourceObjectWithNullReference
        /// </summary>
        /// <see cref="http://stackoverflow.com/a/12523478/709066" />
        /// <seealso cref="http://stackoverflow.com/questions/3083654/automapper-null-properties" />
        [Fact]
        public void SourceObjectWithNullReference()
        {
            var employeeDto = new EmployeeDto
            {
                Title = "Man"
            };

            var employee = new Employee
            {
                ManagerID = 2,
                ContactID = 3,
                Title = "Developer",
                BirthDate = new DateTime(1965, 1, 1, 0, 0, 0),
                HireDate = DateTime.Now,
                Gender = "M",
                MaritalStatus = "M",
                ModifiedDate = DateTime.Now,
                NationalIDNumber = "2",
                rowguid = new Guid(),
                CurrentFlag = true,
                VacationHours = 2,
                SickLeaveHours = 3,
                SalariedFlag = false,
                LoginID = "adventure-works\\peter"
            };

            ITypeAdapter typeAdapter = new TypeAdapter();
            employee = typeAdapter.Transform(employeeDto, employee);

            Assert.NotNull(employee.Gender);
            Assert.Equal(employee.Title, employeeDto.Title);
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessObjectTest.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The business object test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Threading;

    using BusinessEntiies;
    using BusinessObject;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
    using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Validation.PolicyInjection;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.InterceptionExtension;

    using IronFramework.Utility;
    using IronFramework.Utility.UI;
    using Xunit;
    using Xunit.Extensions;
    using System.Data.Entity.Core;

    /// <summary>
    /// The business object test.
    /// </summary>
    public class BusinessObjectTest : TestEmployeeBase
    {
        public BusinessObjectTest()
        {
            this.SetUp(disableTrigger: true);
        }

        #region Public Methods
        /// <summary>
        /// The test_ delete employee_ with_ business object.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void Test_DeleteEmployee_With_BusinessObject()
        {
            var employee = this.CreateNewEmployee();

            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            ebo.CreateEmployee(employee);

            // Insert it
            int eid = employee.EmployeeID;

            // Delete it
            ebo.DelEmployee(employee);

            // Can not get it
            Employee employeefromDb = ebo.GetEmployee(eid);
            Assert.Null(employeefromDb);
        }


        /// <summary>
        /// Tests the service factory with different implement.
        /// </summary>
        [Fact]
        public void TestServiceFactoryWithDifferentImplement()
        {
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            var ebo2 = ServiceFactory.GetInstance<IEmployeeBusinessObject>("NoOLazyloadedAndProxyCreated");
            Assert.NotNull(ebo);
            Assert.NotNull(ebo2);
        }

        /// <summary>
        /// The test bo layer insert invaild fk value arise update exception.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void TestBOLayerInsertInvaildFKValueAriseUpdateException()
        {
            Assert.Throws<UpdateException>(() => BOLayerInsertInvaildFKValueAriseUpdateException());
        }

        private void BOLayerInsertInvaildFKValueAriseUpdateException()
        {
            var employee = new Employee
            {
                // invaild FK value
                ManagerID = 999,
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

            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();

            // By default,have a exception logging files ErrorRolling.log due to arise an exception at bin folder
            ebo.CreateEmployee(employee);

            string loggingfilefullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorRolling.log");
            Assert.True(File.Exists(loggingfilefullpath));
        }

        /// <summary>
        /// The test find employee by title.
        /// </summary>
        [Fact]
        public void TestFindEmployeeByTitle()
        {
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();

            // Get 10 enties
            PagedList<Employee> resultset = ebo.FindByTitle(null, 1, 10);
            Assert.NotNull(resultset);
            Assert.Equal(resultset.Count, 10);
        }

        /// <summary>
        /// The test_ add employee and address_ with_ business object.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void Test_AddEmployeeAndAddress_With_BusinessObject()
        {
            var employee = this.CreateNewEmployee();
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            employee.EmployeePayHistories = new List<EmployeePayHistory> {
                    new EmployeePayHistory
                        {
                           Rate = 18.5m, PayFrequency = 1, ModifiedDate = DateTime.Now, RateChangeDate = DateTime.Now 
                        }
                };
            ebo.CreateEmployee(employee);

            // Insert it
            int eid = employee.EmployeeID;

            // Get it
            var employeefromDb = ebo.GetEmployee(eid);
            Assert.NotNull(employeefromDb);
            Assert.Equal(1, employeefromDb.EmployeePayHistories.FirstOrDefault().PayFrequency);
        }

        /// <summary>
        /// The test_ add employee_ with_ business object.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void Test_AddEmployee_With_BusinessObject()
        {
            Employee employee = this.CreateNewEmployee();
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            ebo.CreateEmployee(employee);

            // Insert it
            int eid = employee.EmployeeID;

            // Get it
            Employee employeefromDb = ebo.GetEmployee(eid);
            Assert.NotNull(employeefromDb);
        }

        /// <summary>
        /// The test_ get employee_ with_ business object.
        /// </summary>
        [Fact]
        public void Test_GetEmployee_With_BusinessObject()
        {
            this.GetEmployeeFromBusinessObject();
        }

        /// <summary>
        /// The test_ update employee_ use_ attach approach.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void Test_UpdateEmployee_Use_AttachApproach()
        {
            int eid = 1;
            Employee employee = this.CreateNewEmployee();

            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();

            // Update entity
            employee.EmployeeID = eid;
            employee.Title = "modify it";

            // We have change entity state as modify in it.
            ebo.UpdateEmployeeByAttachEntity(employee);

            // Get it and verify it
            Employee employeefromDb = ebo.GetEmployee(eid);
            Assert.NotNull(employeefromDb);
            Assert.Equal("modify it", employee.Title);
        }

        /// <summary>
        /// The test_ update employee_ with_ business object.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void Test_UpdateEmployee_With_BusinessObject()
        {
            Employee employee = this.CreateNewEmployee();
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            ebo.CreateEmployee(employee);

            // Insert new entity
            int eid = employee.EmployeeID;

            // Update entity
            employee.Title = "modify it";
            ebo.UpdateEmployee(employee);

            // Get it and verify it
            Employee employeefromDb = ebo.GetEmployee(eid);
            Assert.NotNull(employeefromDb);
            Assert.Equal("modify it", employee.Title);
        }

        /// <summary>
        /// The test attach emploee and update it.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void TestAttachEmploeeAndUpdateIt()
        {
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            var employee = new Employee { EmployeeID = 2 };

            ebo.AttachEmployee(employee);

            employee.Title = "modified";
            ebo.UpdateEmployee(employee);

            Employee entity = ebo.GetEmployee(employee.EmployeeID);

            Assert.NotNull(entity);
            Assert.Equal(employee.Title, entity.Title);
        }

        /// <summary>
        /// The test bo delete employee with attach employee.
        /// </summary>
        [Fact(Skip = "has some issue")]
        public void TestBODeleteEmployeeWithAttachEmployee()
        {
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            var existemployee = new Employee { EmployeeID = 344 };
            ebo.AttachEmployee(existemployee);
            ebo.DelEmployee(existemployee);
        }


        /// <summary>
        /// The test employee business object under muti thread.
        /// </summary>
        [Fact(Skip = "has some issue")]
        public void TestEmployeeBusinessObjectUnderMutiThread()
        {
            ThreadStart job = this.GetEmployeeFromBusinessObject;
            var thread1 = new Thread(job);
            var thread2 = new Thread(job);
            var thread3 = new Thread(job);

            var threads = new[] { thread1, thread2, thread3 };

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
                Thread.Sleep(100);
            }

            Thread.Sleep(2000);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets the employee from business object.
        /// </summary>
        private void GetEmployeeFromBusinessObject()
        {
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            Employee employee = ebo.GetEmployee(1);
            Assert.NotNull(employee);
        }

        #endregion
    }
}
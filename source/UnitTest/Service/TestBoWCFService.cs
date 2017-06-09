// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestBoService.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The test bo service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using System;
    using System.ServiceModel;
    using Xunit.Extensions;
    using Xunit;
    using ServicePoxry.AWServiceReference;
    using IronFramework.Utility.WCF;
    using BoService;
    using UnitTest.Util;

    /// <summary>
    /// The test bo service, it depend on WCF Service. Currently,You need to host this service before you testing. Otherwise,they will failed.
    /// http://localhost:20333/EmployeeBoService.svc
    /// </summary>
    /// <remark>Please use non single modle when unity resolove business object</remark>
    /// <example>
    /// <code><![CDATA[
    /// 
    ///    <register  type="IEmployeeBusinessObject" mapTo="EmployeeBusinessObject">
    ///    <!--<lifetime type="singleton" />-->
    ///    <interceptor type="TransparentProxyInterceptor" />
    ///    <policyInjection />
    ///  </register > 
    ///  
    /// ]]></code>
    /// </example>
    /// TODO: Use channel factory instead of Proxy of client
    public class TestBoWCFService : TestEmployeeBase
    {
        #region Public Methods

        /// <summary>
        /// The test delete employee business object.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void TestDeleteEmployeeBusinessObject()
        {
            CreateWCFServiceHost(() =>
            {
                // T-SQL you may use it clear data: delete from [ADVENTUREWORKS_DATA].[HumanResources].[Employee] where LoginID='adventure-works\peter'
                var EboServiceClient = new EmployeeBoServiceClient();
                int eid = EboServiceClient.CreateEmployee2(this.CreateClientEmployee());

                var deletedentity = new Employee { EmployeeID = eid };

                // Here we do not need get entity again from database.Just use attach. 
                // Note: EF4 context working with unity container only work well on transient mode.  
                // Single mode will arise "The object cannot be deleted because it was not found in the ObjectStateManager"        
                // Unity Lifetime Managers http://msdn.microsoft.com/en-us/library/ff647854.aspx
                // Reference <<Entity framework 4.0 Recipes>> 
                EboServiceClient.DelEmployee(deletedentity);
            });
        }

        /// <summary>
        /// The test employee business object delete 2.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void TestEmployeeBusinessObjectDelete2()
        {
            CreateWCFServiceHost(() =>
           {
               var eboServiceClient = new EmployeeBoServiceClient();
               var employee = this.CreateClientEmployee();
               int employid = eboServiceClient.CreateEmployee2(employee);

               Assert.NotNull(employee);
               Assert.True(employid > 0);

               // Get it
               var employee2 = eboServiceClient.GetEmployee(employid);

               // Delete it
               eboServiceClient.DelEmployee(employee2);
               Assert.NotNull(employee);
           });
        }

        /// <summary>
        /// The test get employee business object.
        /// </summary>
        [Fact]
        public void TestGetEmployeeBusinessObject()
        {
            CreateWCFServiceHost(() =>
            {
                var EboServiceClient = new EmployeeBoServiceClient();
                var employee = EboServiceClient.GetEmployee(1);
                Assert.NotNull(employee);
            });
              
        }


        /// <summary>
        /// The test get employee list.
        /// </summary>
        [Fact]
        public void TestGetEmployeeList()
        {
            CreateWCFServiceHost(() =>
           {
               var EboServiceClient = new EmployeeBoServiceClient();
               int totalcount = 0;
               var employee = EboServiceClient.FindEmployeeByTitle(out totalcount, "Technician", 1, 10);
               Assert.NotNull(employee);
               Assert.Equal(10, employee.Count);
           });
        }

        /// <summary>
        /// The test get employee list_ with_ null condition.
        /// </summary>
        [Fact]
        public void TestGetEmployeeList_With_NullCondition()
        {
            var EboServiceClient = new EmployeeBoServiceClient();
            int totalcount = 0;
            var employee = EboServiceClient.FindEmployeeByTitle(out totalcount, null, 1, 10);
            Assert.NotNull(employee);
            Assert.Equal(10, employee.Count);
        }


        /// <summary>
        /// The test update employee business object.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void TestUpdateEmployeeBusinessObject()
        {
            var EboServiceClient = new EmployeeBoServiceClient();

            // Insert it
            int eid = EboServiceClient.CreateEmployee2(this.CreateClientEmployee());
            bool isSuccess = eid > 0;
            Assert.True(isSuccess, "Insert employee data failed");

            // Get it
            var myEmployee = EboServiceClient.GetEmployee(eid);
            Assert.NotNull(myEmployee);
            Assert.True(myEmployee.EmployeeID > 0);

            // Update
            myEmployee.Title = "new title";
            EboServiceClient.UpdateEmployee(myEmployee);

            // Delete it
            var deletedentity = new Employee { EmployeeID = myEmployee.EmployeeID };

            ////Here we do not need get entity again from database.Just use attach. 
            ////Note: EF4 context working with unity container only work well on transient mode.  
            ////Single mode will arise The object cannot be deleted because it was not found in the ObjectStateManager        
            ////Unity Lifetime Managers http://msdn.microsoft.com/en-us/library/ff647854.aspx
            //// Reference <<Entity framework 4.0 Recipes>> 
            EboServiceClient.DelEmployee(deletedentity);
        }

        #endregion


        #region Private Help method
        /// <summary>
        /// CreateWCFServiceHost
        /// </summary>
        /// <param name="action">action</param>
        private static void CreateWCFServiceHost(Action action)
        {
            using (var employeeService = new ServiceHost<BoService.IEmployeeBoService, EmployeeBoService>(
                 new Uri("http://localhost:20333/EmployeeBoService.svc")
                 ))
              {

                employeeService.Open();
                action();
                employeeService.Close();
            }

        } 
        #endregion
    }
}
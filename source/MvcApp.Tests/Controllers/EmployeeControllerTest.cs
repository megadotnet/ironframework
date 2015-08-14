// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeControllerTest.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The employee controller test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcApp.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcApp.Controllers;
    using ServicePoxry.AWServiceReference;
    using IronFramework.Utility;
    using Xunit;

    /// <summary>
    /// The employee controller test.
    /// </summary>
    public class EmployeeWCFControllerTest
    {
        #region Public Methods

        /// <summary>
        /// The test employee controller create.
        /// </summary>
        [Fact]
        public void TestEmployeeControllerCreate()
        {
            // Arrange
            var controller = GetEmployeeController(new MemeoryEmployeeBoService()); 
            var employee = new Employee { ManagerID = 11, Title = "Engnieer", BirthDate = DateTime.Now, ContactID = 10 };

            // Act
            var result = controller.Create(employee);

            // Assert
            Assert.NotNull(result);
            var redirectToRouteResult = (RedirectToRouteResult)result;
            Assert.NotNull(redirectToRouteResult);
            Assert.Equal("Index",redirectToRouteResult.RouteValues.Values.SingleOrDefault());
        }

        /// <summary>
        /// The test employee controller index.
        /// </summary>
        [Fact]
        public void TestEmployeeControllerIndex()
        {
            // Arrange
            var controller = GetEmployeeController(new MemeoryEmployeeBoService());

            // Act
            var result = controller.Index();
            var enties = result.Model as IEnumerable<Employee>;

            // Assert
            Assert.NotNull(enties);
            Assert.Equal(1, enties.Count());
        }

        [Fact]
        public void TestEmployeeControllerDelete()
        {
            // Arrange
            var controller = GetEmployeeController(new MemeoryEmployeeBoService());

            // Act
           var result = controller.Delete(1);

            // Assert
           Assert.NotNull(result);
           var viewresult = result as ViewResult;
           Assert.NotNull(viewresult);

        }

        [Fact]
        public void TestEmployeeControllerDetails()
        {
            // Arrange
            var controller = GetEmployeeController(new MemeoryEmployeeBoService());

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.NotNull(result);
            var viewresult = result as ViewResult;
            Assert.NotNull(viewresult);
            var employee = viewresult.Model as Employee;
            Assert.NotNull(employee);
            Assert.Equal(1, employee.EmployeeID);
        }

        /// <summary>
        /// Tests the employee controller index has HTTP post attribute.
        /// </summary>
        [Fact]
        public void TestEmployeeControllerIndexHasHttpPostAttribute()
        {
            // Arrange
            var controller = GetEmployeeController(new MemeoryEmployeeBoService());

            //Act
            bool hasPostAttribute = controller.GetMethod(e => e.Create(new Employee()))
                .HasAttribute<HttpPostAttribute>();

            // Assert
            Assert.True(hasPostAttribute);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get employee controller.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
        /// <returns>
        /// Employee Controller
        /// </returns>
        private static EmployeeWCFController GetEmployeeController(IEmployeeBoService service)
        {
            var controller = new EmployeeWCFController(service);

            controller.ControllerContext = new ControllerContext
                {
                   Controller = controller, RequestContext = new RequestContext(new MockHttpContext(), new RouteData()) 
                };
            return controller;
        }

        #endregion
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebAPITest.cs" company="Megadotnet">
//   Copyright (c) 2010-2012 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The WebAPI Unit Test
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcApp.Tests.Controllers
{
    using ServicePoxry.AWServiceReference;
    using WebAppMVC4.Controllers;
    using Xunit;
    using Moq;
    using System.Web.Http;
    using System.Net.Http;
    using System.Net;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Http.Controllers;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;

    /// <summary>
    /// WebAPI Unit Test
    /// </summary>
    /// <remarks>Current it work with asp.net MVC 4 beta</remarks>
    public class WebAPITest
    {
        /// <summary>
        /// Gets the employee should get one entity.
        /// </summary>
        [Fact]
        public void GetEmployeeShouldGetOneEntity()
        {
            var emploeeController = new EmployeeWCFController(new MemeoryEmployeeBoService());
            var item = emploeeController.GetEmployee(1);
            Assert.NotNull(item);
            Assert.IsType<Employee>(item);
        }


        /// <summary>
        /// Gets the employee returns correct item from repository.
        /// </summary>
        [Fact]
        public void GetEmployeeReturnsCorrectItemFromRepository()
        {
            // Arrange
            var product = new Employee { EmployeeID = 1, Title = "SD" };
            var controller = new EmployeeWCFController(new MemeoryEmployeeBoService());

            // Act
            var result = controller.GetEmployee(1);

            // Assert
            Assert.Equal(product.EmployeeID, result.EmployeeID);
        }

        /// <summary>
        /// Gets the product throws when repository returns null.
        /// </summary>
        [Fact]
        public void GetProductThrowsWhenRepositoryReturnsNull()
        {
            var controller = new EmployeeWCFController(new MemeoryEmployeeBoService());
            Assert.Throws<HttpResponseException>(() => controller.GetEmployee(222));
        }

        /// <summary>
        /// Gets all products returns everything in repository.
        /// </summary>
        [Fact]
        public void GetAllProductsReturnsEverythingInRepository()
        {
            // Arrange
            var allItems = new List<Employee>
            {
                new Employee{EmployeeID=1,Title="SD"}
            };
            var controller = new EmployeeWCFController(new MemeoryEmployeeBoService());

            // Act
            var result = controller.GetAllEmployee();

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Posts the employee returns created status code.
        /// </summary>
        [Fact]
        public void PostEmployeeReturnsCreatedStatusCode()
        {
            var controller = new EmployeeWCFController(new MemeoryEmployeeBoService());
            SetupControllerForTests(controller);

            var result = controller.PostEmployee(new Employee { EmployeeID = 1 });
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        /// <summary>
        /// Posts the employee returns the correct location in response message.
        /// </summary>
        [Fact]
        public void PostEmployeeReturnsTheCorrectLocationInResponseMessage()
        {
            var controller = new EmployeeWCFController(new MemeoryEmployeeBoService());
            SetupControllerForTests(controller);

            var result = controller.PostEmployee(new Employee { EmployeeID = 111 });
            Assert.Equal("http://localhost/api/employee/111", result.Headers.Location.ToString());
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);

        }

        /// <summary>
        /// Deletes the employee calls repository remove.
        /// </summary>
        [Fact]
        public void DeleteEmployeeCallsRepositoryRemove()
        {
            int removedId = 123;
            var mockobject= new Mock<IEmployeeBoService>();
            mockobject.Setup(e => e.DelEmployee(It.Is<Employee>(i => i.EmployeeID == removedId))).Returns(true);
            var serviceclient =mockobject.Object;
            var controller = new EmployeeWCFController(serviceclient);
            var employee = new Employee { EmployeeID = removedId };
            controller.DeleteEmployee(employee);

            Assert.Equal(123, removedId);
        }

        /// <summary>
        /// Deletes the employee returns response message with no content status code.
        /// </summary>
        [Fact]
        public void DeleteEmployeeReturnsResponseMessageWithNoContentStatusCode()
        {
            var controller = new EmployeeWCFController(new MemeoryEmployeeBoService());

            var employee = new Employee { EmployeeID = 111 };
            var result = controller.DeleteEmployee(employee);

            Assert.IsType<HttpResponseMessage>(result);
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        /// <summary>
        /// Puts the employee updates repository.
        /// </summary>
        [Fact]
        public void PutEmployeeUpdatesRepository()
        {
            //Arrange
            var controller = new EmployeeWCFController(new MemeoryEmployeeBoService());
            var item=new Employee { EmployeeID=1,Title="PM"};
         
            // Act
            controller.PutEmployee(item);
            var existEmployee = controller.GetEmployee(1);

            // Assert
            Assert.NotNull(existEmployee);
            Assert.Same(item, existEmployee);
        }

        /// <summary>
        /// Puts the employee throws when repository update returns false.
        /// </summary>
        [Fact]
        public void PutEmployeeThrowsWhenRepositoryUpdateReturnsFalse()
        {
            //Arrange
            var controller = new EmployeeWCFController(new MemeoryEmployeeBoService());

            Assert.Throws<HttpResponseException>(() => controller.PutEmployee(new Employee() { EmployeeID=123}));
        }

        /// <summary>
        /// Setups the controller for tests.
        /// </summary>
        /// <param name="controller">The controller.</param>
        private static void SetupControllerForTests(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/employee");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "employee" } });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }

    }
}

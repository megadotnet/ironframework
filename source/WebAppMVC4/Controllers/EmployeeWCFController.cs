// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeController.cs" company="Megadotnet">
//   Copyright (c) 2010-2012 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   Defines the EmployeeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WebAppMVC4.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using ServicePoxry.AWServiceReference;
    using System.Net.Http.Formatting;

    /// <summary>
    /// The employee controller for Web API
    /// </summary>
    public class EmployeeWCFController : ApiController
    {
        /// <summary>
        /// The service client.
        /// </summary>
        private readonly IEmployeeBoService serviceClient;

        #region Constructors and Destructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeWCFController"/> class.
        /// </summary>
        /// <param name="serviceClient">
        /// The service client.
        /// </param>
        public EmployeeWCFController(IEmployeeBoService serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        #endregion

        /// <summary>
        /// The get all employee.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<Employee> GetAllEmployee()
        {
            int totalcount = 10;
            return serviceClient.FindEmployeeByTitle(out totalcount, string.Empty, 1, 10);
        }

        /// <summary>
        /// The get employee.
        /// </summary>
        /// <param name="id">
        /// Get Employee 
        /// </param>
        /// <remarks>access http://localhost:21148/api/employee/1 </remarks>
        /// <returns>
        /// </returns>
        /// <exception cref="HttpResponseException">
        /// </exception>
        public Employee GetEmployee(int id)
        {
            Employee item = serviceClient.GetEmployee(id);
            if (item == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return item;
        }


        /// <summary>
        /// The post employee.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>HttpResponseMessage
        /// </returns>
        public HttpResponseMessage PostEmployee([FromBody]Employee item)
        {
            serviceClient.CreateEmployee2(item);
            HttpResponseMessage response = Request.CreateResponse<Employee>(HttpStatusCode.Created, item,new JsonMediaTypeFormatter());

            string uri = Url.Link("DefaultApi", new {id = item.EmployeeID});
            response.Headers.Location = new Uri(uri);
            return response;
        }


        /// <summary>
        /// The put employee.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <exception cref="HttpResponseException">
        /// </exception>
        public void PutEmployee(Employee item)
        {
            if (!serviceClient.UpdateEmployee(item))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }

        /// <summary>
        /// The delete employee.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// </returns>
        public HttpResponseMessage DeleteEmployee(Employee item)
        {
            serviceClient.DelEmployee(item);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
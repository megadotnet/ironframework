// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RESTServiceTest.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//  REST Service  Unit Test
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.ApplicationServer.Http;
    using Microsoft.ApplicationServer.Http.Description;
    using System.Net.Http;
    using BusinessEntiies;
    using BoService;
    using System.ServiceModel;
    using IronFramework.Utility.WCF;
    using System.ServiceModel.Description;
    using Xunit;
    using Xunit.Extensions;
    using DataTransferObject;

    /// <summary>
    /// RESTServiceTest
    /// </summary>
    public class RESTServiceTest : TestEmployeeBase
    {
        /// <summary>
        /// Tests the CRUD employee method
        /// </summary>
        [Fact]
        [AutoRollback]
        public void TestCRUDEmployee()
        {
            int pkid = 0;
            using (var service =
                 new ServiceHost<IRESTEmployeeService, RESTEmployeeService>(
                 new List<IEndpointBehavior>() { new WebHttpBehavior() }
               , new WebHttpBinding(), new Uri("http://localhost:20260/RESTEmployeeService.svc/")))
            {
                   service.Open();

                    var newone = CreateDTO();
                    var executor = service.Contract;

                    //Create
                    pkid = executor.Create(newone);
                     Assert.True(pkid > 0);

                    //Get it
                    var entityFromDb = executor.Get(pkid);
                    Assert.NotNull(entityFromDb);

                    //Update
                    entityFromDb.Title = "Worker";
                    executor.Update(entityFromDb);
                    Assert.Equal("Worker", entityFromDb.Title);
                
                    //Delete and Clear up
                    var result = executor.Delete(pkid);
                    Assert.True(result);

                    service.Close();
               
            }
        }


        #region Using Wcf web API preview 5
        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <remarks> Need change ICollection<T> to List<T> in entity that  Or mark nav property as XmlIgnore.
        /// 
        /// Use DTOs or (view models in ASP.NET MVC) to decouple from your domain model. 
        /// And you can use AutoMapper to minimize your code converting between domain models and DTOs.
        /// 
        /// We still need modify POCO entity class and T4 template
        ///We want to use EF4 POCO via WCF service, maybe LazyLoadingEnabled set as false
        ///http://stackoverflow.com/questions/3372895/datacontractserializer-error-using-entity-framework-4-0-with-wcf-4-0
        ///http://stackoverflow.com/questions/6959964/can-i-tell-the-wcf-webapi-serializer-to-ignore-nested-class-objects
        ///http://msdn.microsoft.com/en-us/library/dd456853.aspx
        ///http://msdn.microsoft.com/en-us/library/ee705457.aspx
        ///Set Conext.ContextOptions.ProxyCreationEnabled = false;  in IUnitofWork line94 or expose a method set it.
        /// </remarks>
        /// 
        [Fact]
        public void TestGet()
        {
            using (var webservice = CreateRESTHttpService())
            {
                var client = new HttpClient();
                client.BaseAddress = webservice.BaseUri;

                // Builds: http://localhost:20259/RESTEmployeeService.svc/Get?id=1
                var uri = webservice.Uri("Get?id=1");
                var response = client.Get(uri);

                Assert.True(response.IsSuccessStatusCode, response.ToString());
                // Console.WriteLine(response.Content.ReadAsString());
                Assert.True(response.Content.ReadAsString().Contains("1"));
            }
        }

        /// <summary>
        /// Tests the update.
        /// </summary>
        [Fact(Skip = "Use Domain mode instead it")]
        public void TestUpdate()
        {
            using (var webservice = CreateRESTHttpService())
            {
                var client = new HttpClient();
                client.BaseAddress = webservice.BaseUri;

                // Builds: http://localhost:20259/RESTEmployeeService.svc/Update?id=1
                var uri = webservice.Uri("Update?id=1");

                //fake http content
                var keyvalus = new List<KeyValuePair<string, string>>();
                keyvalus.Add(new KeyValuePair<string, string>("EmployeeId", "1"));
                var response = client.Put(uri, new FormUrlEncodedContent(keyvalus));

                Assert.True(response.IsSuccessStatusCode, response.ToString());
                //Console.WriteLine(response.Content.ReadAsString());
                Assert.True(response.Content.ReadAsString().Contains("true"));
            }
        }


        /// <summary>
        /// Tests the create.
        /// </summary>
        [Fact(Skip = "Need check API how to work")]
        [AutoRollback]
        public void TestCreate()
        {
            using (var webservice = CreateRESTHttpService())
            {
                var client = new HttpClient();
                client.BaseAddress = webservice.BaseUri;

                // Builds: http://localhost:20259/RESTEmployeeService.svc/Create

                var uri = webservice.Uri("Create");

                var employee = new Employee()
                {
                    ContactID = 1,
                    ManagerID = 23,
                    Title = "Engineer",
                    BirthDate = DateTime.Now.AddYears(-23),
                    Gender = "1",
                    CurrentFlag = false,
                    HireDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    NationalIDNumber = "32323"
                };

                var httpcontent = new FormUrlEncodedContent(GetEntityToListKeyValuePair(employee));
                var response = client.Post(uri, httpcontent);

                Assert.True(response.IsSuccessStatusCode, response.ToString());
                Assert.True(response.Content.ReadAsString().Contains("true"));
            }
        }

        /// <summary>
        /// Tests the delete.
        /// </summary>
        [Fact(Skip = "Use Domain mode instead it")]
        public void TestDelete()
        {
            using (var webservice = CreateRESTHttpService())
            {

                var client = new HttpClient();
                client.BaseAddress = webservice.BaseUri;

                // Builds: http://localhost:20259/RESTEmployeeService.svc/Del?id=1

                var uri = webservice.Uri("Del?id=1");

                var response = client.Delete(uri);

                Assert.True(response.IsSuccessStatusCode, response.ToString());
                Assert.True(response.Content.ReadAsString().Contains("true"));

            }
        }

        /// <summary>
        /// Creates the REST HTTP service.
        /// </summary>
        /// <returns></returns>
        private HttpWebService<RESTEmployeeService> CreateRESTHttpService()
        {
            return new HttpWebService<RESTEmployeeService>
            (
             serviceBaseUrl: "http://localhost:20259",
             serviceResourcePath: "RESTEmployeeService.svc",
             serviceConfiguration: new HttpConfiguration()
          );
        }

        /// <summary>
        /// Gets the entity to list key value pair.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> GetEntityToListKeyValuePair(Employee employee)
        {
            var keyvalus = new List<KeyValuePair<string, string>>();

            foreach (var po in
             employee.GetType().GetProperties())
            {
                var rr = po.GetValue(employee, null);

                if (rr != null)
                {
                    //parse datatime and guid and bool type has some issue
                    if (!rr.ToString().Contains('/') && !rr.ToString().Contains('-') && !rr.ToString().Contains("False"))
                    {
                        keyvalus.Add(new KeyValuePair<string, string>(po.Name, rr.ToString()));
                        Console.WriteLine("{0}:  {1}", po.Name, rr);
                    }


                }
            }

            return keyvalus;
        }

        #endregion

        /// <summary>
        /// Creates the DTO.
        /// </summary>
        /// <returns>EmployeeDto</returns>
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
                NationalIDNumber = "2",
                rowguid = new Guid(),
                CurrentFlag = true,
                VacationHours = 2,
                SickLeaveHours = 3,
                SalariedFlag = false,
                LoginID = "adventure-works\\peter"
            };
            return employee;
        }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestTypeAdapter.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   Test entity and DTO object mapping function
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UnitTest.TestUtility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xunit;
    using IronFramework.Utility;
    using BusinessEntiies;
    using BusinessObject;
    using BoService;
    using System.ServiceModel;

    /// <summary>
    /// TestTypeAdapter
    ///// </summary>
    public class TestTypeAdapter
    {
        /// <summary>
        /// Transforms the employee pay history.
        /// </summary>
        [Fact]
        public void TransformEmployeePayHistory()
        {
            var adapter = new TypeAdapter<EmployeePayHistory, EmployeePayHistoryDTO>();
            var eph = new EmployeePayHistory()
            {
                EmployeeID = 1,
                ModifiedDate = DateTime.Now
            };
            var dto = adapter.Transform<EmployeePayHistory, EmployeePayHistoryDTO>(eph);

            Assert.Equal(1, dto.EmployeeID);
        }

        /// <summary>
        /// Transforms the DT oto employee pay history.
        /// </summary>
        [Fact]
        public void TransformDTOtoEmployeePayHistory()
        {
            var adapter = new TypeAdapter<EmployeePayHistoryDTO,EmployeePayHistory>();
            var eph = new EmployeePayHistoryDTO()
            {
                EmployeeID = 1,
                ModifiedDate = DateTime.Now
            };
            var dto = adapter.Transform<EmployeePayHistoryDTO, EmployeePayHistory>(eph);

            Assert.Equal(dto.EmployeeID,eph.EmployeeID);
        }

        /// <summary>
        /// Transforms the contact.
        /// </summary>
        [Fact]
        public void TransformContact()
        {
            var adapter = new TypeAdapter<Contact, ContactDTO>();
            var contact = new Contact()
            {
               FirstName="gates"
            };
            var dto = adapter.Transform<Contact, ContactDTO>(contact);

            Assert.Equal(contact.FirstName, dto.FirstName);
        }

        /// <summary>
        /// Transforms the DT oto contact.
        /// </summary>
        [Fact]
        public void TransformDTOtoContact()
        {
            var adapter = new TypeAdapter<ContactDTO, Contact>();
            var contact = new ContactDTO()
            {
                FirstName = "gates"
            };
            var dto = adapter.Transform<ContactDTO,Contact>(contact);

            Assert.Equal(dto.FirstName, contact.FirstName);
        }


        /// <summary>
        /// Transforms the employee.
        /// </summary>
        [Fact]
        public void TransformEmployeeToDTO()
        {
            var adapter = new EmployeeAdapter();
            var employee = new Employee()
            {
                EmployeeID = 1,
                LoginID = "petter",
                ContactID = 12,
                Contact = new Contact() { FirstName = "Peter" },
                EmployeePayHistories = new List<EmployeePayHistory>()
                 {
                    new EmployeePayHistory()
                    {
                        EmployeeID = 1,
                        ModifiedDate = DateTime.Now
                    }
                 }
            };
            var dto = adapter.Transform<Employee, EmployeeDTO>(employee);

            Assert.Equal(employee.EmployeeID, dto.EmployeeID);
            Assert.Equal(employee.LoginID, dto.LoginID);
        }

        /// <summary>
        /// Transforms the DTO to employee.
        /// </summary>
        [Fact]
        public void TransformDTOToEmployee()
        {
            var adapter = new EmployeeAdapter();

            var employee = new EmployeeDTO()
            {
                EmployeeID = 1,
                LoginID = "petter"
                ,ContactID = 12
                ,EmployeePayHistories = new List<EmployeePayHistoryDTO>()
                 {
                    new EmployeePayHistoryDTO()
                    {
                        EmployeeID = 1,
                        ModifiedDate = DateTime.Now
                    }
                 }
            };
            var dto = adapter.Transform<EmployeeDTO, Employee>(employee);

            Assert.Equal(employee.EmployeeID, dto.EmployeeID);
            Assert.Equal(employee.LoginID, dto.LoginID);
        }
    }
}

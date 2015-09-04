// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBOTests.cs" company="Megadotnet">
// Copyright (c) 2010-2014 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The Address repository.
//   This file is auto generated and will be overwritten as soon as the template is executed
//   Do not modify this file...
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
namespace UnitTest.GenreateBOTests
{  
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
	using System.Threading.Tasks;
    using Xunit;
    using BusinessObject.Util;
    using BusinessObject;
    using DataTransferObject;
    using DataAccessObject;

	public  partial class AddressBOTests 
	{
        /// <summary>
        /// Tests the get entiy by pk by own.
        /// </summary>
        [Fact]
        public void TestGetEntiyByPKByOwn()
        {
            var dbcontext = new AdventureWorksEntities();
            var dbresults=dbcontext.Employees.Where(cc => cc.EmployeeID == 1);

            Assert.NotNull(dbresults);
            Assert.NotNull(dbresults.FirstOrDefault());
            Assert.NotNull(dbresults.FirstOrDefault().NationalIDNumber);
        }

	}
}
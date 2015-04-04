// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeTests.cs" company="Megadotnet">
// Copyright (c) 2010-2015 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The EmployeeTests
//   This file is auto generated and will be overwritten as soon as the template is executed
//   Do not modify this file...
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;
using Ploeh.AutoFixture.Xunit;
using DataTransferObject;
using BusinessObject;
	
namespace UnitTest.GenreateBOTests
{   
    /// <summary>
    /// Employee Tests object
    /// </summary>
	public partial class EmployeeTests
	{       
        /// <summary>
        /// Tests the add.
        /// </summary>
        /// <param name="_EmployeeDto">The Employee dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestAdd(EmployeeDto _EmployeeDto)
        {
            var _EmployeeBO = new EmployeeBO();
            bool hasAdded=_EmployeeBO.CreateEntiy(_EmployeeDto);
            Assert.True(hasAdded);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeeDto">The _Employee dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestGet(EmployeeDto _EmployeeDto)
        {
            var _EmployeeBO = new EmployeeBO();
            var dbResult=_EmployeeBO.FindAll(_EmployeeDto);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the update with attach entiy.
        /// </summary>
        /// <param name="_EmployeeDto">The Employee.</param>
        [Theory, AutoData, AutoRollback]
        public void TestUpdateWithAttachEntiy(EmployeeDto _EmployeeDto)
        {
            var _EmployeeBO = new EmployeeBO();
            bool isUpdated = _EmployeeBO.UpdateWithAttachEntiy(_EmployeeDto);
            Assert.True(isUpdated);
        }

        /// <summary>
        /// Tests the delete with attach entiy.
        /// </summary>
        /// <param name="_EmployeeDto">The Employee dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestDeleteWithAttachEntiy(EmployeeDto _EmployeeDto)
        {
            var _EmployeeBO = new EmployeeBO();
            bool isDeleted = _EmployeeBO.DeleteWithAttachEntiy(_EmployeeDto);
            Assert.True(isDeleted);
        }


	}
}
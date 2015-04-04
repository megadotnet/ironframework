// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeePayHistoryTests.cs" company="Megadotnet">
// Copyright (c) 2010-2015 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The EmployeePayHistoryTests
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
    /// EmployeePayHistory Tests object
    /// </summary>
	public partial class EmployeePayHistoryTests
	{       
        /// <summary>
        /// Tests the add.
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">The EmployeePayHistory dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestAdd(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO();
            bool hasAdded=_EmployeePayHistoryBO.CreateEntiy(_EmployeePayHistoryDto);
            Assert.True(hasAdded);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">The _EmployeePayHistory dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestGet(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO();
            var dbResult=_EmployeePayHistoryBO.FindAll(_EmployeePayHistoryDto);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the update with attach entiy.
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">The EmployeePayHistory.</param>
        [Theory, AutoData, AutoRollback]
        public void TestUpdateWithAttachEntiy(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO();
            bool isUpdated = _EmployeePayHistoryBO.UpdateWithAttachEntiy(_EmployeePayHistoryDto);
            Assert.True(isUpdated);
        }

        /// <summary>
        /// Tests the delete with attach entiy.
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">The EmployeePayHistory dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestDeleteWithAttachEntiy(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO();
            bool isDeleted = _EmployeePayHistoryBO.DeleteWithAttachEntiy(_EmployeePayHistoryDto);
            Assert.True(isDeleted);
        }


	}
}
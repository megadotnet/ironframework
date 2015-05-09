// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeBOTests.cs" company="Megadotnet">
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
using BusinessEntities;
using Xunit;
using Xunit.Extensions;
using Ploeh.AutoFixture.Xunit;
using DataTransferObject;
using BusinessObject;
using DataAccessObject;
	
namespace UnitTest.GenreateBOTests
{   
    /// <summary>
    /// Employee Tests object
    /// </summary>
	public partial class EmployeeBOTests
	{       
        #region BoTest

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
        ///GetEntiyByPK
        /// </summary>
        /// <param name="pkid">The PK int</param>
        [Theory, AutoData]
        public void TestGetEntiyByPK(int pkid)
        {
            var _EmployeeBO = new EmployeeBO();
            var dbResult = _EmployeeBO.GetEntiyByPK(pkid);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeeDto">The _Employee dto.</param>
        [Theory, AutoData]
        public void TestFindAll(EmployeeDto _EmployeeDto)
        {
            var _EmployeeBO = new EmployeeBO();
            var dbResult=_EmployeeBO.FindAll(_EmployeeDto);
            Assert.NotNull(dbResult);
		    Assert.True(dbResult.total>0);
        }

		/// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeeDto">The _Employee dto.</param>
        [Theory, AutoData]
        public void TestFindEnties(EmployeeDto _EmployeeDto)
        {
            var _EmployeeBO = new EmployeeBO();
            var dbResult=_EmployeeBO.FindEnties(_EmployeeDto);
            Assert.NotNull(dbResult);
			Assert.True(dbResult.total>0);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeeDto">The _Employee dto.</param>
        [Theory, AutoData]
        public void TestFindEntiesWithSimplePaging(int? pageIndex, int pageSize)
        {
             var _EmployeeBO = new EmployeeBO();
            var dbResult = _EmployeeBO.FindEnties(pageIndex, pageSize);
            Assert.NotNull(dbResult);
			Assert.True(dbResult.Count>0);
        }

		/// <summary>
        /// TestUpdateEntiyWithGet
        /// </summary>
        /// <param name="_EmployeeDto"></param>
        [Theory, AutoData, AutoRollback]
        public void TestUpdateEntiyWithGet(EmployeeDto _EmployeeDto)
        {
            var _EmployeeBO = new EmployeeBO();
            var dbResult = _EmployeeBO.UpdateEntiyWithGet(_EmployeeDto);
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

		/// <summary>
        /// TestDeleteEntiy
        /// </summary>
        /// <param name="_EmployeeDto">_EmployeeDto</param>
        [Theory, AutoData, AutoRollback]
        public void TestDeleteEntiy(EmployeeDto _EmployeeDto)
        {
            var _EmployeeBO = new EmployeeBO();
            bool isDeleted = _EmployeeBO.DeleteEntiy(_EmployeeDto);
            Assert.True(isDeleted);
        }

        #endregion

        /// <summary>
        /// Tests the Employee repository add.
        /// </summary>
        /// <param name="_Employee">The _ Employee.</param>
        [Theory, AutoData, AutoRollback]
        public void TestEmployeeRepositoryAdd(Employee _Employee)
        {
            var _EmployeeRepository = RepositoryHelper.GetEmployeeRepository();
            _EmployeeRepository.Add(_Employee);
            _EmployeeRepository.Save();
        }

        /// <summary>
        /// Tests the Employee repository get.
        /// </summary>
        /// <param name="_EmployeeId">The _ Employee identifier.</param>
        [Theory, AutoData]
        public void TestEmployeeRepositoryGet(int  _EmployeeId)
        {
            var _EmployeeRepository = RepositoryHelper.GetEmployeeRepository();
            var _Employee=_EmployeeRepository.Repository.Find(entity=>entity.EmployeeID==_EmployeeId);
            Assert.NotNull(_Employee);
        }



	}
}
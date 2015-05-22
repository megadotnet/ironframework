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
using System.Threading.Tasks;
using DataTransferObject;
using BusinessObject;
using DataAccessObject;
using BusinessObject.Util;
using Moq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
	
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
            var _EmployeeBO = new EmployeeBO(new FakeEmployeeConverter());
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
            var _EmployeeBO = new EmployeeBO(new FakeEmployeeConverter());
            var dbResult = _EmployeeBO.GetEntiyByPK(pkid);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeeDto">The _Employee dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindAll(EmployeeDto _EmployeeDto)
        {
            var _EmployeeBO = new EmployeeBO(new EmployeeConverter());
		    bool hasAdded = _EmployeeBO.CreateEntiy(_EmployeeDto);
            var dbResult=_EmployeeBO.FindAll(_EmployeeDto);
            Assert.NotNull(dbResult);
		    Assert.True(dbResult.Total>0);
        }

		/// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeeDto">The _Employee dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindEnties(EmployeeDto _EmployeeDto)
        {
            var _EmployeeBO = new EmployeeBO(new EmployeeConverter());
		    bool hasAdded = _EmployeeBO.CreateEntiy(_EmployeeDto);
            var dbResult=_EmployeeBO.FindEnties(_EmployeeDto);
            Assert.NotNull(dbResult);
			Assert.True(dbResult.Total>0);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeeDto">The _Employee dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindEntiesWithSimplePaging(EmployeeDto _EmployeeDto)
        {
             var _EmployeeBO = new EmployeeBO(new EmployeeConverter());
			bool hasAdded = _EmployeeBO.CreateEntiy(_EmployeeDto);
            var dbResult = _EmployeeBO.FindEnties(1, 10);
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
            var _EmployeeBO = new EmployeeBO(new FakeEmployeeConverter());
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
            var _EmployeeBO = new EmployeeBO(new FakeEmployeeConverter());
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
            var _EmployeeBO = new EmployeeBO(new FakeEmployeeConverter());
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
            var _EmployeeBO = new EmployeeBO(new FakeEmployeeConverter());
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

		/// <summary>
        /// Tests the Employee repository Delete.
        /// </summary>
        /// <param name="_Employee">The _ Employee entity.</param>
        [Theory, AutoData, AutoRollback]
        public void TestEmployeeRepositoryDelete(Employee _Employee)
        {
            var _EmployeeRepository = RepositoryHelper.GetEmployeeRepository();
           _EmployeeRepository.Repository.Delete(_Employee);
           _EmployeeRepository.Save();
        }

        /// <summary>
        /// TestEmployeeRepositoryFindAsyc
        /// </summary>
        /// <param name="_AddressId"></param>
        /// <returns></returns>
        [Theory, AutoData]
        public async Task<IEnumerable<Employee>> TestEmployeeRepositoryFindAsyc(List<Employee> _EmployeeModel)
        {
		    var data = _EmployeeModel.AsQueryable();
            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IDbAsyncEnumerable<Employee>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Employee>(data.GetEnumerator()));

            mockSet.As<IQueryable<Employee>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Employee>(data.Provider));

            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AdventureWorksEntities>();
            mockContext.Setup(c => c.Employees).Returns(mockSet.Object);
		
            //var mockObjectContextAdapter = new Mock<IObjectContextAdapter>();
            //mockObjectContextAdapter.Setup(c => c.ObjectContext).Returns(mockContext);

            //var objectcontext = ((IObjectContextAdapter)mockContext.Object).ObjectContext;

            //var _AddressRepository = RepositoryHelper.GetAddressRepository(dbcontext.Object);
            //var _Address = await _AddressRepository.Repository.FindAsync(entity => entity.AddressID == data.FirstOrDefault().AddressID);

            var _EmployeeRepository = mockContext.Object;
            var _Employee = await _EmployeeRepository.Employees.Where(entity => entity.EmployeeID == data.FirstOrDefault().EmployeeID).ToListAsync();


            Assert.NotNull(_Employee);
            return _Employee;
        }

	}
}
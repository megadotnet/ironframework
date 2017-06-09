// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeePayHistoryBOTests.cs" company="Megadotnet">
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
using BusinessEntities;
using Xunit;
using Xunit.Extensions;
using System.Threading.Tasks;
using DataTransferObject;
using BusinessObject;
using DataAccessObject;
using BusinessObject.Util;
using Moq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using IronFramework.Utility.UI;
using Ploeh.AutoFixture.Xunit2;
using UnitTest.Util;

namespace UnitTest.GenreateBOTests
{   
    /// <summary>
    /// EmployeePayHistory Tests object
    /// </summary>
	public partial class EmployeePayHistoryBOTests
	{       
        #region BoTest

        /// <summary>
        /// Tests the add.
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">The EmployeePayHistory dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestAdd(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO(new FakeEmployeePayHistoryConverter());
            bool hasAdded=_EmployeePayHistoryBO.CreateEntiy(_EmployeePayHistoryDto);
            Assert.True(hasAdded);
        }

	    /// <summary>
        ///GetEntiyByPK
        /// </summary>
        /// <param name="pkid">The PK int</param>
        [Theory, AutoData]
        public void TestGetEntiyByPK(Int32 pkid)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO(new FakeEmployeePayHistoryConverter());
            var dtoEntity=new EmployeePayHistoryDto(){EmployeeID=pkid};
            var dbResult = _EmployeePayHistoryBO.GetEntiyByPK(dtoEntity);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">The _EmployeePayHistory dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindAll(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO(new EmployeePayHistoryConverter());
		    bool hasAdded = _EmployeePayHistoryBO.CreateEntiy(_EmployeePayHistoryDto);
            var dbResult=_EmployeePayHistoryBO.FindAll(new PagedList<EmployeePayHistoryDto> {_EmployeePayHistoryDto});
            Assert.NotNull(dbResult);
		    Assert.True(dbResult.Total>0);
        }

		/// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">The _EmployeePayHistory dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindEnties(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO(new EmployeePayHistoryConverter());
		    bool hasAdded = _EmployeePayHistoryBO.CreateEntiy(_EmployeePayHistoryDto);
            var dbResult=_EmployeePayHistoryBO.FindEnties(new PagedList<EmployeePayHistoryDto> {_EmployeePayHistoryDto});
            Assert.NotNull(dbResult);
			Assert.True(dbResult.Total>0);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">The _EmployeePayHistory dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindEntiesWithSimplePaging(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
             var _EmployeePayHistoryBO = new EmployeePayHistoryBO(new EmployeePayHistoryConverter());
			bool hasAdded = _EmployeePayHistoryBO.CreateEntiy(_EmployeePayHistoryDto);
            var dbResult = _EmployeePayHistoryBO.FindEnties(1, 10);
            Assert.NotNull(dbResult);
			Assert.True(dbResult.Count>0);
        }

		/// <summary>
        /// TestUpdateEntiyWithGet
        /// </summary>
        /// <param name="_EmployeePayHistoryDto"></param>
        [Theory, AutoData, AutoRollback]
        public void TestUpdateEntiyWithGet(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO(new FakeEmployeePayHistoryConverter());
            var dbResult = _EmployeePayHistoryBO.UpdateEntiyWithGet(_EmployeePayHistoryDto);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the update with attach entiy.
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">The EmployeePayHistory.</param>
        [Theory, AutoData, AutoRollback]
        public void TestUpdateWithAttachEntiy(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO(new FakeEmployeePayHistoryConverter());
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
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO(new FakeEmployeePayHistoryConverter());
            bool isDeleted = _EmployeePayHistoryBO.DeleteWithAttachEntiy(_EmployeePayHistoryDto);
            Assert.True(isDeleted);
        }

		/// <summary>
        /// TestDeleteEntiy
        /// </summary>
        /// <param name="_EmployeePayHistoryDto">_EmployeePayHistoryDto</param>
        [Theory, AutoData, AutoRollback]
        public void TestDeleteEntiy(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
            var _EmployeePayHistoryBO = new EmployeePayHistoryBO(new FakeEmployeePayHistoryConverter());
            bool isDeleted = _EmployeePayHistoryBO.DeleteEntiy(_EmployeePayHistoryDto);
            Assert.True(isDeleted);
        }

        #endregion

        /// <summary>
        /// Tests the EmployeePayHistory repository add.
        /// </summary>
        /// <param name="_EmployeePayHistory">The _ EmployeePayHistory.</param>
        [Theory, AutoData, AutoRollback]
        public void TestEmployeePayHistoryRepositoryAdd(EmployeePayHistory _EmployeePayHistory)
        {
            var _EmployeePayHistoryRepository = RepositoryHelper.GetEmployeePayHistoryRepository();
            _EmployeePayHistoryRepository.Add(_EmployeePayHistory);
            _EmployeePayHistoryRepository.Save();
        }

        /// <summary>
        /// Tests the EmployeePayHistory repository get.
        /// </summary>
        /// <param name="_EmployeePayHistoryId">The _ EmployeePayHistory identifier.</param>
        [Theory, AutoData]
        public void TestEmployeePayHistoryRepositoryGet(int  _EmployeePayHistoryId)
        {
            var _EmployeePayHistoryRepository = RepositoryHelper.GetEmployeePayHistoryRepository();
            var _EmployeePayHistory=_EmployeePayHistoryRepository.Repository.Find(entity=>entity.EmployeeID==_EmployeePayHistoryId);
            Assert.NotNull(_EmployeePayHistory);
        }

		/// <summary>
        /// Tests the EmployeePayHistory repository Delete.
        /// </summary>
        /// <param name="_EmployeePayHistory">The _ EmployeePayHistory entity.</param>
        [Theory, AutoData, AutoRollback]
        public void TestEmployeePayHistoryRepositoryDelete(EmployeePayHistory _EmployeePayHistory)
        {
            var _EmployeePayHistoryRepository = RepositoryHelper.GetEmployeePayHistoryRepository();
           _EmployeePayHistoryRepository.Repository.Delete(_EmployeePayHistory);
           _EmployeePayHistoryRepository.Save();
        }

        /// <summary>
        /// TestEmployeePayHistoryRepositoryFindAsyc
        /// </summary>
        /// <param name="_AddressId"></param>
        /// <returns></returns>
        [Theory, AutoData]
        public async Task<IEnumerable<EmployeePayHistory>> TestEmployeePayHistoryRepositoryFindAsyc(List<EmployeePayHistory> _EmployeePayHistoryModel)
        {
		    var data = _EmployeePayHistoryModel.AsQueryable();
            var mockSet = new Mock<DbSet<EmployeePayHistory>>();
            mockSet.As<IDbAsyncEnumerable<EmployeePayHistory>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<EmployeePayHistory>(data.GetEnumerator()));

            mockSet.As<IQueryable<EmployeePayHistory>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<EmployeePayHistory>(data.Provider));

            mockSet.As<IQueryable<EmployeePayHistory>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<EmployeePayHistory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<EmployeePayHistory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AdventureWorksEntities>();
            mockContext.Setup(c => c.EmployeePayHistories).Returns(mockSet.Object);
		
            //var mockObjectContextAdapter = new Mock<IObjectContextAdapter>();
            //mockObjectContextAdapter.Setup(c => c.ObjectContext).Returns(mockContext);

            //var objectcontext = ((IObjectContextAdapter)mockContext.Object).ObjectContext;

            //var _AddressRepository = RepositoryHelper.GetAddressRepository(dbcontext.Object);
            //var _Address = await _AddressRepository.Repository.FindAsync(entity => entity.AddressID == data.FirstOrDefault().AddressID);

            var _EmployeePayHistoryRepository = mockContext.Object;
            var _EmployeePayHistory = await _EmployeePayHistoryRepository.EmployeePayHistories.Where(entity => entity.EmployeeID == data.FirstOrDefault().EmployeeID).ToListAsync();


            Assert.NotNull(_EmployeePayHistory);
            return _EmployeePayHistory;
        }

	}
}
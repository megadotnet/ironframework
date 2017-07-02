// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBOTests.cs" company="Megadotnet">
// Copyright (c) 2010-2015 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The AddressTests
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
using Ploeh.AutoFixture.Xunit2;
using UnitTest.Util;
using System.Threading.Tasks;
using DataTransferObject;
using BusinessObject;
using DataAccessObject;
using BusinessObject.Util;
using Moq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using IronFramework.Utility.UI;
	
namespace UnitTest.GenreateBOTests
{   
    /// <summary>
    /// Address Tests object
    /// </summary>
	public partial class AddressBOTests
	{       
        #region BoTest

        /// <summary>
        /// Tests the add.
        /// </summary>
        /// <param name="_AddressDto">The Address dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestAdd(AddressDto _AddressDto)
        {
            IAddressBO _AddressBO = new AddressBO(new FakeAddressConverter());
            bool hasAdded=_AddressBO.CreateEntiy(_AddressDto);
            Assert.True(hasAdded);
        }

	    /// <summary>
        ///GetEntiyByPK
        /// </summary>
        /// <param name="pkid">The PK int</param>
        [Theory, AutoData]
        public void TestGetEntiyByPK(Int32 pkid)
        {
            IAddressBO _AddressBO = new AddressBO(new FakeAddressConverter());
            var dtoEntity=new AddressDto(){AddressID=pkid};
            var dbResult = _AddressBO.GetEntiyByPK(dtoEntity);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_AddressDto">The _Address dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindAll(AddressDto _AddressDto)
        {
            IAddressBO _AddressBO = new AddressBO(new AddressConverter());
		    bool hasAdded = _AddressBO.CreateEntiy(_AddressDto);
            var dbResult=_AddressBO.FindAll(new PagedList<AddressDto> {_AddressDto});
            Assert.NotNull(dbResult);
		    Assert.True(dbResult.Total>0);
        }

		/// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_AddressDto">The _Address dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindEnties(AddressDto _AddressDto)
        {
            IAddressBO _AddressBO = new AddressBO(new AddressConverter());
		    bool hasAdded = _AddressBO.CreateEntiy(_AddressDto);
            var dbResult=_AddressBO.FindEnties(new PagedList<AddressDto> {_AddressDto});
            Assert.NotNull(dbResult);
			Assert.True(dbResult.Total>0);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_AddressDto">The _Address dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindEntiesWithSimplePaging(AddressDto _AddressDto)
        {
            IAddressBO _AddressBO = new AddressBO(new AddressConverter());
			bool hasAdded = _AddressBO.CreateEntiy(_AddressDto);
            var dbResult = _AddressBO.FindEnties(1, 10);
            Assert.NotNull(dbResult);
			Assert.True(dbResult.Count>0);
        }

		/// <summary>
        /// TestUpdateEntiyWithGet
        /// </summary>
        /// <param name="_AddressDto"></param>
        [Theory, AutoData, AutoRollback]
        public void TestUpdateEntiyWithGet(AddressDto _AddressDto)
        {
            IAddressBO _AddressBO = new AddressBO(new FakeAddressConverter());
            var dbResult = _AddressBO.UpdateEntiyWithGet(_AddressDto);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the update with attach entiy.
        /// </summary>
        /// <param name="_AddressDto">The Address.</param>
        [Theory, AutoData, AutoRollback]
        public void TestUpdateWithAttachEntiy(AddressDto _AddressDto)
        {
            IAddressBO _AddressBO = new AddressBO(new FakeAddressConverter());
            bool isUpdated = _AddressBO.UpdateWithAttachEntiy(_AddressDto);
            Assert.True(isUpdated);
        }

        /// <summary>
        /// Tests the delete with attach entiy.
        /// </summary>
        /// <param name="_AddressDto">The Address dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestDeleteWithAttachEntiy(AddressDto _AddressDto)
        {
            IAddressBO _AddressBO = new AddressBO(new FakeAddressConverter());
            bool isDeleted = _AddressBO.DeleteWithAttachEntiy(_AddressDto);
            Assert.True(isDeleted);
        }

		/// <summary>
        /// TestDeleteEntiy
        /// </summary>
        /// <param name="_AddressDto">_AddressDto</param>
        [Theory, AutoData, AutoRollback]
        public void TestDeleteEntiy(AddressDto _AddressDto)
        {
            IAddressBO _AddressBO = new AddressBO(new FakeAddressConverter());
            bool isDeleted = _AddressBO.DeleteEntiy(_AddressDto);
            Assert.True(isDeleted);
        }

        #endregion

        /// <summary>
        /// Tests the Address repository add.
        /// </summary>
        /// <param name="_Address">The _ Address.</param>
        [Theory, AutoData, AutoRollback]
        public void TestAddressRepositoryAdd(Address _Address)
        {
            var _AddressRepository = RepositoryHelper.GetAddressRepository();
            _AddressRepository.Add(_Address);
            _AddressRepository.Save();
        }

        /// <summary>
        /// Tests the Address repository get.
        /// </summary>
        /// <param name="_AddressId">The _ Address identifier.</param>
        [Theory, AutoData]
        public void TestAddressRepositoryGet(int  _AddressId)
        {
            var _AddressRepository = RepositoryHelper.GetAddressRepository();
            var _Address=_AddressRepository.Repository.Find(entity=>entity.AddressID==_AddressId);
            Assert.NotNull(_Address);
        }

		/// <summary>
        /// Tests the Address repository Delete.
        /// </summary>
        /// <param name="_Address">The _ Address entity.</param>
        [Theory, AutoData, AutoRollback]
        public void TestAddressRepositoryDelete(Address _Address)
        {
            var _AddressRepository = RepositoryHelper.GetAddressRepository();
           _AddressRepository.Repository.Delete(_Address);
           _AddressRepository.Save();
        }

        /// <summary>
        /// TestAddressRepositoryFindAsyc
        /// </summary>
        /// <param name="_AddressId"></param>
        /// <returns></returns>
        [Theory, AutoData]
        public async Task<IEnumerable<Address>> TestAddressRepositoryFindAsyc(List<Address> _AddressModel)
        {
		    var data = _AddressModel.AsQueryable();
            var mockSet = new Mock<DbSet<Address>>();
            mockSet.As<IDbAsyncEnumerable<Address>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Address>(data.GetEnumerator()));

            mockSet.As<IQueryable<Address>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Address>(data.Provider));

            mockSet.As<IQueryable<Address>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Address>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Address>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AdventureWorksEntities>();
            mockContext.Setup(c => c.Addresses).Returns(mockSet.Object);
		
            //var mockObjectContextAdapter = new Mock<IObjectContextAdapter>();
            //mockObjectContextAdapter.Setup(c => c.ObjectContext).Returns(mockContext);

            //var objectcontext = ((IObjectContextAdapter)mockContext.Object).ObjectContext;

            //var _AddressRepository = RepositoryHelper.GetAddressRepository(dbcontext.Object);
            //var _Address = await _AddressRepository.Repository.FindAsync(entity => entity.AddressID == data.FirstOrDefault().AddressID);

            var _AddressRepository = mockContext.Object;
            var _Address = await _AddressRepository.Addresses.Where(entity => entity.AddressID == data.FirstOrDefault().AddressID).ToListAsync();


            Assert.NotNull(_Address);
            return _Address;
        }

	}
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactBOTests.cs" company="Megadotnet">
// Copyright (c) 2010-2015 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The ContactTests
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
    /// Contact Tests object
    /// </summary>
	public partial class ContactBOTests
	{       
        #region BoTest

        /// <summary>
        /// Tests the add.
        /// </summary>
        /// <param name="_ContactDto">The Contact dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestAdd(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO(new FakeContactConverter());
            bool hasAdded=_ContactBO.CreateEntiy(_ContactDto);
            Assert.True(hasAdded);
        }

	    /// <summary>
        ///GetEntiyByPK
        /// </summary>
        /// <param name="pkid">The PK int</param>
        [Theory, AutoData]
        public void TestGetEntiyByPK(Int32 pkid)
        {
            var _ContactBO = new ContactBO(new FakeContactConverter());
            var dtoEntity=new ContactDto(){ContactID=pkid};
            var dbResult = _ContactBO.GetEntiyByPK(dtoEntity);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_ContactDto">The _Contact dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindAll(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO(new ContactConverter());
		    bool hasAdded = _ContactBO.CreateEntiy(_ContactDto);
            var dbResult=_ContactBO.FindAll(_ContactDto);
            Assert.NotNull(dbResult);
		    Assert.True(dbResult.Total>0);
        }

		/// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_ContactDto">The _Contact dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindEnties(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO(new ContactConverter());
		    bool hasAdded = _ContactBO.CreateEntiy(_ContactDto);
            var dbResult=_ContactBO.FindEnties(_ContactDto);
            Assert.NotNull(dbResult);
			Assert.True(dbResult.Total>0);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_ContactDto">The _Contact dto.</param>
        [Theory, AutoData,AutoRollback]
        public void TestFindEntiesWithSimplePaging(ContactDto _ContactDto)
        {
             var _ContactBO = new ContactBO(new ContactConverter());
			bool hasAdded = _ContactBO.CreateEntiy(_ContactDto);
            var dbResult = _ContactBO.FindEnties(1, 10);
            Assert.NotNull(dbResult);
			Assert.True(dbResult.Count>0);
        }

		/// <summary>
        /// TestUpdateEntiyWithGet
        /// </summary>
        /// <param name="_ContactDto"></param>
        [Theory, AutoData, AutoRollback]
        public void TestUpdateEntiyWithGet(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO(new FakeContactConverter());
            var dbResult = _ContactBO.UpdateEntiyWithGet(_ContactDto);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the update with attach entiy.
        /// </summary>
        /// <param name="_ContactDto">The Contact.</param>
        [Theory, AutoData, AutoRollback]
        public void TestUpdateWithAttachEntiy(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO(new FakeContactConverter());
            bool isUpdated = _ContactBO.UpdateWithAttachEntiy(_ContactDto);
            Assert.True(isUpdated);
        }

        /// <summary>
        /// Tests the delete with attach entiy.
        /// </summary>
        /// <param name="_ContactDto">The Contact dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestDeleteWithAttachEntiy(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO(new FakeContactConverter());
            bool isDeleted = _ContactBO.DeleteWithAttachEntiy(_ContactDto);
            Assert.True(isDeleted);
        }

		/// <summary>
        /// TestDeleteEntiy
        /// </summary>
        /// <param name="_ContactDto">_ContactDto</param>
        [Theory, AutoData, AutoRollback]
        public void TestDeleteEntiy(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO(new FakeContactConverter());
            bool isDeleted = _ContactBO.DeleteEntiy(_ContactDto);
            Assert.True(isDeleted);
        }

        #endregion

        /// <summary>
        /// Tests the Contact repository add.
        /// </summary>
        /// <param name="_Contact">The _ Contact.</param>
        [Theory, AutoData, AutoRollback]
        public void TestContactRepositoryAdd(Contact _Contact)
        {
            var _ContactRepository = RepositoryHelper.GetContactRepository();
            _ContactRepository.Add(_Contact);
            _ContactRepository.Save();
        }

        /// <summary>
        /// Tests the Contact repository get.
        /// </summary>
        /// <param name="_ContactId">The _ Contact identifier.</param>
        [Theory, AutoData]
        public void TestContactRepositoryGet(int  _ContactId)
        {
            var _ContactRepository = RepositoryHelper.GetContactRepository();
            var _Contact=_ContactRepository.Repository.Find(entity=>entity.ContactID==_ContactId);
            Assert.NotNull(_Contact);
        }

		/// <summary>
        /// Tests the Contact repository Delete.
        /// </summary>
        /// <param name="_Contact">The _ Contact entity.</param>
        [Theory, AutoData, AutoRollback]
        public void TestContactRepositoryDelete(Contact _Contact)
        {
            var _ContactRepository = RepositoryHelper.GetContactRepository();
           _ContactRepository.Repository.Delete(_Contact);
           _ContactRepository.Save();
        }

        /// <summary>
        /// TestContactRepositoryFindAsyc
        /// </summary>
        /// <param name="_AddressId"></param>
        /// <returns></returns>
        [Theory, AutoData]
        public async Task<IEnumerable<Contact>> TestContactRepositoryFindAsyc(List<Contact> _ContactModel)
        {
		    var data = _ContactModel.AsQueryable();
            var mockSet = new Mock<DbSet<Contact>>();
            mockSet.As<IDbAsyncEnumerable<Contact>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Contact>(data.GetEnumerator()));

            mockSet.As<IQueryable<Contact>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Contact>(data.Provider));

            mockSet.As<IQueryable<Contact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Contact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Contact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AdventureWorksEntities>();
            mockContext.Setup(c => c.Contacts).Returns(mockSet.Object);
		
            //var mockObjectContextAdapter = new Mock<IObjectContextAdapter>();
            //mockObjectContextAdapter.Setup(c => c.ObjectContext).Returns(mockContext);

            //var objectcontext = ((IObjectContextAdapter)mockContext.Object).ObjectContext;

            //var _AddressRepository = RepositoryHelper.GetAddressRepository(dbcontext.Object);
            //var _Address = await _AddressRepository.Repository.FindAsync(entity => entity.AddressID == data.FirstOrDefault().AddressID);

            var _ContactRepository = mockContext.Object;
            var _Contact = await _ContactRepository.Contacts.Where(entity => entity.ContactID == data.FirstOrDefault().ContactID).ToListAsync();


            Assert.NotNull(_Contact);
            return _Contact;
        }

	}
}
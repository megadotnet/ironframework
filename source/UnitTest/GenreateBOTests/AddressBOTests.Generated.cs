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
using Ploeh.AutoFixture.Xunit;
using DataTransferObject;
using BusinessObject;
using DataAccessObject;
	
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
            var _AddressBO = new AddressBO();
            bool hasAdded=_AddressBO.CreateEntiy(_AddressDto);
            Assert.True(hasAdded);
        }

	    /// <summary>
        ///GetEntiyByPK
        /// </summary>
        /// <param name="pkid">The PK int</param>
        [Theory, AutoData]
        public void TestGetEntiyByPK(int pkid)
        {
            var _AddressBO = new AddressBO();
            var dbResult = _AddressBO.GetEntiyByPK(pkid);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_AddressDto">The _Address dto.</param>
        [Theory, AutoData]
        public void TestFindAll(AddressDto _AddressDto)
        {
            var _AddressBO = new AddressBO();
            var dbResult=_AddressBO.FindAll(_AddressDto);
            Assert.NotNull(dbResult);
		    Assert.True(dbResult.total>0);
        }

		/// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_AddressDto">The _Address dto.</param>
        [Theory, AutoData]
        public void TestFindEnties(AddressDto _AddressDto)
        {
            var _AddressBO = new AddressBO();
            var dbResult=_AddressBO.FindEnties(_AddressDto);
            Assert.NotNull(dbResult);
			Assert.True(dbResult.total>0);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_AddressDto">The _Address dto.</param>
        [Theory, AutoData]
        public void TestFindEntiesWithSimplePaging(int? pageIndex, int pageSize)
        {
             var _AddressBO = new AddressBO();
            var dbResult = _AddressBO.FindEnties(pageIndex, pageSize);
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
            var _AddressBO = new AddressBO();
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
            var _AddressBO = new AddressBO();
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
            var _AddressBO = new AddressBO();
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
            var _AddressBO = new AddressBO();
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



	}
}
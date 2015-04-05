// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactTests.cs" company="Megadotnet">
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
using Xunit;
using Xunit.Extensions;
using Ploeh.AutoFixture.Xunit;
using DataTransferObject;
using BusinessObject;
	
namespace UnitTest.GenreateBOTests
{   
    /// <summary>
    /// Contact Tests object
    /// </summary>
	public partial class ContactTests
	{       
        /// <summary>
        /// Tests the add.
        /// </summary>
        /// <param name="_ContactDto">The Contact dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestAdd(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO();
            bool hasAdded=_ContactBO.CreateEntiy(_ContactDto);
            Assert.True(hasAdded);
        }

        /// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_ContactDto">The _Contact dto.</param>
        [Theory, AutoData]
        public void TestFindAll(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO();
            var dbResult=_ContactBO.FindAll(_ContactDto);
            Assert.NotNull(dbResult);
        }

		/// <summary>
        /// Tests the get.
        /// </summary>
        /// <param name="_ContactDto">The _Contact dto.</param>
        [Theory, AutoData]
        public void TestFindEnties(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO();
            var dbResult=_ContactBO.FindEnties(_ContactDto);
            Assert.NotNull(dbResult);
        }

        /// <summary>
        /// Tests the update with attach entiy.
        /// </summary>
        /// <param name="_ContactDto">The Contact.</param>
        [Theory, AutoData, AutoRollback]
        public void TestUpdateWithAttachEntiy(ContactDto _ContactDto)
        {
            var _ContactBO = new ContactBO();
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
            var _ContactBO = new ContactBO();
            bool isDeleted = _ContactBO.DeleteWithAttachEntiy(_ContactDto);
            Assert.True(isDeleted);
        }


	}
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressTests.cs" company="Megadotnet">
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
using Xunit;
using Xunit.Extensions;
using Ploeh.AutoFixture.Xunit;
using DataTransferObject;
using BusinessObject;
	
namespace UnitTest.GenreateBOTests
{   
    /// <summary>
    /// Address Tests object
    /// </summary>
	public partial class AddressTests
	{       
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
        /// Tests the get.
        /// </summary>
        /// <param name="_AddressDto">The _Address dto.</param>
        [Theory, AutoData, AutoRollback]
        public void TestGet(AddressDto _AddressDto)
        {
            var _AddressBO = new AddressBO();
            var dbResult=_AddressBO.FindAll(_AddressDto);
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


	}
}
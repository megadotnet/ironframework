// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestIStoredProcedureFunctionsDAO.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The test i stored procedure functions dao.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using DataAccessObject;
    using DataAccessObject.Repositories;

    using Xunit;

    /// <summary>
    /// The test i stored procedure functions dao.
    /// </summary>
    public class TestIStoredProcedureFunctionsDAO
    {
        #region Public Methods

        /// <summary>
        /// The test update employee login.
        /// </summary>
        [Fact]
        public void TestUpdateEmployeeLogin()
        {
            //arrange
            var storedProcedureFunctionsDao = ObjectFactory.GetInstance<IStoredProcedureFunctionsDAO>();

            //assert
            Assert.NotNull(storedProcedureFunctionsDao);

        }

        #endregion
    }
}
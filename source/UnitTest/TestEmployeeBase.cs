// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEmployeeBase.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   This is unit test base class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using System;
    using System.Transactions;

    using BusinessEntiies;
    using DataAccessObject;

    /// <summary>
    /// This is unit test base class
    /// </summary>
    public class TestEmployeeBase
    {
        #region Constants and Fields
        /// <summary>
        /// T-sql statement
        /// </summary>
        private static readonly string DISABLETRIGGERTSQL = @"declare @flag bit
                                        select @flag=is_disabled from sys.triggers where name='dEmployee'
                                        if @flag=0
                                        ALTER TABLE [HumanResources].[Employee] DISABLE TRIGGER [dEmployee]";

      

        #endregion

        #region Public Methods

        /// <summary>
        /// The create new employee.
        /// </summary>
        /// <returns>
        /// </returns>
        public Employee CreateNewEmployee()
        {
            var employee = new Employee
                {
                    ManagerID = 2, 
                    ContactID = 3, 
                    Title = "Developer", 
                    BirthDate = new DateTime(1965, 1, 1, 0, 0, 0), 
                    HireDate = DateTime.Now, 
                    Gender = "M", 
                    MaritalStatus = "M", 
                    ModifiedDate = DateTime.Now, 
                    NationalIDNumber = "2", 
                    rowguid = new Guid(), 
                    CurrentFlag = true, 
                    VacationHours = 2, 
                    SickLeaveHours = 3, 
                    SalariedFlag = false, 
                    LoginID = "adventure-works\\peter"
                };
            return employee;
        }

        /// <summary>
        /// The tear set down.
        /// </summary>
        public void TearSetDown()
        {

        }


        /// <summary>
        /// Sets up.
        /// </summary>
        /// <param name="disableTrigger">if set to <c>true</c> [disable trigger].</param>
        public void SetUp(bool disableTrigger)
        {

            //TODO: Need deal with transactionscope issue with wcf
            if (disableTrigger)
            {
                // Disable delete TRIGGER on the Employee table
                var objectcontext = ObjectFactory.GetInstance<IObjectContext>();
                objectcontext.ExecuteStoreCommand(DISABLETRIGGERTSQL);
            }
        }

        /// <summary>
        /// Sets up.
        /// </summary>
        public void SetUp()
        {
            SetUp(true);
        }

        #endregion
    }
}
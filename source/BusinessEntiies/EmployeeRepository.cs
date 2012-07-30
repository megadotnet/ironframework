// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The employee repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using BusinessEntiies;

    using IronFramework.Utility.UI;

    /// <summary>
    /// The employee repository.
    /// </summary>
    public partial class EmployeeRepository
    {
        #region Public Methods

        /// <summary>
        /// Gets the by pk.
        /// </summary>
        /// <param name="employeeId">The employee id.</param>
        /// <returns></returns>
        public Employee GetByPk(int employeeId)
        {
            return this._repository.Single(e => e.EmployeeID == employeeId);
        }

        #endregion
    }
}
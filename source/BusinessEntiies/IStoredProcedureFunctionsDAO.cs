// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStoredProcedureFunctionsDAO.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The i stored procedure functions dao.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject.Repositories
{
    using System;

     /// <summary>
    /// The interface of stored procedure functions data access object
    /// </summary>
    public interface IStoredProcedureFunctionsDAO
    {
   
#region Function Imports

	    void UpdateEmployeeLogin(Nullable<int> employeeID, Nullable<int> managerID, string loginID, string title, Nullable<System.DateTime> hireDate, Nullable<bool> currentFlag);

#endregion

 
    }
}

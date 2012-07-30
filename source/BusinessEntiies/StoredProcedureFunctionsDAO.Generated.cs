// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoredProcedureFunctionsDAO.cs" company="Megdotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The stored procedure functions dao.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject.Repositories
{
    using System;
    using System.Data.Objects;

    /// <summary>
    /// The stored procedure functions dao.
    /// </summary>
    public partial class StoredProcedureFunctionsDAO : IStoredProcedureFunctionsDAO
    {
	    private readonly IObjectContext  dbObjectcontext;
	   
        public StoredProcedureFunctionsDAO(IObjectContext  _dbObjectcontext)
        {
            dbObjectcontext = _dbObjectcontext;
        }


     #region Function Imports

	public void UpdateEmployeeLogin(Nullable<int> employeeID, Nullable<int> managerID, string loginID, string title, Nullable<System.DateTime> hireDate, Nullable<bool> currentFlag)
	{
		ObjectParameter employeeIDParameter;
		if (employeeID.HasValue)
		{
			employeeIDParameter = new ObjectParameter("EmployeeID", employeeID);
		}
		else
		{
			employeeIDParameter = new ObjectParameter("EmployeeID", typeof(int));
		}
		
		ObjectParameter managerIDParameter;
		if (managerID.HasValue)
		{
			managerIDParameter = new ObjectParameter("ManagerID", managerID);
		}
		else
		{
			managerIDParameter = new ObjectParameter("ManagerID", typeof(int));
		}
		
		ObjectParameter loginIDParameter;
		if (loginID != null)
		{
			loginIDParameter = new ObjectParameter("LoginID", loginID);
		}
		else
		{
			loginIDParameter = new ObjectParameter("LoginID", typeof(string));
		}
		
		ObjectParameter titleParameter;
		if (title != null)
		{
			titleParameter = new ObjectParameter("Title", title);
		}
		else
		{
			titleParameter = new ObjectParameter("Title", typeof(string));
		}
		
		ObjectParameter hireDateParameter;
		if (hireDate.HasValue)
		{
			hireDateParameter = new ObjectParameter("HireDate", hireDate);
		}
		else
		{
			hireDateParameter = new ObjectParameter("HireDate", typeof(System.DateTime));
		}
		
		ObjectParameter currentFlagParameter;
		if (currentFlag.HasValue)
		{
			currentFlagParameter = new ObjectParameter("CurrentFlag", currentFlag);
		}
		else
		{
			currentFlagParameter = new ObjectParameter("CurrentFlag", typeof(bool));
		}
		
		     dbObjectcontext.ExecuteFunction("UpdateEmployeeLogin", employeeIDParameter, managerIDParameter, loginIDParameter, titleParameter, hireDateParameter, currentFlagParameter);
	}

#endregion
    }
}

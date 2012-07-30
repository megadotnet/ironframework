// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeBoService.svc.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The wcf business object data service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BoService
{
    using BusinessEntiies;

    using BusinessObject;

    using IronFramework.Utility;
    using IronFramework.Utility.UI;

    /// <summary>
    /// The employee bo service.
    /// </summary>
    public class EmployeeBoService : IEmployeeBoService
    {
        #region Constants and Fields

        /// <summary>
        /// The ebo.
        /// </summary>
        private readonly IEmployeeBusinessObject ebo;
        private readonly IContactBusinessObject contactebo;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBoService"/> class.
        /// </summary>
        public EmployeeBoService()
        {
            this.ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            this.contactebo = ServiceFactory.GetInstance<IContactBusinessObject>();
        }

        #endregion

        #region Implemented Interfaces

        #region IEmployeeBoService

        /// <summary>
        /// The create employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The create employee.
        /// </returns>
        public bool CreateEmployee(Employee employee)
        {
            return this.ebo.CreateEmployee(employee);
        }

        /// <summary>
        /// The create employee 2.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The create employee 2.
        /// </returns>
        public int CreateEmployee2(Employee employee)
        {
            this.ebo.CreateEmployee(employee);
            return employee.EmployeeID;
        }

        /// <summary>
        /// The del employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The del employee.
        /// </returns>
        public bool DelEmployee(Employee employee)
        {
            this.ebo.AttachEmployee(employee);
            return this.ebo.DelEmployee(employee);
        }

        /// <summary>
        /// The find employee by title.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="totalcount">
        /// The totalcount.
        /// </param>
        /// <returns>
        /// </returns>
        public PagedList<Employee> FindEmployeeByTitle(string title, int? pageIndex, int pageSize, out int totalcount)
        {
            PagedList<Employee> datalists = this.ebo.FindByTitle(title, pageIndex, pageSize);
            totalcount = datalists.TotalCount;
            return datalists;
        }

        /// <summary>
        /// The get employee.
        /// </summary>
        /// <param name="pid">
        /// The pid.
        /// </param>
        /// <returns>
        /// </returns>
        public Employee GetEmployee(int pid)
        {
            return this.ebo.GetEmployee(pid);
        }

        /// <summary>
        /// The update employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The update employee.
        /// </returns>
        public bool UpdateEmployee(Employee employee)
        {
            return this.ebo.UpdateEmployee2(employee);
        }


        /// <summary>
        /// Gets the paged list contact.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalcount">The totalcount.</param>
        /// <returns>PagedList Contact</returns>
        public PagedList<Contact> GetPagedListContact(int? pageIndex, int pageSize, out int totalcount)
        {
            PagedList<Contact> datalists = this.contactebo.FindContacts(pageIndex, pageSize);
            totalcount = datalists.TotalCount;
            return datalists;
        }

        #endregion

        #endregion


      
    }
}
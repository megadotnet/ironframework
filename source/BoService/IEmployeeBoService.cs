// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmployeeBoService.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The i employee bo service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BoService
{
    using System.ServiceModel;

    using BusinessEntities;

    using IronFramework.Utility;
    using IronFramework.Utility.UI;

    /// <summary>
    /// The i employee bo service.
    /// </summary>
    [ServiceContract]
    public interface IEmployeeBoService
    {
        #region Public Methods

        /// <summary>
        /// The create employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The create employee.
        /// </returns>
        [OperationContract]
        [ApplyDataContractResolver]
        bool CreateEmployee(Employee employee);

        /// <summary>
        /// The create employee 
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        ///new employee Id
        /// </returns>
        [OperationContract]
        [ApplyDataContractResolver]
        int CreateEmployee2(Employee employee);

        /// <summary>
        /// The del employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The del employee.
        /// </returns>
        [OperationContract]
        [ApplyDataContractResolver]
        [CyclicReferencesAware(true)]
        bool DelEmployee(Employee employee);

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
        [OperationContract]
        [ApplyDataContractResolver]
        PagedList<Employee> FindEmployeeByTitle(string title, int? pageIndex, int pageSize, out int totalcount);

        /// <summary>
        /// The get employee.
        /// </summary>
        /// <param name="pid">
        /// The pid.
        /// </param>
        /// <returns>
        /// </returns>
        [OperationContract]
        [ApplyDataContractResolver]
        Employee GetEmployee(int pid);

        /// <summary>
        /// The update employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The update employee.
        /// </returns>
        [OperationContract]
        [ApplyDataContractResolver]
        bool UpdateEmployee(Employee employee);


        /// <summary>
        /// Gets the paged list contact.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalcount">The totalcount.</param>
        /// <returns>PagedList Contact</returns>
        [OperationContract]
        [ApplyDataContractResolver]
        PagedList<Contact> GetPagedListContact(int? pageIndex, int pageSize, out int totalcount);

        #endregion
    }
}
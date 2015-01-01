// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRESTEmployeeService.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The interface of REST employee CRUD service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BoService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using System.ServiceModel.Web;
    using BusinessEntiies;
    using IronFramework.Utility;

    /// <summary>
    /// Interface of  REST Employee DTO Service CRUD
    /// </summary>
    /// <remarks>It seems ApplyDataContractResolver does not work with WCF webHttpBinding</remarks>
    [ServiceContract]
    public interface IRESTEmployeeService
    {
        #region Public method
        /// <summary>
        /// Creates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>if success return true else false</returns>
        [OperationContract]
        [ApplyDataContractResolver]
        [WebInvoke(UriTemplate = "Create", Method = "POST")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int Create(EmployeeDto employee);

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>if success return true else false</returns>
        [OperationContract]
        [ApplyDataContractResolver]
        [CyclicReferencesAware(true)]
        [WebInvoke(UriTemplate = "/Del?id={id}", Method = "DELETE")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool Delete(int id);

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>single Emploee entity</returns>
        [OperationContract]
        [WebGet(UriTemplate = "/Get?id={id}")]
        [ApplyDataContractResolver]
        [CyclicReferencesAware(true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        EmployeeDto Get(int id);


        /// <summary>
        /// Updates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>if success return true else false</returns>
        [OperationContract]
        [ApplyDataContractResolver]
        [WebInvoke(UriTemplate = "Update", Method = "PUT")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool Update(EmployeeDto employee);
    } 
    #endregion
}

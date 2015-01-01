// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RESTEmployeeService.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The REST employee CRUD service.
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
    using BusinessEntiies;
    using BusinessObject;
    using IronFramework.Utility;

    /// <summary>
    ///  Employee REST CRUD Service
    /// </summary>
    public class RESTEmployeeService : IRESTEmployeeService
    {

        /// <summary>
        /// IEmployeeBusinessObject
        /// </summary>
        private readonly IEmployeeBusinessObject ebo;
        private readonly ITypeAdapter enityadapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="RESTEmployeeService"/> class.
        /// </summary>
        public RESTEmployeeService()
        {
            this.ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>("NoOLazyloadedAndProxyCreated");
            this.enityadapter = new EmployeeAdapter();
        }

        /// <summary>
        /// Creates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>if success return true else false</returns>
        [OperationBehavior(TransactionAutoComplete = true,TransactionScopeRequired = true)]
        public int Create(EmployeeDto employee)
        {
            var entity = enityadapter.Transform<EmployeeDto,Employee>(employee);
            this.ebo.CreateEmployee(entity);
            return entity.EmployeeID;
        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>if success return true else false</returns>
        public bool Delete(int id)
        {
            var employee = new EmployeeDto { EmployeeID = id };
            var entity = enityadapter.Transform<EmployeeDto, Employee>(employee);
            this.ebo.AttachEmployee(entity);
            return this.ebo.DelEmployee(entity);
        }

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>single Emploee entity</returns>
        public EmployeeDto Get(int id)
        {
            var tempe=this.ebo.GetEmployee(id);
            return enityadapter.Transform<Employee,EmployeeDto>(tempe);
        }

        /// <summary>
        /// Updates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>if success return true else false</returns>
        public bool Update(EmployeeDto employee)
        {
            var entity = enityadapter.Transform<EmployeeDto, Employee>(employee);
            return this.ebo.UpdateEmployeeByAttachEntity(entity);
        }
    }
}

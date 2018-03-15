// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeBusnessObject.Generated.cs" company="Megadonet">
//   Iron Framework
// </copyright>
// <summary>
//   EmployeeBusinessObject partial class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessObject
{
    using System.Linq;

    using BusinessEntities;

    using DataAccessObject;
    using IronFramework.Common.Data.EntityFramework;
    using IronFramework.Utility.UI;

    /// <summary>
    /// Employee Business Object
    /// </summary>
    public partial class EmployeeBusinessObject : IEmployeeBusinessObject
    {
        #region Constants and Fields

        /// <summary>
        /// The employee repository.
        /// </summary>
        private readonly EmployeeRepository employeeRepository;
        private readonly IObjectContext context;
        private readonly IUnitOfWork uow;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBusinessObject"/> class.
        /// </summary>
        public EmployeeBusinessObject()
        {
            this.context = RepositoryHelper.GetDbContext();
            this.uow = RepositoryHelper.GetUnitOfWork(context);
            this.employeeRepository = RepositoryHelper.GetEmployeeRepository(context);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBusinessObject"/> class.
        /// </summary>
        /// <param name="lazyloaded">if set to <c>true</c> [lazyloaded].</param>
        /// <param name="proxycreated">if set to <c>true</c> [proxycreated].</param>
        public EmployeeBusinessObject(bool lazyloaded, bool proxycreated)
        {
            this.context = RepositoryHelper.GetDbContext();

            /*  http://msdn.microsoft.com/en-us/library/dd456853.aspx
                 Windows Communication Foundation (WCF) cannot directly serialize or deserialize proxies because the DataContractSerializer
                  can only serialize and deserialize known types, and proxy types are not known types. 
                  When you need to serialize POCO entities, disable proxy creation or use the ProxyDataContractResolver class 
                  to serialize proxy objects as the original POCO entities. 
                  To disable proxy creation, set the ProxyCreationEnabled property to false.  */

            ///we have test use ProxyDataContractResolver class is not work with webHttp bind in WCF. only set them as false.
            this.context.LazyLoadingEnabled = lazyloaded;
            this.context.ProxyCreationEnabled = proxycreated;

            this.uow = RepositoryHelper.GetUnitOfWork(context);
            this.employeeRepository = RepositoryHelper.GetEmployeeRepository(context);
        }

        #endregion

        #region Implemented Interfaces

        #region IEmployeeBusinessObject

        /// <summary>
        /// Creates the employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The create employee.
        /// </returns>
        public bool CreateEmployee(Employee employee)
        {
            this.employeeRepository.Add(employee);
            this.employeeRepository.Save();
            return true;
        }

        /// <summary>
        /// Dels the employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The del employee.
        /// </returns>
        public bool DelEmployee(Employee employee)
        {
            this.employeeRepository.Delete(employee);
            this.employeeRepository.Save();
            return true;
        }

        /// <summary>
        /// Get the employee.
        /// </summary>
        /// <param name="pid">
        /// The pid.
        /// </param>
        /// <returns>Single entity</returns>
        public Employee GetEmployee(int pid)
        {
            return employeeRepository.GetByPk(pid);
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The update employee.
        /// </returns>
        public bool UpdateEmployee(Employee employee)
        {
            //To avoid this error when update record
            // "The conversion of a datetime2 data type to a datetime data type resulted in an out-of-range value. The statement has been terminated."
            // exec sp_executesql N'update [HumanResources].[Employee]
            employee.ModifiedDate = System.DateTime.Now;
            employee.rowguid = System.Guid.NewGuid();
            this.employeeRepository.Save();
            return true;
        }

        /// <summary>
        /// Updates the employee 
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The update employee 2.
        /// </returns>
        /// <remarks>
        /// For WCF,because wcf cannot persistent ef4 objectcontext
        /// we also need change entity state then save it. Reference book 'Programming Entity framework 4'
        /// </remarks>
        public bool UpdateEmployeeByAttachEntity(Employee employee)
        {
            IObjectContext context = RepositoryHelper.GetDbContext();
            IUnitOfWork uow = RepositoryHelper.GetUnitOfWork(context);
            EmployeeRepository employRepository = RepositoryHelper.GetEmployeeRepository(context);

            employRepository.Attach(employee);
            employee.rowguid = System.Guid.NewGuid();
            employee.State = State.Modified;
            //To avoid this error when update record
            // "The conversion of a datetime2 data type to a datetime data type resulted in an out-of-range value. The statement has been terminated."
            // exec sp_executesql N'update [HumanResources].[Employee]
            employee.ModifiedDate = System.DateTime.Now;
            context.ChangeObjectState(employee, StateHelpers.GetEquivalentEntityState(employee.State));
            uow.Save();

            return true;
        }

        #endregion

        #endregion
    }
}
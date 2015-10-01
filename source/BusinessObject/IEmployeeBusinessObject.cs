// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmployeeBusinessObject.cs" company="Megadotnet">
//   Iron Framework 
// </copyright>
// <summary>
//   The i employee business object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessObject
{
    using System.Linq;

    using BusinessEntities;

    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.PolicyInjection;
    using Microsoft.Practices.EnterpriseLibrary.Logging.PolicyInjection;
    using Microsoft.Practices.EnterpriseLibrary.Validation.PolicyInjection;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

    using IronFramework.Utility.UI;
    using IronFramework.Common.IOC.EntLib.CallHandler;

    /// <summary>
    /// The interface of employee business object
    /// </summary>
    public interface IEmployeeBusinessObject
    {
        #region Public Methods

        /// <summary>
        /// The attach employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The attach employee
        /// </returns>
        bool AttachEmployee(Employee employee);

        /// <summary>
        /// The create employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The create employee
        /// </returns>
        [ExceptionCallHandler("MyPolicy")]
        [TransactionScopeCallHandler]
        bool CreateEmployee(Employee employee);

        /// <summary>
        /// The del employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The del employee
        /// </returns>
        [ExceptionCallHandler("MyPolicy")]
        bool DelEmployee(Employee employee);

        /// <summary>
        /// The find by title
        /// </summary>
        /// <param name="title">
        /// The title
        /// </param>
        /// <param name="pageIndex">
        /// The page index
        /// </param>
        /// <param name="pageSize">
        /// The page size
        /// </param>
        /// <returns>
        /// collection of entity
        /// </returns>
        PagedList<Employee> FindByTitle(string title, int? pageIndex, int pageSize);

        /// <summary>
        /// The get all employee.
        /// </summary>
        /// <returns>Queryable employee</returns>
        IQueryable<Employee> GetAllEmployee();

        /// <summary>
        /// The get employee.
        /// </summary>
        /// <param name="pid">
        /// The pid.
        /// </param>
        /// <returns>
        /// Single entity
        /// </returns>
        [ValidationCallHandler]
        [LogCallHandler(BeforeMessage = "before GetEmployee", AfterMessage = "after GetEmployee", 
            IncludeCallStack = true)]
        //[CachingCallHandler(0, 10, 0, Order = 3)]
        Employee GetEmployee(
            [RangeValidator(1, RangeBoundaryType.Inclusive, int.MaxValue, RangeBoundaryType.Inclusive)] int pid);

        /// <summary>
        /// The update employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The update employee
        /// </returns>
        [ExceptionCallHandler("MyPolicy")]
        bool UpdateEmployee(Employee employee);

        /// <summary>
        /// The update employee 2.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The update employee
        /// </returns>
        [ExceptionCallHandler("MyPolicy")]
        bool UpdateEmployeeByAttachEntity(Employee employee);

        #endregion
    }
}
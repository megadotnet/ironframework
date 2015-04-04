// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeBusinessObject.cs" company="Megadonet">
//   Iron Framework
// </copyright>
// <summary>
//   EmployeeBusinessObject partial
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessObject
{
    using System.Linq;

    using BusinessEntities;

    using DataAccessObject;

    using IronFramework.Utility.UI;

    /// <summary>
    /// EmployeeBusinessObject partial
    /// </summary>
    public partial class EmployeeBusinessObject
    {
        #region Implemented Interfaces

        #region IEmployeeBusinessObject

        /// <summary>
        /// Attaches the employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The attach employee.
        /// </returns>
        public bool AttachEmployee(Employee employee)
        {
            this.employeeRepository.Attach(employee);
            return true;
        }

        /// <summary>
        /// The find by title.
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
        /// <returns>collection of employee
        /// </returns>
        public PagedList<Employee> FindByTitle(string title, int? pageIndex, int pageSize)
        {
            if (string.IsNullOrEmpty(title))
            {
                return this.employeeRepository.Repository.Find(null, e => e.EmployeeID, pageIndex, pageSize);
            }

            return this.employeeRepository.Repository.Find(e => e.Title.Contains(title), e => e.EmployeeID, pageIndex, pageSize);
        }

        /// <summary>
        /// Gets all employee.
        /// </summary>
        /// <returns>
        /// collection of employee as IQueryable
        /// </returns>
        public IQueryable<Employee> GetAllEmployee()
        {
            return RepositoryHelper.GetEmployeeRepository().Repository.All().AsQueryable();
        }

        #endregion

        #endregion
    }
}
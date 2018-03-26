using DataAccessObjectDotNetCore;
using IronFramework.Common.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectStandard.Service
{
    /// <summary>
    /// EmployeeService
    /// </summary>
    /// <seealso cref="BusinessObjectStandard.Service.Service{DataAccessObjectDotNetCore.Employee}" />
    /// <seealso cref="BusinessObjectStandard.Service.IEmployeeService" />
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public EmployeeService(IRepository<Employee> repository) : base(repository)
        {
        }
    }
}

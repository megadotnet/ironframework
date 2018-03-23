using DataAccessObjectDotNetCore;
using IronFramework.Common.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectStandard.Service
{
    public class EmployeeService : Service<Employee>
    {
        public EmployeeService(IRepository<Employee> repository) : base(repository)
        {
        }
    }
}

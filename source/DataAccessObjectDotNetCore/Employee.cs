using System;
using System.Collections.Generic;

namespace DataAccessObjectDotNetCore
{ 

    public partial class Employee
    {
        public Employee()
        {
            EmployeePayHistory = new HashSet<EmployeePayHistory>();
        }

        public int EmployeeId { get; set; }
        public string NationalIdnumber { get; set; }
        public int ContactId { get; set; }
        public string LoginId { get; set; }
        public int? ManagerId { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<EmployeePayHistory> EmployeePayHistory { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }
    }
}

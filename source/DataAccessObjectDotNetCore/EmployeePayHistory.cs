using System;
using System.Collections.Generic;

namespace DataAccessObjectDotNetCore
{
    public partial class EmployeePayHistory
    {
        public int EmployeeId { get; set; }
        public DateTime RateChangeDate { get; set; }
        public decimal Rate { get; set; }
        public byte PayFrequency { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

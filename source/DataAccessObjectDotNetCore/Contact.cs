using System;
using System.Collections.Generic;

namespace DataAccessObjectDotNetCore
{
    public partial class Contact
    {
        public Contact()
        {
            Employee = new HashSet<Employee>();
        }

        public int ContactId { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string EmailAddress { get; set; }
        public int EmailPromotion { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string AdditionalContactInfo { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}


using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects.DataClasses;

namespace BusinessEntities
{
	[MetadataType(typeof(AddressMetadata))]
	public partial class Address
	{
		internal sealed class AddressMetadata
		{
		
			[Required(ErrorMessage="Address is required")]
    		public Int32 AddressID { get; set; }

			[Required(ErrorMessage="Address Line1 is required")]
			[StringLength(60)]
    		public String AddressLine1 { get; set; }

			[StringLength(60)]
    		public String AddressLine2 { get; set; }

			[Required(ErrorMessage="City is required")]
			[StringLength(30)]
    		public String City { get; set; }

			[Required(ErrorMessage="State Province is required")]
    		public Int32 StateProvinceID { get; set; }

			[Required(ErrorMessage="Postal Code is required")]
			[StringLength(15)]
    		public String PostalCode { get; set; }

			[Required(ErrorMessage="rowguid is required")]
    		public Guid rowguid { get; set; }

			[Required(ErrorMessage="Modified Date is required")]
			[DataType(DataType.DateTime)]
    		public DateTime ModifiedDate { get; set; }

		}
	}
	
	[MetadataType(typeof(ContactMetadata))]
	public partial class Contact
	{
		internal sealed class ContactMetadata
		{
		
			[Required(ErrorMessage="Contact is required")]
    		public Int32 ContactID { get; set; }

			[Required(ErrorMessage="Name Style is required")]
    		public Boolean NameStyle { get; set; }

			[StringLength(8)]
    		public String Title { get; set; }

			[Required(ErrorMessage="First Name is required")]
			[StringLength(50)]
    		public String FirstName { get; set; }

			[StringLength(50)]
    		public String MiddleName { get; set; }

			[Required(ErrorMessage="Last Name is required")]
			[StringLength(50)]
    		public String LastName { get; set; }

			[StringLength(10)]
    		public String Suffix { get; set; }

			[StringLength(50)]
			[DataType(DataType.EmailAddress)]
    		public String EmailAddress { get; set; }

			[Required(ErrorMessage="Email Promotion is required")]
			[DataType(DataType.EmailAddress)]
    		public Int32 EmailPromotion { get; set; }

			[StringLength(25)]
			[DataType(DataType.PhoneNumber)]
    		public String Phone { get; set; }

			[Required(ErrorMessage="Password Hash is required")]
			[StringLength(128)]
    		public String PasswordHash { get; set; }

			[Required(ErrorMessage="Password Salt is required")]
			[StringLength(10)]
    		public String PasswordSalt { get; set; }

    		public String AdditionalContactInfo { get; set; }

			[Required(ErrorMessage="rowguid is required")]
    		public Guid rowguid { get; set; }

			[Required(ErrorMessage="Modified Date is required")]
			[DataType(DataType.DateTime)]
    		public DateTime ModifiedDate { get; set; }

    		public EntityCollection<Employee> Employees { get; set; }

		}
	}
	
	[MetadataType(typeof(EmployeeMetadata))]
	public partial class Employee
	{
		internal sealed class EmployeeMetadata
		{
		
			[Required(ErrorMessage="Employee is required")]
    		public Int32 EmployeeID { get; set; }

			[Required(ErrorMessage="National I D Number is required")]
			[StringLength(15)]
    		public String NationalIDNumber { get; set; }

			[Required(ErrorMessage="Contact is required")]
    		public Int32 ContactID { get; set; }

			[Required(ErrorMessage="Login is required")]
			[StringLength(256)]
    		public String LoginID { get; set; }

    		public Int32 ManagerID { get; set; }

			[Required(ErrorMessage="Title is required")]
			[StringLength(50)]
    		public String Title { get; set; }

			[Required(ErrorMessage="Birth Date is required")]
			[DataType(DataType.DateTime)]
    		public DateTime BirthDate { get; set; }

			[Required(ErrorMessage="Marital Status is required")]
			[StringLength(1)]
    		public String MaritalStatus { get; set; }

			[Required(ErrorMessage="Gender is required")]
			[StringLength(1)]
    		public String Gender { get; set; }

			[Required(ErrorMessage="Hire Date is required")]
			[DataType(DataType.DateTime)]
    		public DateTime HireDate { get; set; }

			[Required(ErrorMessage="Salaried Flag is required")]
    		public Boolean SalariedFlag { get; set; }

			[Required(ErrorMessage="Vacation Hours is required")]
    		public Int16 VacationHours { get; set; }

			[Required(ErrorMessage="Sick Leave Hours is required")]
    		public Int16 SickLeaveHours { get; set; }

			[Required(ErrorMessage="Current Flag is required")]
    		public Boolean CurrentFlag { get; set; }

			[Required(ErrorMessage="rowguid is required")]
    		public Guid rowguid { get; set; }

			[Required(ErrorMessage="Modified Date is required")]
			[DataType(DataType.DateTime)]
    		public DateTime ModifiedDate { get; set; }

    		public EntityCollection<Contact> Contact { get; set; }

    		public EntityCollection<Employee> Employee1 { get; set; }

    		public EntityCollection<Employee> Employee2 { get; set; }

    		public EntityCollection<EmployeePayHistory> EmployeePayHistories { get; set; }

		}
	}
	
	[MetadataType(typeof(EmployeePayHistoryMetadata))]
	public partial class EmployeePayHistory
	{
		internal sealed class EmployeePayHistoryMetadata
		{
		
			[Required(ErrorMessage="Employee is required")]
    		public Int32 EmployeeID { get; set; }

			[Required(ErrorMessage="Rate Change Date is required")]
			[DataType(DataType.DateTime)]
    		public DateTime RateChangeDate { get; set; }

			[Required(ErrorMessage="Rate is required")]
    		public Decimal Rate { get; set; }

			[Required(ErrorMessage="Pay Frequency is required")]
    		public Byte PayFrequency { get; set; }

			[Required(ErrorMessage="Modified Date is required")]
			[DataType(DataType.DateTime)]
    		public DateTime ModifiedDate { get; set; }

    		public EntityCollection<Employee> Employee { get; set; }

		}
	}
	
	
}


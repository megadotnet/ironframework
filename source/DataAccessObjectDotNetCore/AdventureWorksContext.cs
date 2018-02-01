using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BusinessEntities;

namespace DotCoreWebAPI.Models2
{
    /// <summary>
    /// AdventureWorksContext
    /// </summary>
    /// <seealso cref="https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db"/>
    public partial class AdventureWorksContext : DbContext
    {
        /// <summary>
        /// AdventureWorksContext
        /// </summary>
        /// <param name="options"></param>
        /// <see cref="https://stackoverflow.com/questions/40745468/no-database-provider-has-been-configured-for-this-dbcontext"/>
        public AdventureWorksContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }


        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeePayHistory> EmployeePayHistory { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Person");

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_Address_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.StateProvinceID)
                    .HasName("IX_Address_StateProvinceID");

                entity.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvinceID, e.PostalCode })
                    .HasName("IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode")
                    .IsUnique();

                entity.Property(e => e.AddressID).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.AddressLine2)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.StateProvinceID).HasColumnName("StateProvinceID");

                entity.Property(d => d.StateProvinceID)
                 .HasColumnType("StateProvinceId");
            });

          

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact", "Person");

                entity.HasIndex(e => e.AdditionalContactInfo)
                    .HasName("PXML_Contact_AddContact");

                entity.HasIndex(e => e.EmailAddress)
                    .HasName("IX_Contact_EmailAddress");

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_Contact_rowguid")
                    .IsUnique();

                entity.Property(e => e.ContactID).HasColumnName("ContactID");

                entity.Property(e => e.AdditionalContactInfo).HasColumnType("xml");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.EmailPromotion).HasDefaultValueSql("0");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.MiddleName).HasColumnType("Name");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.NameStyle)
                    .HasColumnType("NameStyle")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Phone).HasColumnType("Phone");

                entity.Property(e => e.rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.Suffix).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(8);
            });

       
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "HumanResources");

                entity.HasIndex(e => e.LoginID)
                    .HasName("AK_Employee_LoginID")
                    .IsUnique();

                entity.HasIndex(e => e.ManagerID)
                    .HasName("IX_Employee_ManagerID");

                entity.HasIndex(e => e.NationalIDNumber)
                    .HasName("AK_Employee_NationalIDNumber")
                    .IsUnique();

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_Employee_rowguid")
                    .IsUnique();

                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.ContactID).HasColumnName("ContactID");

                entity.Property(e => e.CurrentFlag)
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("nchar(1)");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LoginID)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(256);

                entity.Property(e => e.ManagerID).HasColumnName("ManagerID");

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasColumnType("nchar(1)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.NationalIDNumber)
                    .IsRequired()
                    .HasColumnName("NationalIDNumber")
                    .HasMaxLength(15);

                entity.Property(e => e.rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.SalariedFlag)
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SickLeaveHours).HasDefaultValueSql("0");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VacationHours).HasDefaultValueSql("0");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ContactID)
                    .OnDelete(DeleteBehavior.Restrict);

                //entity.HasOne(d => d.Employee1)
                //    .WithMany(p => p.Employee2)
                //    .HasForeignKey(d => d.ManagerId);
            });

         

            modelBuilder.Entity<EmployeePayHistory>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeID, e.RateChangeDate })
                    .HasName("PK_EmployeePayHistory_EmployeeID_RateChangeDate");

                entity.ToTable("EmployeePayHistory", "HumanResources");

                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                entity.Property(e => e.RateChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePayHistories)
                    .HasForeignKey(d => d.EmployeeID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

           
            
        }
    }
}
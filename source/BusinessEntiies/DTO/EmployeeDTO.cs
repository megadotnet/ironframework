// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeDTO.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   EmployeeDTO
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessEntiies
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using IronFramework.Utility.EntityFramewrok;
    using IronFramework.Utility;

    /// <summary>
    /// EmployeeDTO is wcf or UI data transfer object
    /// </summary>
    [DataContract]
    public partial class EmployeeDTO 
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string NationalIDNumber { get; set; }
        [DataMember]
        public int ContactID { get; set; }
        [DataMember]
        public string LoginID { get; set; }
        [DataMember]
        public Nullable<int> ManagerID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public System.DateTime BirthDate { get; set; }
        [DataMember]
        public string MaritalStatus { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public System.DateTime HireDate { get; set; }
        [DataMember]
        public bool SalariedFlag { get; set; }
        [DataMember]
        public short VacationHours { get; set; }
        [DataMember]
        public short SickLeaveHours { get; set; }
        [DataMember]
        public bool CurrentFlag { get; set; }
        [DataMember]
        public System.Guid rowguid { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        public virtual ContactDTO Contact { get; set; }
        /// <summary>
        /// Gets or sets the employee pay histories.
        /// </summary>
        /// <value>
        /// The employee pay histories.
        /// </value>
        public virtual List<EmployeePayHistoryDTO> EmployeePayHistories { get; set; }

    }

    /// <summary>
    /// EmployeeAdapter
    /// </summary>
    public class EmployeeAdapter : TypeAdapter
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <typeparam name="S">Souce type</typeparam>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public override T Transform<S,T>(S source)
        {
            //TODO: The best approach that provider automatically revert method
            if (typeof(S).Equals(typeof(Employee)))
            {
                CreateMap<Employee, EmployeeDTO>();
                //mapping child collection
                CreateMap<Contact, ContactDTO>();
                CreateMap<EmployeePayHistory, EmployeePayHistoryDTO>();
            }
            else
            {
                CreateMap<EmployeeDTO, Employee>();
                //mapping child collection
                CreateMap<ContactDTO, Contact>();
                CreateMap<EmployeePayHistoryDTO, EmployeePayHistory>();
            }
            return GetTarget<S,T>(source);
        }
    }
}

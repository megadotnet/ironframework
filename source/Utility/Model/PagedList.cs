// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedList.cs" company="Megadotnet">
//   Copyright (c) 2010-2015 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The paged list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.UI
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// The paged list.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    ///<see cref="http://www.codeproject.com/Articles/834829/Serializing-A-PagedList-Using-JSON-NET-In-ASP-NET"/>
    ///<example>
    ///<code>
    ///<![CDATA[
    ///{"IsNextPage":true,"IsPreviousPage":true,"PageIndex":1,"PageSize":10,"TotalCount":291,"Items":[{"EmployeeID":307,"NationalIDNumber":"2","ContactID":3,"LoginID":"adventure-works\\peter","ManagerID":2,"Title":"new title","BirthDate":"1965-01-01T00:00:00","MaritalStatus":"M","Gender":"M","HireDate":"2014-08-10T10:43:38.007","SalariedFlag":false,"VacationHours":2,"SickLeaveHours":3,"CurrentFlag":true,"rowguid":"becd40ef-48cb-45da-9c37-e707cca62e1d","ModifiedDate":"2014-08-10T10:43:39.02","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":290,"NationalIDNumber":"758596752","ContactID":1024,"LoginID":"adventure-works\\lynn0","ManagerID":288,"Title":"Sales Representative","BirthDate":"1961-04-18T00:00:00","MaritalStatus":"S","Gender":"F","HireDate":"2003-07-01T00:00:00","SalariedFlag":true,"VacationHours":36,"SickLeaveHours":38,"CurrentFlag":true,"rowguid":"4a9a8407-a680-4a6b-8d03-511cb58f9a8a","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":289,"NationalIDNumber":"954276278","ContactID":1023,"LoginID":"adventure-works\\rachel0","ManagerID":284,"Title":"Sales Representative","BirthDate":"1965-08-09T00:00:00","MaritalStatus":"S","Gender":"F","HireDate":"2003-07-01T00:00:00","SalariedFlag":true,"VacationHours":35,"SickLeaveHours":37,"CurrentFlag":true,"rowguid":"b9bf7741-e0ca-4f37-acde-a4f78c6d03e9","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":288,"NationalIDNumber":"481044938","ContactID":1012,"LoginID":"adventure-works\\syed0","ManagerID":273,"Title":"Pacific Sales Manager","BirthDate":"1965-02-11T00:00:00","MaritalStatus":"M","Gender":"M","HireDate":"2003-04-15T00:00:00","SalariedFlag":true,"VacationHours":20,"SickLeaveHours":30,"CurrentFlag":true,"rowguid":"86f292db-b73c-429d-9912-800994d809fb","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":287,"NationalIDNumber":"90836195","ContactID":1027,"LoginID":"adventure-works\\tete0","ManagerID":268,"Title":"Sales Representative","BirthDate":"1968-02-06T00:00:00","MaritalStatus":"M","Gender":"M","HireDate":"2002-11-01T00:00:00","SalariedFlag":true,"VacationHours":39,"SickLeaveHours":39,"CurrentFlag":true,"rowguid":"0c67ce00-de78-4712-908f-06939a2c58d5","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":286,"NationalIDNumber":"134219713","ContactID":1022,"LoginID":"adventure-works\\ranjit0","ManagerID":284,"Title":"Sales Representative","BirthDate":"1965-10-31T00:00:00","MaritalStatus":"S","Gender":"M","HireDate":"2002-07-01T00:00:00","SalariedFlag":true,"VacationHours":34,"SickLeaveHours":37,"CurrentFlag":true,"rowguid":"604213f9-dd0f-43b4-bdd2-c96e93d3f4bf","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":285,"NationalIDNumber":"668991357","ContactID":1025,"LoginID":"adventure-works\\jae0","ManagerID":284,"Title":"Sales Representative","BirthDate":"1958-04-18T00:00:00","MaritalStatus":"M","Gender":"F","HireDate":"2002-07-01T00:00:00","SalariedFlag":true,"VacationHours":37,"SickLeaveHours":38,"CurrentFlag":true,"rowguid":"723a5921-d8a1-4659-9bc4-13c4cf7c9c91","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":284,"NationalIDNumber":"982310417","ContactID":1013,"LoginID":"adventure-works\\amy0","ManagerID":273,"Title":"European Sales Manager","BirthDate":"1947-10-22T00:00:00","MaritalStatus":"M","Gender":"F","HireDate":"2002-05-18T00:00:00","SalariedFlag":true,"VacationHours":21,"SickLeaveHours":30,"CurrentFlag":true,"rowguid":"66d66445-ee78-4676-9e66-0e22d6109a92","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":283,"NationalIDNumber":"987554265","ContactID":1015,"LoginID":"adventure-works\\david8","ManagerID":268,"Title":"Sales Representative","BirthDate":"1964-03-14T00:00:00","MaritalStatus":"S","Gender":"M","HireDate":"2001-07-01T00:00:00","SalariedFlag":true,"VacationHours":23,"SickLeaveHours":31,"CurrentFlag":true,"rowguid":"1e8f9e91-508f-4d49-acd2-775c836030ed","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":282,"NationalIDNumber":"399771412","ContactID":1020,"LoginID":"adventure-works\\josé1","ManagerID":268,"Title":"Sales Representative","BirthDate":"1954-01-11T00:00:00","MaritalStatus":"M","Gender":"M","HireDate":"2001-07-01T00:00:00","SalariedFlag":true,"VacationHours":31,"SickLeaveHours":35,"CurrentFlag":true,"rowguid":"fd3992fb-3067-451d-a09d-73bd53c0feca","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0}],"Capacity":0,"Count":0}
    /// ]]>
    /// </code>
    /// </example>
     [Serializable]
     [CollectionDataContract]
     //[JsonObject]
    public class PagedList<T> : List<T>, IPagedList
    {

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        public PagedList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        public PagedList(IQueryable<T> source, int index, int pageSize, int count)
            : this(source, index, pageSize)
        {
            this.TotalCount = count;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        public PagedList(IQueryable<T> source, int index, int pageSize)
        {
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        public PagedList(List<T> source, int index, int pageSize)
        {
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether IsNextPage.
        /// </summary>
        public bool IsNextPage
        {
            get
            {
                return (this.PageIndex * this.PageSize) <= this.TotalCount;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsPreviousPage.
        /// </summary>
        public bool IsPreviousPage
        {
            get
            {
                return this.PageIndex > 0;
            }
        }

        /// <summary>
        /// Gets or sets PageIndex.
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets PageSize.
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets TotalCount.
        /// </summary>
        [DataMember]
        public int TotalCount { get; set; }

         /// <summary>
        /// Items
         /// </summary>
        /// <see cref="http://www.codeproject.com/Articles/834829/Serializing-A-PagedList-Using-JSON-NET-In-ASP-NET"/>
        /// <seealso cref="http://gurustop.net/blog/2014/01/06/serializing-a-pagedlist-using-json-net-the-gotcha-and-workaround/"/>
        [JsonProperty]
        public List<T> Items
        {
            get
            {
                return this.ToList();
             
            }

        }


        #endregion

         /// <summary>
        /// GetMetaData
         /// </summary>
         /// <returns></returns>
        /// <see cref="http://stackoverflow.com/questions/10870618/newtonsoft-json-serialization-of-pagedlistt-is-not-including-some-properties"/>
        public IPagedList GetMetaData()
        {
            return new PagedListMetaData(this);
        }
    }

     ///<summary>
     /// Non-enumerable version of the PagedList class.
     ///</summary>
     //[Serializable]
     public class PagedListMetaData : IPagedList
     {
         /// <summary>
         /// Protected constructor that allows for instantiation without passing in a separate list.
         /// </summary>
         protected PagedListMetaData()
         {
         }

         ///<summary>
         /// Non-enumerable version of the PagedList class.
         ///</summary>
         ///<param name="pagedList">A PagedList (likely enumerable) to copy metadata from.</param>
         public PagedListMetaData(IPagedList pagedList)
         {
             TotalCount = pagedList.TotalCount;
             PageIndex = pagedList.PageIndex;
             PageSize = pagedList.PageSize;
         }

         #region IPagedList Members

         /// <summary>
         /// 	Total number of subsets within the superset.
         /// </summary>
         /// <value>
         /// 	Total number of subsets within the superset.
         /// </value>
         public int PageCount { get;  set; }

         /// <summary>
         /// 	One-based index of this subset within the superset.
         /// </summary>
         /// <value>
         /// 	One-based index of this subset within the superset.
         /// </value>
         public int PageIndex { get;  set; }

         /// <summary>
         /// 	Maximum size any individual subset.
         /// </summary>
         /// <value>
         /// 	Maximum size any individual subset.
         /// </value>
         public int PageSize { get;  set; }


         #endregion

         /// <summary>
         /// IsNextPage
         /// </summary>
         public bool IsNextPage { get;  set; }

         /// <summary>
         /// IsPreviousPage
         /// </summary>
         public bool IsPreviousPage { get;  set; }

         /// <summary>
         /// TotalCount
         /// </summary>
         public int TotalCount { get;  set; }

         /// <summary>
         /// GetMetaData
         /// </summary>
         /// <returns></returns>
         public IPagedList GetMetaData()
         {
             throw new NotImplementedException();
         }
     }
}
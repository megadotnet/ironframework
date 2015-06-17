using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronFramework.Utility.UI
{
    /// <summary>
    /// PagedListViewModel for UI
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref=""/>
    /// <seealso cref="http://json2csharp.com/"/>
    public class PagedListViewModel<T> where T : class
    {
        public bool IsNextPage { get; set; }
        public bool IsPreviousPage { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
        public int Capacity { get; set; }
        public int Count { get; set; }
    }

    /// <summary>
    /// PagedListViewModel2
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// {"Items":[{"EmployeeID":290,"NationalIDNumber":"758596752","ContactID":1024,"LoginID":"adventure-works\\lynn0","ManagerID":288,"Title":"Sales Representative","BirthDate":"1961-04-18T00:00:00","MaritalStatus":"S","Gender":"F","HireDate":"2003-07-01T00:00:00","SalariedFlag":true,"VacationHours":36,"SickLeaveHours":38,"CurrentFlag":true,"rowguid":"4a9a8407-a680-4a6b-8d03-511cb58f9a8a","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":289,"NationalIDNumber":"954276278","ContactID":1023,"LoginID":"adventure-works\\rachel0","ManagerID":284,"Title":"Sales Representative","BirthDate":"1965-08-09T00:00:00","MaritalStatus":"S","Gender":"F","HireDate":"2003-07-01T00:00:00","SalariedFlag":true,"VacationHours":35,"SickLeaveHours":37,"CurrentFlag":true,"rowguid":"b9bf7741-e0ca-4f37-acde-a4f78c6d03e9","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":288,"NationalIDNumber":"481044938","ContactID":1012,"LoginID":"adventure-works\\syed0","ManagerID":273,"Title":"Pacific Sales Manager","BirthDate":"1965-02-11T00:00:00","MaritalStatus":"M","Gender":"M","HireDate":"2003-04-15T00:00:00","SalariedFlag":true,"VacationHours":20,"SickLeaveHours":30,"CurrentFlag":true,"rowguid":"86f292db-b73c-429d-9912-800994d809fb","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":287,"NationalIDNumber":"90836195","ContactID":1027,"LoginID":"adventure-works\\tete0","ManagerID":268,"Title":"Sales Representative","BirthDate":"1968-02-06T00:00:00","MaritalStatus":"M","Gender":"M","HireDate":"2002-11-01T00:00:00","SalariedFlag":true,"VacationHours":39,"SickLeaveHours":39,"CurrentFlag":true,"rowguid":"0c67ce00-de78-4712-908f-06939a2c58d5","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0},{"EmployeeID":286,"NationalIDNumber":"134219713","ContactID":1022,"LoginID":"adventure-works\\ranjit0","ManagerID":284,"Title":"Sales Representative","BirthDate":"1965-10-31T00:00:00","MaritalStatus":"S","Gender":"M","HireDate":"2002-07-01T00:00:00","SalariedFlag":true,"VacationHours":34,"SickLeaveHours":37,"CurrentFlag":true,"rowguid":"604213f9-dd0f-43b4-bdd2-c96e93d3f4bf","ModifiedDate":"2004-07-31T00:00:00","EmployeePayHistoriess":null,"pageSize":10,"pageIndex":1,"TotalCount":0}],"MetaData":{"PageCount":0,"PageIndex":1,"PageSize":5,"IsNextPage":false,"IsPreviousPage":false,"TotalCount":290}}
    /// ]]>
    /// </code>
    /// </example>
    public class PagedListViewModel2<T> where T : class
    {
        public List<T> Items { get; set; }
        public MetaData MetaData { get; set; }
    }

    /// <summary>
    /// MetaData  for PagedListViewModel2
    /// </summary>
    /// <seealso cref="http://json2csharp.com/"/>
    public class MetaData
    {
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool IsNextPage { get; set; }
        public bool IsPreviousPage { get; set; }
        public int TotalCount { get; set; }
    }
}

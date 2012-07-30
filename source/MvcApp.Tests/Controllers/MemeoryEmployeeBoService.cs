// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemeoryEmployeeBoService.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The memeory employee bo service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcApp.Tests.Controllers
{
    using System;
    using System.Linq;

    using ServicePoxry.AWServiceReference;
    using System.Collections.Generic;

    /// <summary>
    /// The memeory employee bo service.
    /// </summary>
    /// <remarks>It would be better use Mock framework to reduce code</remarks>
    public class MemeoryEmployeeBoService : IEmployeeBoService
    {
        private IList<Employee> employeeList;

        public MemeoryEmployeeBoService()
        {
            employeeList = new List<Employee>
            {
                new Employee{EmployeeID=1,Title="SD"}
            };
        }

        #region Implemented Interfaces

        #region IEmployeeBoService

        /// <summary>
        /// The create employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The create employee.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CreateEmployee(Employee employee)
        {
            employeeList.Add(employee);
            return true;
        }

        /// <summary>
        /// The create employee 2.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The create employee 2.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int CreateEmployee2(Employee employee)
        {
            employeeList.Add(employee);
            return employee.EmployeeID;
        }

        /// <summary>
        /// The del employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The del employee.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool DelEmployee(Employee employee)
        {
            employeeList.Remove(employee);
            return true;
        }

        /// <summary>
        /// The find employee by title.
        /// </summary>
        /// <param name="totalcount">
        /// The totalcount.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// </returns>
        public PagedListOfEmployeeuTvS1Dbc FindEmployeeByTitle(
            out int totalcount, string title, int? pageIndex, int pageSize)
        {
            var list = new PagedListOfEmployeeuTvS1Dbc();
            list.AddRange(employeeList);
            totalcount = list.Count();
            return list;
        }

        /// <summary>
        /// The get employee.
        /// </summary>
        /// <param name="pid">
        /// The pid.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Employee GetEmployee(int pid)
        {
            return employeeList.Where(e => e.EmployeeID == pid).SingleOrDefault();
        }

        /// <summary>
        /// Gets the paged list contact.
        /// </summary>
        /// <param name="totalcount">
        /// The totalcount.
        /// </param>
        /// <param name="pageIndex">
        /// Index of the page.
        /// </param>
        /// <param name="pageSize">
        /// Size of the page.
        /// </param>
        /// <returns>
        /// Paged list contact
        /// </returns>
        public PagedListOfContactuTvS1Dbc GetPagedListContact(out int totalcount, int? pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The update employee.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The update employee.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool UpdateEmployee(Employee employee)
        {
            var employee1 = employeeList.Where(e => e.EmployeeID == employee.EmployeeID).SingleOrDefault();
            if (employee1 != null)
            {
                employeeList.Remove(employee1);
                employeeList.Add(employee);
                return true;
            }
            return false;
        }

        #endregion

        #endregion
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeController.cs" company="Megadotnet">
// Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//  EmployeeController
//  usage  "Scaffold-DbContext "Data Source=.;Initial Catalog=AdventureWorks;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model"
// </summary>
// --------------------------------------------------------------------------------------------------------------------	

namespace DotCoreWebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using DotCoreWebAPI.Converter;
    using DataTransferObject;
    using DataAccessObjectDotNetCore;
    using BusinessObjectStandard.Service;

    /// <summary>
    /// EmployeeController
    /// </summary>
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        /// <summary>
        /// AdventureWorksContext
        /// </summary>
        private readonly IEmployeeService _context;
        /// <summary>
        /// EmployeeConverter
        /// </summary>
        private readonly EmployeeConverter employeeConverter = IronFramework.Utility.Singleton.GetInstance<EmployeeConverter>() as EmployeeConverter;

        /// <summary>
        /// EmployeeController
        /// </summary>
        /// <param name="context"></param>
        public EmployeeController(IEmployeeService service)
        {
            _context = service;
        }

        /// <summary>
        /// Get all EmployeeDto   api/employee
        /// </summary>
        /// <returns>Employee</returns>
        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            var dbentities = (_context as Service<Employee>).Queryable().ToList();
            var employeedtos = new List<EmployeeDto>();
            dbentities.ForEach(c => employeedtos.Add(employeeConverter.ConvertEntitiesToDto(c)));
            return employeedtos;
        }


        /// <summary>
        /// Get EmployeeDto  api/employee/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EmployeeDto</returns>
        //[HttpGet("{id}")]
        //public EmployeeDto Get(int id)
        //{
        //    var dbentities = _context.Employee.Where(e => e.EmployeeId == id);
        //    if (dbentities==null)
        //    {
        //        return null;
        //    }
        //    return employeeConverter.ConvertEntitiesToDto(dbentities.FirstOrDefault());
        //}

    }
}

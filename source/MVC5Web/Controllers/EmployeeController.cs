// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="Megadotnet">
// Copyright (c) 2010-2014 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The Employee repository.
//   This file is auto generated and will be overwritten as soon as the template is executed
//   Do not modify this file...
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
namespace MVC5Web.Controllers
{  
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
	using System.Web.Mvc;
    using BusinessEntities;
    using IronFramework.Utility.UI;
    using DataTransferObject;
    using System.Threading.Tasks;

	public partial class EmployeeController : BaseWebController
	{
        public async Task<ActionResult> Index()
        {
            var dbresults = await ClientHTTPGetList<PagedList<EmployeeDto>, EmployeeDto>(
                string.Format("pageindex={0}&pagesize={1}", 1, 10)
                );
            return View(dbresults);
        }
	}
}
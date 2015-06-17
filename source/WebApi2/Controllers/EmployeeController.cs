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
namespace WebApi2.Controllers
{  
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using BusinessEntities;
    using System.Threading.Tasks;
    using System.Web.Http;
    using IronFramework.Utility.UI;
    using DataTransferObject;

	public partial class EmployeeController : BaseWebAPIController
	{
        [HttpGet]
        [Route("GetPageListAync2")]
        [PagedListActionFilter]
        public async Task<object> GetPageListAync2()
        {
            int index = Request.GetPageIndex();
            int size = Request.GetPageSize();
           var results=await _EmployeeBO.FindEntiesAsync(index, size);


           return new { Items = results, MetaData = results.GetMetaData() };
        }


	}
}
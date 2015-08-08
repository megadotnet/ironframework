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
    using IronFramework.Utility.UI;
    using DataTransferObject;
    using System.Threading.Tasks;
    using DataTransferObject.Model;
    using Newtonsoft.Json;



	public partial class EmployeeController : BaseWebController
	{

        /// <summary>
        /// Indexes the specified employee_name.
        /// </summary>
        /// <param name="employee_name">The employee_name.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<ActionResult> Index(string employee_name, int? page)
        {
            int pageIndex;
            int pageSize = 5;
            string pageQueryString = string.Empty;
     
            pageIndex = page.HasValue ? page.Value : 1;
            
            pageQueryString = string.Format("&pageIndex={0}&pageSize={1}", pageIndex, pageSize);
            var dbresults = await ClientHTTPGetList<EasyuiDatagridData<EmployeeDto>, EmployeeDto>(new EmployeeDto(), pageQueryString);

            if (Request.IsAjaxRequest())
                return PartialView("_PartialEmployee", dbresults);
            else
                return View(dbresults);
        }

        /// <summary>
        /// Indexes the asynchronous.
        /// </summary>
        /// <param name="employee_name">The employee_name.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<ActionResult> IndexAsync(string employee_name, int? page)
        {
            //int count = 0;
            int pageindex = page.HasValue ? page.Value : 1;
            int pagesize = 5;
            var dbresults = await ClientHTTPGetList<PagedListViewModel<EmployeeDto>, EmployeeDto>("GetPageListAync",
                string.Format("pageindex={0}&pagesize={1}", pageindex, pagesize)
                );

            if (Request.IsAjaxRequest())
                return PartialView("_PartialEmployeeAsync", dbresults);
            else
                return View(dbresults);
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Create()
        {
            //int count = 0;
            //var employees = this.serviceClient.FindEmployeeByTitle(null, 1, 10, out count);
            //var contactlist = this.serviceClient.GetPagedListContact(1, 10, out count);

            //this.ViewBag.ContactID = new SelectList(contactlist, "ContactID", "FirstName");
            //this.ViewBag.ManagerID = new SelectList(employees, "EmployeeID", "LoginID");
            return this.View();
        }

        // POST: /Employee/Create

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public async Task<bool> Create(EmployeeDto employee)
        {
            return await Post(employee);
        }

        // GET: /Employee/Edit/5

        // GET: /Employee/Delete/5

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var model = await ClientHTTPGet<EmployeeDto>(id);
        //    return View(model);
        //}

        // POST: /Employee/Delete/5

        /// <summary>
        /// The delete confirmed.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await ClientHTTPDelete<EmployeeDto>(id);
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// The details.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        public  async Task<ViewResult> Details(int id)
        {
            var model = await ClientHTTPGet<EmployeeDto>(id);
            return View(model);
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        public  async Task<ActionResult> Edit(int id)
        {
            var model = await ClientHTTPGet<EmployeeDto>(id);

            int count = 0;
            //var employeelist = this.serviceClient.FindEmployeeByTitle(null, 1, 10, out count);

            //var contactlist = this.serviceClient.GetPagedListContact(1, 10, out count);

            //this.ViewBag.ContactID = new SelectList(contactlist, "ContactID", "FirstName");
            //this.ViewBag.ManagerID = new SelectList(employeelist, "EmployeeID", "LoginID", employee.ManagerID);
            return View(model);
        }

	}
}
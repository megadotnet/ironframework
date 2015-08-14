// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeController.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The employee controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcApp.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using ServicePoxry.AWServiceReference;

    /// <summary>
    /// The employee controller.
    /// </summary>
    public class EmployeeWCFController : Controller
    {
        #region Constants and Fields

        /// <summary>
        /// The service client.
        /// </summary>
        private readonly IEmployeeBoService serviceClient;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="_serviceClient">
        /// The _service client.
        /// </param>
        public EmployeeWCFController(IEmployeeBoService _serviceClient)
        {
            this.serviceClient = _serviceClient;
        }

        #endregion

        // GET: /Employee/

        // GET: /Employee/Create
        #region Public Methods

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Create()
        {
            int count = 0;
            PagedListOfEmployeeuTvS1Dbc employees = this.serviceClient.FindEmployeeByTitle(out count, null, 1, 10);
            var contactlist = this.serviceClient.GetPagedListContact(out count, 1, 10);

            this.ViewBag.ContactID = new SelectList(contactlist, "ContactID", "FirstName");
            this.ViewBag.ManagerID = new SelectList(employees, "EmployeeID", "LoginID");
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
        public ActionResult Create(ServicePoxry.AWServiceReference.Employee employee)
        {
            if (this.ModelState.IsValid)
            {
                this.serviceClient.CreateEmployee(employee);
                return this.RedirectToAction("Index");
            }

            int count = 0;
            PagedListOfEmployeeuTvS1Dbc employeelist = this.serviceClient.FindEmployeeByTitle(out count, null, 1, 10);
            var contactlist = this.serviceClient.GetPagedListContact(out count, 1, 10);

            this.ViewBag.ContactID = new SelectList(contactlist, "ContactID", "FirstName");
            this.ViewBag.ManagerID = new SelectList(employeelist, "EmployeeID", "LoginID", employee.ManagerID);
            return View(employee);
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
        public ActionResult Delete(int id)
        {
            Employee employee = this.serviceClient.GetEmployee(id);
            return View(employee);
        }

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
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = this.serviceClient.GetEmployee(id);
            this.serviceClient.DelEmployee(employee);
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
        public ViewResult Details(int id)
        {
            Employee employee = this.serviceClient.GetEmployee(id);
            return View(employee);
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        public ActionResult Edit(int id)
        {
            Employee employee = this.serviceClient.GetEmployee(id);

            int count = 0;
            PagedListOfEmployeeuTvS1Dbc employeelist = this.serviceClient.FindEmployeeByTitle(out count, null, 1, 10);

            var contactlist = this.serviceClient.GetPagedListContact(out count, 1, 10);
            
            this.ViewBag.ContactID = new SelectList(contactlist, "ContactID", "FirstName");
            this.ViewBag.ManagerID = new SelectList(employeelist, "EmployeeID", "LoginID", employee.ManagerID);
            return View(employee);
        }

        // POST: /Employee/Edit/5

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public ActionResult Edit(ServicePoxry.AWServiceReference.Employee employee)
        {
            if (this.ModelState.IsValid)
            {
                // db.Entry(employee).State = EntityState.Modified;
                // db.SaveChanges();
                this.serviceClient.UpdateEmployee(employee);
                return this.RedirectToAction("Index");
            }

            int count = 0;
            PagedListOfEmployeeuTvS1Dbc employeelist = this.serviceClient.FindEmployeeByTitle(out count, null, 1, 10);

            var contactlist = this.serviceClient.GetPagedListContact(out count, 1, 10);

            this.ViewBag.ContactID = new SelectList(contactlist, "ContactID", "FirstName");
            this.ViewBag.ManagerID = new SelectList(employeelist, "EmployeeID", "LoginID", employee.ManagerID);
            return View(employee);
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>ViewResult
        /// </returns>
        public ViewResult Index()
        {
            int count = 0;
            PagedListOfEmployeeuTvS1Dbc employee = this.serviceClient.FindEmployeeByTitle(out count, null, 1, 10);
            return View(employee.ToList());
        }

        [HttpGet]
        /// <summary>
        /// GetTitle for Autocomplete
        /// </summary>
        /// <returns>
        /// JsonResult
        /// </returns>
        public JsonResult GetTitle(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                int count = 0;
                //TODO:Change search text return Title column only
                PagedListOfEmployeeuTvS1Dbc employeelist = this.serviceClient.FindEmployeeByTitle(out count, null, 1, 20);

                return Json(employeelist.Where(el => el.Title.ToLower().Contains(term.ToLower())).Select(ee => ee.Title)
                    , JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            var clientservice = serviceClient as System.ServiceModel.ClientBase<IEmployeeBoService>;
            if (clientservice!=null)
                clientservice.Close();
            base.Dispose(disposing);
        }

        #endregion
    }
}
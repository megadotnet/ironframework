using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoService;
using BusinessEntiies;

namespace MVC5Web.Controllers
{
    public class EmployeeController : Controller
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
        public EmployeeController(IEmployeeBoService _serviceClient)
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
            var employees = this.serviceClient.FindEmployeeByTitle(null, 1, 10,out count);
            var contactlist = this.serviceClient.GetPagedListContact(1, 10,out count);

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
        public ActionResult Create(Employee employee)
        {
            if (this.ModelState.IsValid)
            {
                this.serviceClient.CreateEmployee(employee);
                return this.RedirectToAction("Index");
            }

            int count = 0;
            var employeelist = this.serviceClient.FindEmployeeByTitle(null, 1, 10,out count);
            var contactlist = this.serviceClient.GetPagedListContact(1, 10,out count);

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
            var employeelist = this.serviceClient.FindEmployeeByTitle(null, 1, 10, out count);

            var contactlist = this.serviceClient.GetPagedListContact(1, 10, out count);

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
        public ActionResult Edit(Employee employee)
        {
            if (this.ModelState.IsValid)
            {
                // db.Entry(employee).State = EntityState.Modified;
                // db.SaveChanges();
                this.serviceClient.UpdateEmployee(employee);
                return this.RedirectToAction("Index");
            }

            int count = 0;
            var employeelist = this.serviceClient.FindEmployeeByTitle(null, 1, 10, out count);

            var contactlist = this.serviceClient.GetPagedListContact(1, 10, out count);

            this.ViewBag.ContactID = new SelectList(contactlist, "ContactID", "FirstName");
            this.ViewBag.ManagerID = new SelectList(employeelist, "EmployeeID", "LoginID", employee.ManagerID);
            return View(employee);
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>ViewResult
        /// </returns>
        public ActionResult Index(string employee_name,int? page)
        {
            int count = 0;
            int pageindex = page.HasValue ? page.Value : 1, pagesize = 5;
            var employee = this.serviceClient.FindEmployeeByTitle(employee_name, pageindex, pagesize, out count);
            employee.TotalCount = count;
            employee.PageIndex = pageindex;
            employee.PageSize = pagesize;
    
            if (Request.IsAjaxRequest())
                return PartialView("_PartialEmployee", employee);
            else
                return View(employee);
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
                var employeelist = this.serviceClient.FindEmployeeByTitle(null, 1, 10, out count);

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
            if (clientservice != null)
                clientservice.Close();
            base.Dispose(disposing);
        }

        #endregion
    }
}
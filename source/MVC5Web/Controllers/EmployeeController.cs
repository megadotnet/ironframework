using BusinessEntities;
using DataTransferObject;
using DataTransferObject.Model;
using IronFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
	
namespace MVC5Web.Controllers
{   

	public partial class EmployeeController : BaseWebController 
	{

        // GET: Employee/Find/?pageindex=1&pagesize=10&....
        public async Task<JsonResult> Find(EmployeeDto _EmployeeDto)
        {
           return Json(await ClientHTTPGetList<EasyuiDatagridData<EmployeeDto>,EmployeeDto>(_EmployeeDto)
                    , JsonRequestBehavior.AllowGet);
        }

        // GET: Employee/Get/14
        public async Task<JsonResult> Get(int id)
        {
            var model = await ClientHTTPGet<EmployeeDto>(id);
              return Json(model, JsonRequestBehavior.AllowGet);
        }

        // Add POST: Employee/Post
        public async Task<bool> Post(EmployeeDto value) 
        {
            if (ModelState.IsValid)
            {
              return await ClientInvokeHttpPOST<EmployeeDto>(value);
            }
            return false;
        }

        //Update PUT: Employee/Put/
        public async Task<bool> Put(EmployeeDto value)
        {
            if (ModelState.IsValid)
            {
               return await  ClientHTTPPut<EmployeeDto>(value);
            }
            return false;
        }

        // DELETE: Employee/Delete/5
        public async Task<bool> Delete(int id)
        {
            return await ClientHTTPDelete<EmployeeDto>(id);
        }

	}
}
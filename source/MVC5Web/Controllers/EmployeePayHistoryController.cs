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

	public partial class EmployeePayHistoryController : BaseWebController 
	{

        // GET: EmployeePayHistory/Find/?pageindex=1&pagesize=10&....
        public async Task<JsonResult> Find(EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
           return Json(await ClientHTTPGetList<EasyuiDatagridData<EmployeePayHistoryDto>,EmployeePayHistoryDto>(_EmployeePayHistoryDto)
                    , JsonRequestBehavior.AllowGet);
        }

        // GET: EmployeePayHistory/Get/14
        public async Task<JsonResult> Get(int id)
        {
            var model = await ClientHTTPGet<EmployeePayHistoryDto>(id);
              return Json(model, JsonRequestBehavior.AllowGet);
        }

        // Add POST: EmployeePayHistory/Post
        public async Task<bool> Post(EmployeePayHistoryDto value) 
        {
            if (ModelState.IsValid)
            {
              return await ClientInvokeHttpPOST<EmployeePayHistoryDto>(value);
            }
            return false;
        }

        //Update PUT: EmployeePayHistory/Put/
        public async Task<bool> Put(EmployeePayHistoryDto value)
        {
            if (ModelState.IsValid)
            {
               return await  ClientHTTPPut<EmployeePayHistoryDto>(value);
            }
            return false;
        }

        // DELETE: EmployeePayHistory/Delete/5
        public async Task<bool> Delete(int id)
        {
            return await ClientHTTPDelete<EmployeePayHistoryDto>(id);
        }

	}
}
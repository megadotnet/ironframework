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
           if (Request["page"] != null)
           {
                _EmployeePayHistoryDto.pageIndex = Convert.ToInt32(Request["page"].ToString());
           }
           return Json(await ClientHTTPGetList<EasyuiDatagridData<EmployeePayHistoryDto>,EmployeePayHistoryDto>(_EmployeePayHistoryDto));
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

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <example>
        /// <code>
        /// POST: 
        /// EmployeePayHistory/Delete
         ///   BODY: 
         /// {
         /// "id": ["1627","1628"]
        ///}
        /// </code>
        /// </example>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Delete(int[] id)
        {
            var delobject = new DeleteObject { Ids = id };
            return Json(await ClientHTTPPut<EmployeePayHistoryDto, DeleteObject>(delobject, "DeleteByList"));
        }

        public ActionResult EmployeePayHistoryUI()
        {
            return this.View();
        }

	}
}
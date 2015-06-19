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

	public partial class ContactController : BaseWebController 
	{

        // GET: Contact/Find/?pageindex=1&pagesize=10&....
        public async Task<JsonResult> Find(ContactDto _ContactDto,int pageIndex=1,int pageSize=10)
        {
          string pageQueryString = string.Empty;
           //for EASYUI datagrid
           if (Request["page"] != null)
           {
               pageIndex = Convert.ToInt32(Request["page"].ToString());
           }
		    pageQueryString = string.Format("&pageIndex={0}&pageSize={1}", pageIndex, pageSize);
           return Json(await ClientHTTPGetList<EasyuiDatagridData<ContactDto>, ContactDto>(_ContactDto, pageQueryString));
        }

        // GET: Contact/Get/14
        public async Task<JsonResult> Get(int id)
        {
            var model = await ClientHTTPGet<ContactDto>(id);
              return Json(model, JsonRequestBehavior.AllowGet);
        }

        // Add POST: Contact/Post
        public async Task<bool> Post(ContactDto value) 
        {
            if (ModelState.IsValid)
            {
              return await ClientInvokeHttpPOST<ContactDto>(value);
            }
            return false;
        }

        //Update PUT: Contact/Put/
        public async Task<bool> Put(ContactDto value)
        {
            if (ModelState.IsValid)
            {
               return await  ClientHTTPPut<ContactDto>(value);
            }
            return false;
        }

        // DELETE: Contact/Delete/5
        public async Task<bool> Delete(int id)
        {
            return await ClientHTTPDelete<ContactDto>(id);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <example>
        /// <code>
        /// POST: 
        /// Contact/Delete
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
            return Json(await ClientHTTPPut<ContactDto, DeleteObject>(delobject, "DeleteByList"));
        }

        public ActionResult ContactUI()
        {
            return this.View();
        }

	}
}


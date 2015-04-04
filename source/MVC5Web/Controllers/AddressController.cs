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

	public partial class AddressController : BaseWebController 
	{

        // GET: Address/Find/?pageindex=1&pagesize=10&....
        public async Task<JsonResult> Find(AddressDto _AddressDto)
        {
           return Json(await ClientHTTPGetList<EasyuiDatagridData<AddressDto>,AddressDto>(_AddressDto)
                    , JsonRequestBehavior.AllowGet);
        }

        // GET: Address/Get/14
        public async Task<JsonResult> Get(int id)
        {
            var model = await ClientHTTPGet<AddressDto>(id);
              return Json(model, JsonRequestBehavior.AllowGet);
        }

        // Add POST: Address/Post
        public async Task<bool> Post(AddressDto value) 
        {
            if (ModelState.IsValid)
            {
              return await ClientInvokeHttpPOST<AddressDto>(value);
            }
            return false;
        }

        //Update PUT: Address/Put/
        public async Task<bool> Put(AddressDto value)
        {
            if (ModelState.IsValid)
            {
               return await  ClientHTTPPut<AddressDto>(value);
            }
            return false;
        }

        // DELETE: Address/Delete/5
        public async Task<bool> Delete(int id)
        {
            return await ClientHTTPDelete<AddressDto>(id);
        }

	}
}
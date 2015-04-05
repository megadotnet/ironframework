using BusinessEntities;
using BusinessObject;
using DataTransferObject;
using DataTransferObject.Model;
using IronFramework.Utility;
using IronFramework.Utility.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
	
namespace WebApi2.Controllers
{   

	public partial class AddressController : BaseWebAPIController 
	{

        /// <summary>
        /// The Address bo
        /// </summary>
        private IAddressBO _AddressBO = ServiceFactory.GetInstance<IAddressBO>();


        // GET: api/Address/?pageindex=1&pagesize=10&....
        public EasyuiDatagridData<AddressDto> Get([FromUri] AddressDto _AddressDto)
        {
           return  _AddressBO.FindAll(_AddressDto);
        }

		// GET: api/Address/?pageindex=1&pagesize=10
        public EasyuiDatagridData<AddressDto> Get([FromUri] int pageIndex, int pageSize)
        {
            return _AddressBO.FindEnties(new EmployeeDto { pageIndex=pageIndex,pageSize=pageSize});
        }

        // GET: api/Address/5
        public AddressDto Get(int id)
        {
            return _AddressBO.GetEntiyByPK(id);
        }

        // POST: api/Address
        [ValidateModel]
        public void Post(AddressDto value)
        {
            _AddressBO.CreateEntiy(value);
        }

        // PUT: api/Address/
        [ValidateModel]
        public void Put(AddressDto value)
        {
            _AddressBO.UpdateWithAttachEntiy(value);
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
            var entity = new AddressDto() { AddressID = id };
            _AddressBO.DeleteWithAttachEntiy(entity);
        }

	}
}

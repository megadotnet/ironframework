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

	public partial class ContactController : BaseWebAPIController 
	{

        /// <summary>
        /// The Contact bo
        /// </summary>
        private IContactBO _ContactBO = ServiceFactory.GetInstance<IContactBO>();


        // GET: api/Contact/?pageindex=1&pagesize=10&....
        public EasyuiDatagridData<ContactDto> Get([FromUri] ContactDto _ContactDto)
        {
           return  _ContactBO.FindAll(_ContactDto);
        }


		// GET: api/Contact/?pageindex=1&pagesize=10
        public PagedList<ContactDto> Get([FromUri] int pageIndex, int pageSize)
        {
            return _ContactBO.FindEnties(pageIndex, pageSize);
        }

        // GET: api/Contact/5
        public ContactDto Get(int id)
        {
            return _ContactBO.GetEntiyByPK(id);
        }

        // POST: api/Contact
        [ValidateModel]
        public void Post(ContactDto value)
        {
            _ContactBO.CreateEntiy(value);
        }

        // PUT: api/Contact/
        [ValidateModel]
        public void Put(ContactDto value)
        {
            _ContactBO.UpdateWithAttachEntiy(value);
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
            var entity = new ContactDto() { ContactID = id };
            _ContactBO.DeleteWithAttachEntiy(entity);
        }

	}
}

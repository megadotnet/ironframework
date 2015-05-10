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
using System.Threading.Tasks;
using System.Web.Http;
	
namespace WebApi2.Controllers
{   

	public partial class ContactController : BaseWebAPIController 
	{

        /// <summary>
        /// The Contact bo
        /// </summary>
        private IContactBO _ContactBO=null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// </summary>
        /// <param name="ContactBO">The _ userbo.</param>
        public ContactController(IContactBO  _varContactBO)
        {
            _ContactBO = _varContactBO;
        }



        // GET: api/Contact/?pageindex=1&pagesize=10&....
        public EasyuiDatagridData<ContactDto> Get([FromUri] ContactDto _ContactDto)
        {
           return  _ContactBO.FindAll(_ContactDto);
        }

		// GET: api/Contact/?pageindex=1&pagesize=10
        public EasyuiDatagridData<ContactDto> Get([FromUri] int pageIndex, int pageSize)
        {
            return _ContactBO.FindEnties(new ContactDto { pageIndex=pageIndex,pageSize=pageSize});
        }

        // GET: api/Contact/5
        public ContactDto Get(int id)
        {
            return _ContactBO.GetEntiyByPK(id);
        }

        // GET: api/Contact/GetAync?pageindex=1&pagesize=10
        [HttpGet]
        [Route("api/Contact/GetAync")]
        public async Task<PagedList<ContactDto>> GetAync([FromUri] int pageIndex, int pageSize)
        {
            return await _ContactBO.FindEntiesAsync(pageIndex, pageSize);
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


        /// <summary>
        /// Deletes the specified identifier. 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <example>
        /// POST http://localhost:14488/api/Contact
        /// BODY: {
        /// "Ids": ["1621","1622"]
        ///}
        /// 
        /// </example>
        [HttpPut]
        [Route("api/Contact/DeleteByList")]
        public void DeleteByList(DeleteObject deletedObjectList)
        {
            if (deletedObjectList != null)
            {
                int[] id = deletedObjectList.Ids;
                if (id != null && id.Length > 0)
                {
                    var listEnties = new List<ContactDto>();
                    foreach (int i in id)
                    {
                        listEnties.Add(new ContactDto() { ContactID = i });
                    }
                    _ContactBO.DeleteWithAttachEntiy(listEnties.ToArray());
                }
            }
        }
	}
}

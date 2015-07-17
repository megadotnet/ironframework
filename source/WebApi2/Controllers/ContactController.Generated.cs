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
using WebApi2.Controllers;
	
namespace WebApi2.Controllers
{   

    [RoutePrefix("api/Contact")]
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


         /// <summary>
        /// Get the List ofContactdto.
        /// </summary>
        /// <param name="_ContactDto">The Contact dto.</param>
        /// <example><code> HTTP GET: api/Contact/?pageindex=1&pagesize=10&....</code></example>
        /// <returns>DatagridData List of ContactDto</returns>
        public EasyuiDatagridData<ContactDto> Get([FromUri] ContactDto _ContactDtos, int pageIndex =1, int pageSize =10)
        {
		    var pagedlist = new PagedList<ContactDto>  {_ContactDtos };
            pagedlist.PageIndex = pageIndex;
            pagedlist.PageSize = pageSize;
            return _ContactBO.FindAll(pagedlist);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <example><code>GET: api/Contact/5</code></example>
        /// <returns>ContactDto</returns>
        public ContactDto Get(Int32 id)
        {
            var dtoEntity = new ContactDto() { ContactID=id};
            return _ContactBO.GetEntiyByPK(dtoEntity);
        }

        /// <summary>
        /// Gets the Contact with aync 
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <example><code>GET: api/Contact/GetAync?pageindex=1&pagesize=10</code></example>
        /// <returns>ContactDto</returns>
        [HttpGet]
        [Route("GetAync")]
        public async Task<PagedList<ContactDto>> GetAync([FromUri] int pageIndex, int pageSize)
        {
            return await _ContactBO.FindEntiesAsync(pageIndex, pageSize);
        }

        // GET: api/Contact/GetAync?pageindex=1&pagesize=10
        [HttpGet]
        [Route("GetPageListAync")]
        [PagedListActionFilter] 
        public async Task<object> GetPageListAync()
        {
		    int index = Request.GetPageIndex();
            int size = Request.GetPageSize();
            var results = await _ContactBO.FindEntiesAsync(index, size);

            return new { Items = results, MetaData = results.GetMetaData() };
        }


        // POST: api/Contact
        [ValidateModel]
        public bool Post(ContactDto value)
        {
            return _ContactBO.CreateEntiy(value);
        }

        // PUT: api/Contact/
        [ValidateModel]
        public bool Put(ContactDto value)
        {
            return _ContactBO.UpdateWithAttachEntiy(value);
        }

        // DELETE: api/Contact/5
        public bool Delete(int id)
        {
            var entity = new ContactDto() { ContactID = id };
            return _ContactBO.DeleteWithAttachEntiy(entity);
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
        [Route("DeleteByList")]
        public bool DeleteByList(DeleteObject deletedObjectList)
        {
		    bool deleteflag = false;
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
			return deleteflag;
        }
	}
}

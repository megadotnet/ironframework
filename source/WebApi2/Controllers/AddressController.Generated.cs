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

    [RoutePrefix("api/Address")]
	public partial class AddressController : BaseWebAPIController 
	{

        /// <summary>
        /// The Address bo
        /// </summary>
        private IAddressBO _AddressBO=null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressController"/> class.
        /// </summary>
        /// <param name="AddressBO">The _ userbo.</param>
        public AddressController(IAddressBO  _varAddressBO)
        {
            _AddressBO = _varAddressBO;
        }


         /// <summary>
        /// Get the List ofAddressdto.
        /// </summary>
        /// <param name="_AddressDto">The Address dto.</param>
        /// <example><code> HTTP GET: api/Address/?pageindex=1&pagesize=10&....</code></example>
        /// <returns>DatagridData List of AddressDto</returns>
        public EasyuiDatagridData<AddressDto> Get([FromUri] AddressDto _AddressDto)
        {
           return  _AddressBO.FindAll(_AddressDto);
        }

        /// <summary>
        /// Gets the specified page index.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <example><code>GET: api/Address/?pageindex=1&pagesize=10</code></example>
        /// <returns>DatagridData List of AddressDto</returns>
        public EasyuiDatagridData<AddressDto> Get([FromUri] int pageIndex, int pageSize)
        {
            return _AddressBO.FindEnties(new AddressDto { pageIndex=pageIndex,pageSize=pageSize});
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <example><code>GET: api/Address/5</code></example>
        /// <returns>AddressDto</returns>
        public AddressDto Get(Int32 id)
        {
            var dtoEntity = new AddressDto() { AddressID=id};
            return _AddressBO.GetEntiyByPK(dtoEntity);
        }

        /// <summary>
        /// Gets the Address with aync 
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <example><code>GET: api/Address/GetAync?pageindex=1&pagesize=10</code></example>
        /// <returns>AddressDto</returns>
        [HttpGet]
        [Route("GetAync")]
        public async Task<PagedList<AddressDto>> GetAync([FromUri] int pageIndex, int pageSize)
        {
            return await _AddressBO.FindEntiesAsync(pageIndex, pageSize);
        }

        // GET: api/Address/GetAync?pageindex=1&pagesize=10
        [HttpGet]
        [Route("GetPageListAync")]
        [PagedListActionFilter] 
        public async Task<object> GetPageListAync()
        {
		    int index = Request.GetPageIndex();
            int size = Request.GetPageSize();
            var results = await _AddressBO.FindEntiesAsync(index, size);

            return new { Items = results, MetaData = results.GetMetaData() };
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


        /// <summary>
        /// Deletes the specified identifier. 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <example>
        /// POST http://localhost:14488/api/Address
        /// BODY: {
        /// "Ids": ["1621","1622"]
        ///}
        /// 
        /// </example>
        [HttpPut]
        [Route("DeleteByList")]
        public void DeleteByList(DeleteObject deletedObjectList)
        {
            if (deletedObjectList != null)
            {
                int[] id = deletedObjectList.Ids;
                if (id != null && id.Length > 0)
                {
                    var listEnties = new List<AddressDto>();
                    foreach (int i in id)
                    {
                        listEnties.Add(new AddressDto() { AddressID = i });
                    }
                    _AddressBO.DeleteWithAttachEntiy(listEnties.ToArray());
                }
            }
        }
	}
}

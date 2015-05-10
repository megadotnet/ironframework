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



        // GET: api/Address/?pageindex=1&pagesize=10&....
        public EasyuiDatagridData<AddressDto> Get([FromUri] AddressDto _AddressDto)
        {
           return  _AddressBO.FindAll(_AddressDto);
        }

		// GET: api/Address/?pageindex=1&pagesize=10
        public EasyuiDatagridData<AddressDto> Get([FromUri] int pageIndex, int pageSize)
        {
            return _AddressBO.FindEnties(new AddressDto { pageIndex=pageIndex,pageSize=pageSize});
        }

        // GET: api/Address/5
        public AddressDto Get(int id)
        {
            return _AddressBO.GetEntiyByPK(id);
        }

        // GET: api/Address/GetAync?pageindex=1&pagesize=10
        [HttpGet]
        [Route("api/Address/GetAync")]
        public async Task<PagedList<AddressDto>> GetAync([FromUri] int pageIndex, int pageSize)
        {
            return await _AddressBO.FindEntiesAsync(pageIndex, pageSize);
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
        [Route("api/Address/DeleteByList")]
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

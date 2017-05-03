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

    [RoutePrefix("api/Currency")]
	public partial class CurrencyController : BaseWebAPIController 
	{

        /// <summary>
        /// The Currency bo
        /// </summary>
        private ICurrencyBO _CurrencyBO=null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyController"/> class.
        /// </summary>
        /// <param name="CurrencyBO">The _ userbo.</param>
        public CurrencyController(ICurrencyBO  _varCurrencyBO)
        {
            _CurrencyBO = _varCurrencyBO;
        }


         /// <summary>
        /// Get the List ofCurrencydto.
        /// </summary>
        /// <param name="_CurrencyDto">The Currency dto.</param>
        /// <example><code> HTTP GET: api/Currency/?pageindex=1&pagesize=10&....</code></example>
        /// <returns>DatagridData List of CurrencyDto</returns>
        public EasyuiDatagridData<CurrencyDto> Get([FromUri] CurrencyDto _CurrencyDto)
        {
           return  _CurrencyBO.FindAll(_CurrencyDto);
        }

        /// <summary>
        /// Gets the specified page index.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <example><code>GET: api/Currency/?pageindex=1&pagesize=10</code></example>
        /// <returns>DatagridData List of CurrencyDto</returns>
        public EasyuiDatagridData<CurrencyDto> Get([FromUri] int pageIndex, int pageSize)
        {
            return _CurrencyBO.FindEnties(new CurrencyDto { pageIndex=pageIndex,pageSize=pageSize});
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <example><code>GET: api/Currency/5</code></example>
        /// <returns>CurrencyDto</returns>
        public CurrencyDto Get(String id)
        {
            var dtoEntity = new CurrencyDto() { CurrencyCode=id};
            return _CurrencyBO.GetEntiyByPK(dtoEntity);
        }

        /// <summary>
        /// Gets the Currency with aync 
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <example><code>GET: api/Currency/GetAync?pageindex=1&pagesize=10</code></example>
        /// <returns>CurrencyDto</returns>
        [HttpGet]
        [Route("GetAync")]
        public async Task<PagedList<CurrencyDto>> GetAync([FromUri] int pageIndex, int pageSize)
        {
            return await _CurrencyBO.FindEntiesAsync(pageIndex, pageSize);
        }

        // GET: api/Currency/GetAync?pageindex=1&pagesize=10
        [HttpGet]
        [Route("GetPageListAync")]
        [PagedListActionFilter] 
        public async Task<PagedList<CurrencyDto>> GetPageListAync()
        {
            int index = Request.GetPageIndex();
            int size = Request.GetPageSize();

            return await _CurrencyBO.FindEntiesAsync(index, size);
        }


        // POST: api/Currency
        [ValidateModel]
        public void Post(CurrencyDto value)
        {
            _CurrencyBO.CreateEntiy(value);
        }

        // PUT: api/Currency/
        [ValidateModel]
        public void Put(CurrencyDto value)
        {
            _CurrencyBO.UpdateWithAttachEntiy(value);
        }

        // DELETE: api/Currency/5
        public void Delete(int id)
        {
            var entity = new CurrencyDto() { CurrencyCode = id };
            _CurrencyBO.DeleteWithAttachEntiy(entity);
        }


        /// <summary>
        /// Deletes the specified identifier. 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <example>
        /// POST http://localhost:14488/api/Currency
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
                    var listEnties = new List<CurrencyDto>();
                    foreach (int i in id)
                    {
                        listEnties.Add(new CurrencyDto() { CurrencyCode = i });
                    }
                    _CurrencyBO.DeleteWithAttachEntiy(listEnties.ToArray());
                }
            }
        }
	}
}

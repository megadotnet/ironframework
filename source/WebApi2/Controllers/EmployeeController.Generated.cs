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

    [RoutePrefix("api/Employee")]
	public partial class EmployeeController : BaseWebAPIController 
	{

        /// <summary>
        /// The Employee bo
        /// </summary>
        private IEmployeeBO _EmployeeBO=null;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="EmployeeBO">The _ userbo.</param>
        public EmployeeController(IEmployeeBO  _varEmployeeBO)
        {
            _EmployeeBO = _varEmployeeBO;
        }


         /// <summary>
        /// Get the List ofEmployeedto.
        /// </summary>
        /// <param name="_EmployeeDto">The Employee dto.</param>
        /// <example><code> HTTP GET: api/Employee/?pageindex=1&pagesize=10&....</code></example>
        /// <returns>DatagridData List of EmployeeDto</returns>
        public object Get([FromUri] EmployeeDto _EmployeeDtos, int pageIndex = 1, int pageSize = 10)
        {
		    var pagedlist = new PagedList<EmployeeDto>  {_EmployeeDtos };
            pagedlist.PageIndex = pageIndex;
            pagedlist.PageSize = pageSize;
            return _EmployeeBO.FindAll(pagedlist);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <example><code>GET: api/Employee/5</code></example>
        /// <returns>EmployeeDto</returns>
        public EmployeeDto Get(Int32 id)
        {
            var dtoEntity = new EmployeeDto() { EmployeeID=id};
            return _EmployeeBO.GetEntiyByPK(dtoEntity);
        }

        /// <summary>
        /// Gets the Employee with aync 
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <example><code>GET: api/Employee/GetAync?pageindex=1&pagesize=10</code></example>
        /// <returns>EmployeeDto</returns>
        [HttpGet]
        [Route("GetAync")]
        public async Task<PagedList<EmployeeDto>> GetAync([FromUri] int pageIndex, int pageSize)
        {
            return await _EmployeeBO.FindEntiesAsync(pageIndex, pageSize);
        }

        // GET: api/Employee/GetAync?pageindex=1&pagesize=10
        [HttpGet]
        [Route("GetPageListAync")]
        [PagedListActionFilter] 
        public async Task<object> GetPageListAync()
        {
		    int index = Request.GetPageIndex();
            int size = Request.GetPageSize();
            var results = await _EmployeeBO.FindEntiesAsync(index, size);

            return new { Items = results, MetaData = results.GetMetaData() };
        }


        // POST: api/Employee
        [ValidateModel]
        public void Post(EmployeeDto value)
        {
            _EmployeeBO.CreateEntiy(value);
        }

        // PUT: api/Employee/
        [ValidateModel]
        public void Put(EmployeeDto value)
        {
            _EmployeeBO.UpdateWithAttachEntiy(value);
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            var entity = new EmployeeDto() { EmployeeID = id };
            _EmployeeBO.DeleteWithAttachEntiy(entity);
        }


        /// <summary>
        /// Deletes the specified identifier. 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <example>
        /// POST http://localhost:14488/api/Employee
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
                    var listEnties = new List<EmployeeDto>();
                    foreach (int i in id)
                    {
                        listEnties.Add(new EmployeeDto() { EmployeeID = i });
                    }
                    _EmployeeBO.DeleteWithAttachEntiy(listEnties.ToArray());
                }
            }
        }
	}
}

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

	public partial class EmployeePayHistoryController : BaseWebAPIController 
	{

        /// <summary>
        /// The EmployeePayHistory bo
        /// </summary>
        private IEmployeePayHistoryBO _EmployeePayHistoryBO=null;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeePayHistoryController"/> class.
        /// </summary>
        /// <param name="EmployeePayHistoryBO">The _ userbo.</param>
        public EmployeePayHistoryController(IEmployeePayHistoryBO  _varEmployeePayHistoryBO)
        {
            _EmployeePayHistoryBO = _varEmployeePayHistoryBO;
        }



        // GET: api/EmployeePayHistory/?pageindex=1&pagesize=10&....
        public EasyuiDatagridData<EmployeePayHistoryDto> Get([FromUri] EmployeePayHistoryDto _EmployeePayHistoryDto)
        {
           return  _EmployeePayHistoryBO.FindAll(_EmployeePayHistoryDto);
        }

		// GET: api/EmployeePayHistory/?pageindex=1&pagesize=10
        public EasyuiDatagridData<EmployeePayHistoryDto> Get([FromUri] int pageIndex, int pageSize)
        {
            return _EmployeePayHistoryBO.FindEnties(new EmployeePayHistoryDto { pageIndex=pageIndex,pageSize=pageSize});
        }

        // GET: api/EmployeePayHistory/5
        public EmployeePayHistoryDto Get(int id)
        {
            return _EmployeePayHistoryBO.GetEntiyByPK(id);
        }

        // POST: api/EmployeePayHistory
        [ValidateModel]
        public void Post(EmployeePayHistoryDto value)
        {
            _EmployeePayHistoryBO.CreateEntiy(value);
        }

        // PUT: api/EmployeePayHistory/
        [ValidateModel]
        public void Put(EmployeePayHistoryDto value)
        {
            _EmployeePayHistoryBO.UpdateWithAttachEntiy(value);
        }

        // DELETE: api/EmployeePayHistory/5
        public void Delete(int id)
        {
            var entity = new EmployeePayHistoryDto() { EmployeeID = id };
            _EmployeePayHistoryBO.DeleteWithAttachEntiy(entity);
        }

	}
}

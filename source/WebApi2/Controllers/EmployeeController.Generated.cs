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



        // GET: api/Employee/?pageindex=1&pagesize=10&....
        public EasyuiDatagridData<EmployeeDto> Get([FromUri] EmployeeDto _EmployeeDto)
        {
           return  _EmployeeBO.FindAll(_EmployeeDto);
        }

		// GET: api/Employee/?pageindex=1&pagesize=10
        public EasyuiDatagridData<EmployeeDto> Get([FromUri] int pageIndex, int pageSize)
        {
            return _EmployeeBO.FindEnties(new EmployeeDto { pageIndex=pageIndex,pageSize=pageSize});
        }

        // GET: api/Employee/5
        public EmployeeDto Get(int id)
        {
            return _EmployeeBO.GetEntiyByPK(id);
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

	}
}

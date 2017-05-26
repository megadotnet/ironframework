using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotCoreWebAPI.Models2;
using Microsoft.EntityFrameworkCore;
using DotCoreWebAPI.Converter;

namespace DotCoreWebAPI.Controllers
{
    /// <summary>
    /// EmployeeController
    /// </summary>
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        /// <summary>
        /// AdventureWorksContext
        /// </summary>
        private readonly AdventureWorksContext _context;
        /// <summary>
        /// EmployeeConverter
        /// </summary>
        private readonly EmployeeConverter employeeConverter = Singleton<EmployeeConverter>.Current as EmployeeConverter;

        /// <summary>
        /// EmployeeController
        /// </summary>
        /// <param name="context"></param>
        public EmployeeController(AdventureWorksContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all EmployeeDto   api/employee
        /// </summary>
        /// <returns>Employee</returns>
        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            var dbentities = _context.Employee.ToList();
            var employeedtos = new List<EmployeeDto>();
            dbentities.ForEach(c => employeedtos.Add(employeeConverter.ConvertEntitiesToDto(c)));
            return employeedtos;
        }


        /// <summary>
        /// Get EmployeeDto  api/employee/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EmployeeDto</returns>
        [HttpGet("{id}")]
        public EmployeeDto Get(int id)
        {
            var dbentities = _context.Employee.Where(e => e.EmployeeId == id);
            if (dbentities==null)
            {
                return null;
            }
            return employeeConverter.ConvertEntitiesToDto(dbentities.FirstOrDefault());
        }

    }
}

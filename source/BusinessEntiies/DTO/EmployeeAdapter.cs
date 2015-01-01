using IronFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntiies
{
    /// <summary>
    /// EmployeeAdapter
    /// </summary>
    public class EmployeeAdapter : TypeAdapter
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <typeparam name="S">Souce type</typeparam>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public override T Transform<S, T>(S source)
        {
            //TODO: The best approach that provider automatically revert method
            if (typeof(S).Equals(typeof(Employee)))
            {
                CreateMap<Employee, EmployeeDto>();
                //mapping child collection
                CreateMap<Contact, ContactDto>();
                CreateMap<EmployeePayHistory, EmployeePayHistoryDto>();
            }
            else
            {
                CreateMap<EmployeeDto, Employee>();
                //mapping child collection
                CreateMap<ContactDto, Contact>();
                CreateMap<EmployeePayHistoryDto, EmployeePayHistory>();
            }
            return GetTarget<S, T>(source);
        }
    }
}

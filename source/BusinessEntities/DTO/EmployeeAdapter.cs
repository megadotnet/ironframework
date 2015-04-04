namespace BusinessEntities.DTO
{
    using DataTransferObject;

    using IronFramework.Utility;

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
                this.CreateMap<Employee, EmployeeDto>();
                //mapping child collection
                this.CreateMap<Contact, ContactDto>();
                this.CreateMap<EmployeePayHistory, EmployeePayHistoryDto>();
            }
            else
            {
                this.CreateMap<EmployeeDto, Employee>();
                //mapping child collection
                this.CreateMap<ContactDto, Contact>();
                this.CreateMap<EmployeePayHistoryDto, EmployeePayHistory>();
            }
            return this.GetTarget<S, T>(source);
        }
    }
}

using BoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace WCFServiceClient
{
    /// <summary>
    /// EmployeeServiceClient
    /// </summary>
    public class EmployeeServiceClient : ClientBase<IEmployeeBoService>, IEmployeeBoService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeServiceClient"/> class.
        /// </summary>
        public EmployeeServiceClient()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeServiceClient"/> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public EmployeeServiceClient(Binding binding, EndpointAddress remoteAddress)
            : base(binding, remoteAddress)
        {
        }

        public bool CreateEmployee(BusinessEntities.Employee employee)
        {
            return base.Channel.CreateEmployee(employee);
        }

        public int CreateEmployee2(BusinessEntities.Employee employee)
        {
            return base.Channel.CreateEmployee2(employee);
        }

        public bool DelEmployee(BusinessEntities.Employee employee)
        {
            return base.Channel.DelEmployee(employee);
        }

        public IronFramework.Utility.UI.PagedList<BusinessEntities.Employee> FindEmployeeByTitle(string title, int? pageIndex, int pageSize, out int totalcount)
        {
            return base.Channel.FindEmployeeByTitle(title,pageIndex,pageSize,out totalcount);
        }

        public BusinessEntities.Employee GetEmployee(int pid)
        {
            return base.Channel.GetEmployee(pid);
        }

        public bool UpdateEmployee(BusinessEntities.Employee employee)
        {
            return base.Channel.UpdateEmployee(employee);
        }

        public IronFramework.Utility.UI.PagedList<BusinessEntities.Contact> GetPagedListContact(int? pageIndex, int pageSize, out int totalcount)
        {
            return base.Channel.GetPagedListContact(pageIndex,pageSize,out totalcount);
        }
    }
}

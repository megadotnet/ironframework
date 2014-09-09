using BoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace WCFServiceClient
{
    public class EmployeeServiceClient : ClientBase<IEmployeeBoService>, IEmployeeBoService
    {

        public EmployeeServiceClient()
            : base()
        {
        }

        public EmployeeServiceClient(Binding binding, EndpointAddress remoteAddress)
            : base(binding, remoteAddress)
        {
        }

        public bool CreateEmployee(BusinessEntiies.Employee employee)
        {
            return base.Channel.CreateEmployee(employee);
        }

        public int CreateEmployee2(BusinessEntiies.Employee employee)
        {
            return base.Channel.CreateEmployee2(employee);
        }

        public bool DelEmployee(BusinessEntiies.Employee employee)
        {
            return base.Channel.DelEmployee(employee);
        }

        public IronFramework.Utility.UI.PagedList<BusinessEntiies.Employee> FindEmployeeByTitle(string title, int? pageIndex, int pageSize, out int totalcount)
        {
            return base.Channel.FindEmployeeByTitle(title,pageIndex,pageSize,out totalcount);
        }

        public BusinessEntiies.Employee GetEmployee(int pid)
        {
            return base.Channel.GetEmployee(pid);
        }

        public bool UpdateEmployee(BusinessEntiies.Employee employee)
        {
            return base.Channel.UpdateEmployee(employee);
        }

        public IronFramework.Utility.UI.PagedList<BusinessEntiies.Contact> GetPagedListContact(int? pageIndex, int pageSize, out int totalcount)
        {
            return base.Channel.GetPagedListContact(pageIndex,pageSize,out totalcount);
        }
    }
}

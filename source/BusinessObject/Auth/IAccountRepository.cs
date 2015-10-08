using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Auth
{
    public interface IAccountRepository
    {
        string GetHashedPassword(string username);
    }
}

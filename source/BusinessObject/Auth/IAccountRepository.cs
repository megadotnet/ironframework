using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Gets the hashed password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        string GetHashedPassword(string username);
    }
}

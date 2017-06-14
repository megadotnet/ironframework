using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Web;

namespace BoService.Util
{
    /// <summary>
    /// UserAuthentication
    /// </summary>
    /// <see cref="http://www.codeproject.com/Articles/96028/WCF-Service-with-custom-username-password-authenti"/>
    /// <see cref="http://www.codeproject.com/Articles/698862/Custom-Authentication-and-Authorization-in-WCF"/>
    /// <seealso cref="http://www.codeproject.com/Articles/33872/Custom-Authorization-in-WCF"/>
    /// <seealso cref="http://www.cnblogs.com/chucklu/p/4685783.html"/>
    /// <seealso cref="http://www.codebetter.com/petervanooijen/2010/03/22/a-simple-wcf-service-with-username-password-authentication-the-things-they-don-t-tell-you/"/>
    public class UserAuthentication : UserNamePasswordValidator
    {
        /// <summary>
        /// When overridden in a derived class, validates the specified username and password.
        /// </summary>
        /// <param name="userName">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        /// <exception cref="System.ServiceModel.FaultException">Unknown Username or Incorrect Password</exception>
        public override void Validate(string userName, string password)
        {
            try
            {
                if (userName == "test" && password == "test123")
                {
                    Console.WriteLine("Authentic User");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new FaultException("Unknown Username or Incorrect Password");
            }
        }
    }
}
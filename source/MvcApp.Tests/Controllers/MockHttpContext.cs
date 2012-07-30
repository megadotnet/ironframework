// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockHttpContext.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The mock http context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcApp.Tests.Controllers
{
    using System.Security.Principal;
    using System.Web;

    /// <summary>
    /// The mock http context.
    /// </summary>
    internal class MockHttpContext : HttpContextBase
    {
        #region Constants and Fields

        /// <summary>
        /// The _user.
        /// </summary>
        private readonly IPrincipal _user;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockHttpContext"/> class.
        /// </summary>
        internal MockHttpContext()
        {
            this._user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets User.
        /// </summary>
        public override IPrincipal User
        {
            get
            {
                return this._user;
            }

            set
            {
                base.User = value;
            }
        }

        #endregion
    }
}
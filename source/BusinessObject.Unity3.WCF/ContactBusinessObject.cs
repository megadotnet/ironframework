// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactBusinessObject.cs" company="Megadotnet">
//   Iron Framework 
// </copyright>
// <summary>
//   The contact business object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DataAccessObject;

    /// <summary>
    /// ContactBusinessObject
    /// </summary>
    public class ContactBusinessObject : IContactBusinessObject
    {
        #region Constants and Fields

        private readonly ContactRepository contactRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactBusinessObject"/> class.
        /// </summary>
        public ContactBusinessObject()
        {
            contactRepository = RepositoryHelper.GetContactRepository();
        }

        #endregion


        /// <summary>
        /// Finds the contacts.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>PagedList entities</returns>
        public IronFramework.Utility.UI.PagedList<BusinessEntities.Contact> FindContacts(int? pageIndex, int pageSize)
        {
            return this.contactRepository.Repository.Find(null, e => e.ContactID, pageIndex, pageSize);
        }
    }
}

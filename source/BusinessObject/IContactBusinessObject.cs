// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContactBusinessObject.cs" company="Megadotnet">
//   Iron Framework 
// </copyright>
// <summary>
//   The interface of contact business object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using IronFramework.Utility.UI;
    using BusinessEntities;

    /// <summary>
    /// IContactBusinessObject
    /// </summary>
    public interface IContactBusinessObject
    {
        /// <summary>
        /// Finds the contacts.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>PagedList entities</returns>
        PagedList<Contact> FindContacts(int? pageIndex, int pageSize);
    }
}

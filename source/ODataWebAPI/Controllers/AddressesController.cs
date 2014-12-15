using BusinessEntiies;
using BusinessObject;
using DataAccessObject;
using IronFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;

namespace ODataWebAPI.Controllers
{
    /// <summary>
    /// AddressesController
    /// </summary>
    /// <seealso cref="http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/create-an-odata-v4-endpoint"/>
    public class AddressesController : ODataController
    {
        /// <summary>
        /// The database 
        /// </summary>
        private AddressRepository db = RepositoryHelper.GetAddressRepository();

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        public IQueryable<Address> Get()
        {
            return db.All().AsQueryable();
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        [EnableQuery]
        public SingleResult<Address> Get([FromODataUri] int key)
        {
            IQueryable<Address> result = db.Repository.Find(p => p.AddressID == key).AsQueryable();
            return SingleResult.Create(result);
        }
    }
}

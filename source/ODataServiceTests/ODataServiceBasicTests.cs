using System;
using System.Linq;
using AdventureWorksModel;
using Xunit;

namespace ODataServiceTests
{
    /// <summary>
    /// ODataServiceBasic Tests
    /// </summary>
    public class ODataServiceBasicTests
    {
        
        /// <summary>
        /// GetContactsCountByODataService
        /// </summary>
        [Fact]
        public void GetContactsCountByODataService()
        {
            var adventureWorksEntities = new AdventureWorksEntities(new Uri("http://localhost:1735/ODataService.svc/"));
            var contacts = adventureWorksEntities.Contacts.Take(2);
            Assert.NotNull(contacts);
            Assert.Equal(2,contacts.ToList().Count);
            Assert.NotNull(contacts.FirstOrDefault());
        }
    }
}

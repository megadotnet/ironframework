// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryTest.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The repository test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using DataAccessObject;
    using Moq;
    using IronFramework.Utility.UI;
    using System.Data;
    using Xunit;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Threading.Tasks;
    using BusinessEntities;

    /// <summary>
    /// The repository test.
    /// </summary>
    public class RepositoryTest
    {
        #region Public Methods

        /// <summary>
        /// Tests the add.
        /// </summary>
        [Fact]
        public void TestAdd()
        {
            //arrange
            var mockobject = new Mock<IRepository<Customer>>();
            mockobject.Setup(r => r.Add(It.IsAny<Customer>())).Verifiable();

            var customer = new Customer() { CustomerId = 1 };
            var mockRepository = mockobject.Object;

            //act
            mockRepository.Add(customer);

            //assert
            mockobject.VerifyAll();
        }

        /// <summary>
        /// Tests the attach.
        /// </summary>
        [Fact]
        public void TestAttach()
        {
            //arrange
            var mockobject = new Mock<IRepository<Customer>>();
            mockobject.Setup(r => r.Attach(It.IsAny<Customer>())).Verifiable();

            var customer = new Customer() { CustomerId = 1 };
            var mockRepository = mockobject.Object;

            //act
            mockRepository.Attach(customer);

            //assert
            mockobject.Verify(e=>e.Attach(customer));
        }

        /// <summary>
        /// Tests the delete.
        /// </summary>
         [Fact]
        public void TestDelete()
        {
            //arrange
            var mockobject = new Mock<IRepository<Customer>>();
            mockobject.Setup(r => r.Delete(It.IsAny<Customer>())).Verifiable();

            var customer = new Customer() { CustomerId = 1 };
            var mockRepository = mockobject.Object;

            //act
            mockRepository.Delete(customer);

            //assert
            mockobject.Verify(e => e.Delete(customer));
        }

         /// <summary>
         /// Tests the find.
         /// </summary>
        [Fact]
        public void TestFind()
        {
            //arrange
            var mockobject = new Mock<IRepository<Customer>>();
            mockobject.Setup(r => r.Add(It.IsAny<Customer>()));

            var customer = new Customer() { CustomerId = 1 };
            mockobject.Setup<IEnumerable<Customer>>(r => r.Find(c => c.CustomerId == customer.CustomerId))
                .Returns(new List<Customer>() { customer });

            var mockPagedlist = new PagedList<Customer>() { PageSize = 10, PageIndex = 1, TotalCount = 50 };
            for (int i = 0; i <= 10; i++)
            {
                mockPagedlist.Add(customer);
            }

            mockobject.Setup<IEnumerable<Customer>>(r => r.Find<int>(c => c.CustomerId == customer.CustomerId,c=>c.CustomerId,1,10))
                .Returns(mockPagedlist);

            var mockRepository = mockobject.Object;

            //act
            var clist = mockRepository.Find(c => c.CustomerId == customer.CustomerId);
            var cPagedlist = mockRepository.Find<int>(c => c.CustomerId == customer.CustomerId,c=>c.CustomerId,1,10);

            //assert
            Assert.NotNull(clist);
            Assert.True(clist.Count() > 0);

            Assert.NotNull(cPagedlist);
            Assert.Equal(10, cPagedlist.PageSize);
            Assert.Equal(1, cPagedlist.PageIndex);
            Assert.Equal(50, cPagedlist.TotalCount);
        }

        /// <summary>
        /// TestFindWithIQueryable with AsNoTracking
        /// </summary>
        /// <see cref="http://www.c-sharpcorner.com/UploadFile/ff2f08/entity-framework-and-asnotracking/"/>
        [Fact]
        public void TestFindWithIQueryable()
        {
            //arrange
            var mockobject = new Mock<IRepository<Customer>>();
            mockobject.Setup(r => r.Add(It.IsAny<Customer>()));

            var customer = new Customer() { CustomerId = 1 };
            mockobject.Setup<IEnumerable<Customer>>(r => r.Find(c => c.CustomerId == customer.CustomerId))
                .Returns(new List<Customer>() { customer });

            var mockPagedlist = new PagedList<Customer>() { PageSize = 10, PageIndex = 1, TotalCount = 50 };
            for (int i = 0; i <= 10; i++)
            {
                mockPagedlist.Add(customer);
            }

            mockobject.Setup<IEnumerable<Customer>>(r => r.Find<int>(c => c.CustomerId == customer.CustomerId, c => c.CustomerId, 1, 10))
                .Returns(mockPagedlist);

            var mockRepository = mockobject.Object;

            //act
            //Returns a new query where the entities returned will not be cached in the DbContext or ObjectContext.
            var clist = mockRepository.All().Where(c => c.CustomerId == customer.CustomerId).AsNoTracking().ToPagedList(1, 10);
            var cPagedlist = mockRepository.Find<int>(c => c.CustomerId == customer.CustomerId, c => c.CustomerId, 1, 10);

            //assert
            Assert.NotNull(clist);
            Assert.True(clist.Count() > 0);

            Assert.NotNull(cPagedlist);
            Assert.Equal(10, cPagedlist.PageSize);
            Assert.Equal(1, cPagedlist.PageIndex);
            Assert.Equal(50, cPagedlist.TotalCount);
        }

        /// <summary>
        /// Tests the Find async
        /// </summary>
        /// <see cref="http://stackoverflow.com/a/21256276/709066"/>
        [Fact]
        public async Task TestFindAsync()
        {
            //arrange
            var mockobject = new Mock<IRepository<Customer>>();
            mockobject.Setup(r => r.Add(It.IsAny<Customer>()));

            var customer = new Customer() { CustomerId = 1 };
            mockobject.Setup(r =>  r.FindAsync(c => c.CustomerId == customer.CustomerId))
                .ReturnsAsync(new List<Customer>() { customer });

            var mockRepository = mockobject.Object;

            //act
            var clist = await mockRepository.FindAsync(c => c.CustomerId == customer.CustomerId);
           
            //assert
            Assert.NotNull(clist);
            Assert.True(clist.Count() > 0);
        }


        /// <summary>
        /// Tests the save.
        /// </summary>
        [Fact]
        public void TestSave()
        {
            //arrange
            var mockobject = new Mock<IRepository<Customer>>();
            mockobject.Setup(r => r.Save()).Verifiable();

            var customer = new Customer() { CustomerId = 1 };
            var mockRepository = mockobject.Object;

            //act
            mockRepository.Save();

            //assert
            mockobject.Verify(e => e.Save());
        }

        /// <summary>
        /// TestSaveAsync
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestSaveAsync()
        {
            //arrange
            var mockobject = new Mock<IRepository<Customer>>();
            mockobject.Setup(r => r.Save()).Verifiable();

            var customer = new Customer() { CustomerId = 1 };
            var mockRepository = mockobject.Object;

            //act
            await mockRepository.SaveAsync();

            //assert
            mockobject.Verify(e => e.SaveAsync());
        }


        /// <summary>
        /// Tests the single.
        /// </summary>
        [Fact]
        public void TestFetchSingle()
        {
            //arrange
            var mockobject = new Mock<IRepository<Customer>>();
            mockobject.Setup(r => r.Single(It.IsAny<Expression<Func<Customer, bool>>>()));

            var customer = new Customer() { CustomerId = 2 };
            var mockRepository = mockobject.Object;

            //act
            mockRepository.Single(c=>c.CustomerId==2);

            //assert
            mockobject.Verify(r=> r.Single(c => c.CustomerId == 2));
        }

        /// <summary>
        /// TestEagerLoading
        /// </summary>
        [Fact]
        public void TestEagerLoading()
        {
            //arrange
            var mockobject = new Mock<IRepository<Employee>>();
            mockobject.Setup(r => r.All()).Returns(new List<Employee>().AsQueryable());

            var customer = new Employee() { EmployeeID = 2 };
            var mockRepository = mockobject.Object;

            //act
            mockRepository.All().Include(e => e.EmployeePayHistories);

            //assert
            mockobject.Verify(r => r.All().Include(e => e.EmployeePayHistories));
        }

        /// <summary>
        /// Tests the state of the object context_ change object.
        /// </summary>
        [Fact]
        public void TestObjectContext_ChangeObjectState()
        {
            //arrange
            var mockobject = new Mock<IObjectContext>();
            mockobject.Setup(i => i.ChangeObjectState(It.IsAny<Object>(), It.IsAny<EntityState>())).Verifiable();

            var mockobjectset = new Mock<IObjectSet<Customer>>();
            mockobject.Setup(i => i.CreateObjectSet<Customer>()).Returns(mockobjectset.Object);

            var customer = new Customer() { CustomerId = 1 };
            var mockObjectContext = mockobject.Object;

            //act
            mockObjectContext.ChangeObjectState(customer, EntityState.Modified);
            var objectset = mockObjectContext.CreateObjectSet<Customer>();

            //assert
            mockobject.VerifyAll();
            Assert.NotNull(objectset);
        }

        #endregion
    }
}
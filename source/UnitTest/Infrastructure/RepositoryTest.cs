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
        /// Tests the single.
        /// </summary>
        [Fact]
        public void TestSingle()
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
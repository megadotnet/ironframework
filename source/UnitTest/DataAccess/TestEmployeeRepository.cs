// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEmployeeRepository.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   Test EmployeeRepository 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using System.Collections.Generic;
    using System.Linq;
    using BusinessEntities;
    using DataAccessObject;
    using IronFramework.Utility.UI;
    using Xunit;
    using Xunit.Extensions;
    using System.Threading.Tasks;
    using UnitTest.Util;

    public class TestEmployeeRepository : TestEmployeeBase
    {
        #region Public Method
        /// <summary>
        /// The test employee repository add.
        /// </summary>
        [Fact]
        [AutoRollback]
        public void TestEmployeeRepositoryAdd()
        {
            Employee employee = this.CreateNewEmployee();
            EmployeeRepository employRepository = RepositoryHelper.GetEmployeeRepository();

            employRepository.Add(employee);
            employRepository.Save();

            // assert
            IEnumerable<Employee> employeelist =
                employRepository.Repository.Find(e => e.EmployeeID == employee.EmployeeID);
            Assert.NotNull(employeelist);
            Assert.NotNull(employeelist.SingleOrDefault());

            employRepository.Delete(employee);
            employRepository.Save();
        }

        /// <summary>
        /// The test employee repository add for object factory.
        /// </summary>
        [Fact][AutoRollback]
        public void TestEmployeeRepositoryAddForObjectFactory()
        {
            EmployeeRepository ep = RepositoryHelper.GetEmployeeRepository();
            Employee employee = this.CreateNewEmployee();
            ep.Add(employee);
            ep.Save();

            // assert
            IEnumerable<Employee> employeelist = ep.Repository.Find(e => e.EmployeeID == employee.EmployeeID);
            Assert.NotNull(employeelist);
            Assert.NotNull(employeelist.SingleOrDefault());

            ep.Delete(employee);
            ep.Save();
        }

        /// <summary>
        /// The test employee repository with unitofwork.
        /// </summary>
        [Fact][AutoRollback]
        public void TestEmployeeRepositoryWithUnitofwork()
        {
            Employee employee = this.CreateNewEmployee();
            IObjectContext context = RepositoryHelper.GetDbContext();
            IUnitOfWork uow = RepositoryHelper.GetUnitOfWork(context);
            EmployeeRepository employRepository = RepositoryHelper.GetEmployeeRepository(context);

            employRepository.Add(employee);
            uow.Save();

            // assert
            IEnumerable<Employee> employeelist =
                employRepository.Repository.Find(e => e.EmployeeID == employee.EmployeeID);
            Assert.NotNull(employeelist);
            Assert.NotNull(employeelist.SingleOrDefault());

            employRepository.Delete(employee);
            uow.Save();
        }

        /// <summary>
        /// The test get unitofwork from container.
        /// </summary>
        [Fact][AutoRollback]
        public void TestGetUnitofworkFromContainer()
        {
            EmployeeRepository employeeRepository1 = RepositoryHelper.GetEmployeeRepository();
            Assert.NotNull(employeeRepository1);

        }

        /// <summary>
        /// The test native api add.
        /// </summary>
        [Fact][AutoRollback]
        public void TestNativeAPIAdd()
        {
            // arrange
            Employee employee = this.CreateNewEmployee();
            var objectcontext = ObjectFactory.GetInstance<IObjectContext>();
            IUnitOfWork uow = new EFUnitOfWork(objectcontext);
            var ep = ObjectFactory.GetInstance<IRepository<Employee>>();

            // act
            ep.Add(employee);
            ep.Save();

            // assert
            IEnumerable<Employee> employeelist = ep.Find(e => e.EmployeeID == employee.EmployeeID);
            Assert.NotNull(employeelist);
            Assert.NotNull(employeelist.SingleOrDefault());

            // Clear
            ep.Delete(employee);
            ep.Save();
        }

        /// <summary>
        /// The test native api add 3.
        /// </summary>
        [Fact][AutoRollback]
        public void TestNativeAPIAdd3()
        {
            // arrange
            Employee employee = this.CreateNewEmployee();
            var ep = ObjectFactory.GetInstance<IRepository<Employee>>();

            // act
            ep.Add(employee);
            ep.Save();

            // assert
            IEnumerable<Employee> employeelist = ep.Find(e => e.EmployeeID == employee.EmployeeID);
            Assert.NotNull(employeelist);
            Assert.NotNull(employeelist.SingleOrDefault());
        }

        /// <summary>
        /// The test repository find.
        /// </summary>
        [Fact][AutoRollback]
        public void TestRepositoryFind()
        {
            Employee employee =
                RepositoryHelper.GetEmployeeRepository().Repository.Find(e => e.EmployeeID == 1).SingleOrDefault();
            Assert.NotNull(employee);

        }

        /// <summary>
        /// The test repository helper.
        /// </summary>
        [Fact][AutoRollback]
        public void TestRepositoryHelper()
        {
            EmployeeRepository employeeRepository1 = RepositoryHelper.GetEmployeeRepository();
            EmployeeRepository employeeRepository2 = RepositoryHelper.GetEmployeeRepository();
            Assert.NotNull(employeeRepository1);
            Assert.NotNull(employeeRepository2);


            // Just for singleon life manage
            // Assert.AreSame(employeeRepository1.Repository, employeeRepository2.Repository);
        }

        /// <summary>
        /// The test repository paging.
        /// </summary>
        [Fact][AutoRollback]
        public void TestRepositoryPaging()
        {
            EmployeeRepository ep = RepositoryHelper.GetEmployeeRepository();
            PagedList<Employee> pageset = ep.Repository.Find(e => e.EmployeeID > 1, e => e.EmployeeID, 2, 10);

            Assert.NotNull(pageset);
            Assert.Equal(10, pageset.Count());
        }

        /// <summary>
        /// The test repository paging 2.
        /// </summary>
        [Fact][AutoRollback]
        public void TestRepositoryPaging2()
        {
            EmployeeRepository ep = RepositoryHelper.GetEmployeeRepository();
            PagedList<Employee> pageset = ep.All().OrderBy(e => e.EmployeeID).AsQueryable().ToPagedList(1, 10);

            Assert.NotNull(pageset);
            Assert.Equal(10, pageset.Count());
        }

        /// <summary>
        /// The test repository paging 3.
        /// </summary>
        [Fact][AutoRollback]
        public void TestRepositoryPaging3()
        {
            EmployeeRepository ep = RepositoryHelper.GetEmployeeRepository();
            PagedList<Employee> pageset =
                ep.Repository.Find(e => e.EmployeeID > 1).OrderBy(e => e.EmployeeID).AsQueryable().ToPagedList(1, 10);

            Assert.NotNull(pageset);
            Assert.Equal(10, pageset.Count());
        }

        /// <summary>
        /// The test_ employee repository_ update.
        /// </summary>
        [Fact][AutoRollback]
        public void Test_EmployeeRepository_Update()
        {
            // arrange
            Employee employee = this.CreateNewEmployee();
            EmployeeRepository employRepository = RepositoryHelper.GetEmployeeRepository();

            // act
            employRepository.Add(employee);
            employRepository.Save();

            // assert
            IEnumerable<Employee> employeelist =
                RepositoryHelper.GetEmployeeRepository().Repository.Find(e => e.EmployeeID == employee.EmployeeID);
            Assert.NotNull(employeelist);

            Employee employee2 = employeelist.SingleOrDefault();
            Assert.NotNull(employee2);

            employee.Title = "ProjectManager";
            employRepository.Save();

            Employee employee3 =
                RepositoryHelper.GetEmployeeRepository().Repository.Find(e => e.EmployeeID == employee2.EmployeeID).
                    FirstOrDefault();
            Assert.NotNull(employee3);
            Assert.Equal(employee3.Title,"ProjectManager");

            employRepository.Delete(employee);
            employRepository.Save();
        }

        /// <summary>
        /// The test ef unitofwork native api.
        /// </summary>
        [Fact][AutoRollback]
        public void TestEFUnitofworkNativeAPI()
        {
            Employee employee = this.CreateNewEmployee();

            var objectcontext = ObjectFactory.GetInstance<IObjectContext>();
            IUnitOfWork uow = ObjectFactory.GetInstance<IUnitOfWork, IObjectContext>(objectcontext);
            IRepository<Employee> ep = ObjectFactory.GetInstance<IRepository<Employee>, IObjectContext>(objectcontext);

            ep.Add(employee);
            uow.Save();

            // assert
            IEnumerable<Employee> employeelist = ep.Find(e => e.EmployeeID == employee.EmployeeID);
            Assert.NotNull(employeelist);
            Assert.NotNull(employeelist.SingleOrDefault());

            ep.Delete(employee);
            uow.Save();
        }

        /// <summary>
        /// TestEFUnitofworkNativeAPIAsync
        /// </summary>
        /// <returns></returns>
        [Fact]
        [AutoRollback]
        public async Task TestEFUnitofworkNativeAPIAsync()
        {
            Employee employee = this.CreateNewEmployee();

            var objectcontext = ObjectFactory.GetInstance<IObjectContext>();
            IUnitOfWork uow = ObjectFactory.GetInstance<IUnitOfWork, IObjectContext>(objectcontext);
            IRepository<Employee> ep = ObjectFactory.GetInstance<IRepository<Employee>, IObjectContext>(objectcontext);

            ep.Add(employee);
            await uow.SaveAsync();

            // assert
            IEnumerable<Employee> employeelist = ep.Find(e => e.EmployeeID == employee.EmployeeID);
            Assert.NotNull(employeelist);
            Assert.NotNull(employeelist.SingleOrDefault());

            ep.Delete(employee);
            await uow.SaveAsync();
        }

        /// <summary>
        /// The test e fcontext.
        /// </summary>
        [Fact][AutoRollback]
        public void TestEFcontext()
        {
            Employee employee = this.CreateNewEmployee();
            var objectcontext = ObjectFactory.GetInstance<IObjectContext>();

            IRepository<Employee> ep = ObjectFactory.GetInstance<IRepository<Employee>, IObjectContext>(objectcontext);

            ep.Add(employee);
            objectcontext.SaveChanges();

            // assert
            IEnumerable<Employee> employeelist = ep.Find(e => e.EmployeeID == employee.EmployeeID);
            Assert.NotNull(employeelist);
            Assert.NotNull(employeelist.SingleOrDefault());

            ep.Delete(employee);
            objectcontext.SaveChanges();
        }

        #endregion
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryHelper.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The repository helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject
{
	public static class RepositoryHelper
	{
		public static IRepository<T> GetRepository<T>()
		{
			return ObjectFactory.GetInstance<IRepository<T>>();
		}

        public static IUnitOfWork GetUnitOfWork()
        {
            return ObjectFactory.GetInstance<IUnitOfWork, IObjectContext>(GetDbContext());
        }
		
		public static IUnitOfWork GetUnitOfWork(IObjectContext objectcontext)
		{
			return ObjectFactory.GetInstance<IUnitOfWork,IObjectContext>(objectcontext);
		}		
		
	    public static IObjectContext GetDbContext()
		{
			return ObjectFactory.GetInstance<IObjectContext>();
		}	
		
		
		public static AddressRepository GetAddressRepository()
		{
			return ObjectFactory.GetInstance<AddressRepository>();
		}
		
		public static AddressRepository GetAddressRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<AddressRepository, IObjectContext>(objectcontext);
        }


		public static ContactRepository GetContactRepository()
		{
			return ObjectFactory.GetInstance<ContactRepository>();
		}
		
		public static ContactRepository GetContactRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<ContactRepository, IObjectContext>(objectcontext);
        }


		public static EmployeeRepository GetEmployeeRepository()
		{
			return ObjectFactory.GetInstance<EmployeeRepository>();
		}
		
		public static EmployeeRepository GetEmployeeRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<EmployeeRepository, IObjectContext>(objectcontext);
        }


		public static EmployeePayHistoryRepository GetEmployeePayHistoryRepository()
		{
			return ObjectFactory.GetInstance<EmployeePayHistoryRepository>();
		}
		
		public static EmployeePayHistoryRepository GetEmployeePayHistoryRepository(IObjectContext objectcontext)
        {
            return ObjectFactory.GetInstance<EmployeePayHistoryRepository, IObjectContext>(objectcontext);
        }

    }
}

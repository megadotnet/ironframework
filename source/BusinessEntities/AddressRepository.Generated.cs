// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressRepository.cs" company="Megadotnet">
// Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The Address repository.
//   This file is auto generated and will be overwritten as soon as the template is executed
//   Do not modify this file...
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
namespace DataAccessObject
{  
    using System;
    using System.Linq;
    using System.Linq.Expressions;
	using System.Threading.Tasks;
    using System.Collections.Generic;
    using BusinessEntities;

    using IronFramework.Utility.UI;
 
	public partial class AddressRepository
	{
		private IRepository<Address> _repository {get;set;}
		public IRepository<Address> Repository
		{
			get { return _repository; }
			set { _repository = value; }
		}
		
		public AddressRepository(IRepository<Address> repository)
    	{
    		Repository = repository;
    	}
		
		/// <summary>
        /// Alls enties 
        /// </summary>
        /// <returns>Alls enties</returns>
		public IEnumerable<Address> All()
		{
			return Repository.All();
		}

		 /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		public void Add(Address entity)
		{
			Repository.Add(entity);
		}
		
		 /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		public void Attach(Address entity)
		{
		    Repository.Attach(entity);
		}
		
		/// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		public void Delete(Address entity)
		{
			Repository.Delete(entity);
		}

		/// <summary>
        /// Saves this instance.
        /// </summary>
		public void Save()
		{
			Repository.Save();
		}

		/// <summary>
        /// SaveAsync
        /// </summary>
        public async Task<int> SaveAsync()
        {
            return await Repository.SaveAsync();
        }
	}
}
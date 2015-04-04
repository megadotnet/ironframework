// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeePayHistoryRepository.cs" company="Megadotnet">
// Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The EmployeePayHistory repository.
//   This file is auto generated and will be overwritten as soon as the template is executed
//   Do not modify this file...
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
namespace DataAccessObject
{  
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using BusinessEntities;

    using IronFramework.Utility.UI;
 
	public partial class EmployeePayHistoryRepository
	{
		private IRepository<EmployeePayHistory> _repository {get;set;}
		public IRepository<EmployeePayHistory> Repository
		{
			get { return _repository; }
			set { _repository = value; }
		}
		
		public EmployeePayHistoryRepository(IRepository<EmployeePayHistory> repository)
    	{
    		Repository = repository;
    	}
		
		/// <summary>
        /// Alls enties 
        /// </summary>
        /// <returns>Alls enties</returns>
		public IEnumerable<EmployeePayHistory> All()
		{
			return Repository.All();
		}

		 /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		public void Add(EmployeePayHistory entity)
		{
			Repository.Add(entity);
		}
		
		 /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		public void Attach(EmployeePayHistory entity)
		{
		    Repository.Attach(entity);
		}
		
		/// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
		public void Delete(EmployeePayHistory entity)
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
	}
}
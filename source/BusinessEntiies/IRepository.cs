
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Megadonet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   a interface of data acccess repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using IronFramework.Utility.UI;

    /// <summary>
    /// a interface of data acccess repository.
    /// </summary>
    /// <typeparam name="T">entity</typeparam>
    public interface IRepository<T>
    {
        #region Public Methods

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Add(T entity);

        /// <summary>
        /// Get all dataset
        /// </summary>
        /// <returns>
        /// collection of entits
        /// </returns>
        IEnumerable<T> All();

        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Attach(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Delete(T entity);

        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// IEmunerable entites
        /// </returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Finds the specified where expression
        /// </summary>
        /// <typeparam name="K">
        /// K is Key type of sort column  
        /// </typeparam>
        /// <param name="whereExpression">
        /// The where expression.
        /// </param>
        /// <param name="orderexpression">
        /// The orderexpression.
        /// </param>
        /// <param name="pageIndex">
        /// Index of the page.
        /// </param>
        /// <param name="pageSize">
        /// Size of the page.
        /// </param>
        /// <returns>
        /// List of entitis 
        /// </returns>
        PagedList<T> Find<K>(
            Expression<Func<T, bool>> whereExpression, 
            Expression<Func<T, K>> orderexpression, 
            int? pageIndex, 
            int pageSize);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        /// <summary>
        /// Singles the specified where.
        /// </summary>
        /// <param name="where">
        /// The where.
        /// </param>
        /// <returns>
        /// Single entity
        /// </returns>
        T Single(Expression<Func<T, bool>> where);

        #endregion
    }
}


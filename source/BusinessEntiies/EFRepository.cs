// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EFRepository.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   EFRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using System.Linq.Expressions;

    using IronFramework.Utility.UI;

    /// <summary>
    /// EFRepository
    /// </summary>
    /// <typeparam name="T">entity</typeparam>
    public class EFRepository<T> : IRepository<T>
        where T : class
    {
        #region Constants and Fields

        /// <summary>
        /// The _object context.
        /// </summary>
        private readonly IObjectContext _objectContext;

        /// <summary>
        /// The _objectset.
        /// </summary>
        private readonly IObjectSet<T> _objectset;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepository{T}"/> class. 
        /// Initializes a new instance of the <see cref="EFRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="objectContext">
        /// The object context.
        /// </param>
        public EFRepository(IObjectContext objectContext)
        {
            this._objectset = objectContext.CreateObjectSet<T>();
            this._objectContext = objectContext;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the object set.
        /// </summary>
        /// <value>The object set.</value>
        private IObjectSet<T> ObjectSet
        {
            get
            {
                return this._objectset;
            }
        }

        #endregion

        #region Implemented Interfaces

        #region IRepository<T>

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Add(T entity)
        {
            this.ObjectSet.AddObject(entity);
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>
        /// collection of entities
        /// </returns>
        public virtual IEnumerable<T> All()
        {
            return this.ObjectSet.AsQueryable();
        }

        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Attach(T entity)
        {
            this.ObjectSet.Attach(entity);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Delete(T entity)
        {
            this.ObjectSet.DeleteObject(entity);
        }

        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// colloection of entities
        /// </returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.ObjectSet.Where(expression);
        }

        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <typeparam name="K">
        /// Order by column
        /// </typeparam>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="orderExpression">
        /// The order expression.
        /// </param>
        /// <param name="pageIndex">
        /// Index of the page.
        /// </param>
        /// <param name="pageSize">
        /// Size of the page.
        /// </param>
        /// <returns>
        /// Entities paged list
        /// </returns>
        public PagedList<T> Find<K>(
            Expression<Func<T, bool>> expression, Expression<Func<T, K>> orderExpression, int? pageIndex, int pageSize)
        {
            if (expression == null)
            {
                return this.ObjectSet.AsQueryable().OrderBy(orderExpression).ToPagedList(pageIndex, pageSize);
            }

            return this.ObjectSet.Where(expression).OrderBy(orderExpression).AsQueryable().ToPagedList(
                pageIndex, pageSize);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            this._objectContext.SaveChanges();
        }

        /// <summary>
        /// Singles the specified where.
        /// </summary>
        /// <param name="where">
        /// The where.
        /// </param>
        /// <returns>
        /// single entity
        /// </returns>
        public T Single(Expression<Func<T, bool>> where)
        {
            return this.ObjectSet.SingleOrDefault(where);
        }

        #endregion

        #endregion
    }
}
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
	using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using System.Linq.Expressions;
	using System.Threading.Tasks;

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
        public virtual IQueryable<T> All()
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
        /// FindAsync
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>async task  IEmunerable entites</returns>
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await this.ObjectSet.Where(expression).ToListAsync();
        }
		
		/// <summary>
        /// Finds the specified expression with aync
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="orderExpression">The order expression.</param>
        /// <param name="isOrderByDesc">if set to <c>true</c> [is order by desc].</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindAsync<K>(
           Expression<Func<T, bool>> expression, Expression<Func<T, K>> orderExpression, bool isOrderByDesc
        )
        {
              if (expression == null)
            {
                if (isOrderByDesc)
                {
                    return await this.ObjectSet.AsQueryable().OrderByDescending(orderExpression).ToListAsync();
                }
                return await this.ObjectSet.AsQueryable().OrderBy(orderExpression).ToListAsync();
            }

            if (isOrderByDesc)
            {
                return await this.ObjectSet.Where(expression).OrderByDescending(orderExpression).ToListAsync();
            }
            return  await this.ObjectSet.Where(expression).OrderBy(orderExpression).ToListAsync();      
       }  

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
        public async Task<PagedList<T>> FindAsync<K>(
            Expression<Func<T, bool>> whereExpression,
            Expression<Func<T, K>> orderexpression,
            int? pageIndex,
            int pageSize)
        {
            return await FindAsync<K>(expression: whereExpression, orderExpression: orderexpression
                , isOrderByDesc: true, pageIndex: pageIndex, pageSize: pageSize);
        }

        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="orderExpression">The order expression.</param>
        /// <param name="isOrderByDesc">if set to <c>true</c> [is order by desc].</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Entities paged list</returns>
        public async Task<PagedList<T>> FindAsync<K>(
         Expression<Func<T, bool>> expression, Expression<Func<T, K>> orderExpression
         , bool isOrderByDesc, int? pageIndex, int pageSize)
        {
            List<T> list = null;
            if (expression == null)
            {
                if (isOrderByDesc)
                {
                    list = await this.ObjectSet.AsQueryable().OrderByDescending(orderExpression).ToListAsync();
                    return list.AsQueryable().ToPagedList(pageIndex, pageSize);
                }
                list = await this.ObjectSet.AsQueryable().OrderBy(orderExpression).ToListAsync();
                return list.AsQueryable().ToPagedList(pageIndex, pageSize);
            }

            if (isOrderByDesc)
            {
                list = await this.ObjectSet.Where(expression).OrderByDescending(orderExpression).ToListAsync();
                return list.AsQueryable().ToPagedList(pageIndex, pageSize);
            }
            list = await this.ObjectSet.Where(expression).OrderBy(orderExpression).ToListAsync();
            return list.AsQueryable().ToPagedList(pageIndex, pageSize);
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
            return this.Find(expression: expression, orderExpression: orderExpression
                ,isOrderByDesc:true, pageIndex: pageIndex, pageSize: pageSize);
        }

        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="orderExpression">The order expression.</param>
        /// <param name="isOrderByDesc">if set to <c>true</c> [is order by desc].</param>
        /// <returns></returns>
        public IEnumerable<T> Find<K>(
                Expression<Func<T, bool>> expression, Expression<Func<T, K>> orderExpression, bool isOrderByDesc
                )
        {
            if (expression == null)
            {
                if (isOrderByDesc)
                {
                    return this.ObjectSet.AsQueryable().OrderByDescending(orderExpression);
                }
                return this.ObjectSet.AsQueryable().OrderBy(orderExpression);
            }

            if (isOrderByDesc)
            {
                return this.ObjectSet.Where(expression).OrderByDescending(orderExpression);
            }
            return this.ObjectSet.Where(expression).OrderBy(orderExpression);
        }

        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="orderExpression">The order expression.</param>
        /// <param name="isOrderByDesc">if set to <c>true</c> [is order by desc].</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Entities paged list</returns>
        public PagedList<T> Find<K>(
                Expression<Func<T, bool>> expression, Expression<Func<T, K>> orderExpression, bool isOrderByDesc
                , int? pageIndex, int pageSize)
          {
            if (expression == null)
            {
                if (isOrderByDesc)
                {
                    return this.ObjectSet.AsQueryable().OrderByDescending(orderExpression).ToPagedList(pageIndex, pageSize);
                }
                return this.ObjectSet.AsQueryable().OrderBy(orderExpression).ToPagedList(pageIndex, pageSize);   
            }

            if (isOrderByDesc)
            {
                return this.ObjectSet.Where(expression).OrderByDescending(orderExpression).AsQueryable().ToPagedList(
                    pageIndex, pageSize);
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
        /// SaveAsync
        /// </summary>
        /// <returns>int</returns>
        public async Task<int> SaveAsync()
        {
            return await this._objectContext.SaveChangesAsync();
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
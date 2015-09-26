// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Megdotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   IUnitOfWork
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
	using System.Collections;
    using System.Linq;
	using System.Threading.Tasks;
	using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
	using EntityFramework.BulkInsert.Extensions;

    /// <summary>
    /// IUnitOfWork interface
    /// </summary>
    public interface IUnitOfWork
    {
        #region Public Methods

        /// <summary>
        /// The save.
        /// </summary>
        void Save();

	    /// <summary>
        /// SaveAsync
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();

        #endregion
    }

    /// <summary>
    /// IObjectContext interface
    /// </summary>
    public interface IObjectContext : IDisposable
    {
	    /// <summary>
        /// Gets or sets a value indicating whether [lazy loading enabled].
        /// </summary>
        /// <value><c>true</c> if [lazy loading enabled]; otherwise, <c>false</c>.</value>
        bool LazyLoadingEnabled {get;set; }

        /// <summary>
        /// Gets or sets a value indicating whether [proxy creation enabled].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [proxy creation enabled]; otherwise, <c>false</c>.
        /// </value>
        bool ProxyCreationEnabled { get; set; }

        #region Public Methods

        /// <summary>
        /// The change object state.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="entityState">
        /// The entity state.
        /// </param>
        void ChangeObjectState(object entity, EntityState entityState);

        /// <summary>
        /// Changes the state of the object.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="entityState">State of the entity.</param>
        void ChangeObjectState<TEntity>(TEntity entity, EntityState entityState) where TEntity : class;

        /// <summary>
        /// The create object set.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// IObjectSet generic T
        /// </returns>
        IObjectSet<T> CreateObjectSet<T>() where T : class;

		    /// <summary>
        /// Executes the function or sproc
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>affect rows</returns>
        int ExecuteFunction(string functionName, params ObjectParameter[] parameters);
        
        /// <summary>
        /// ExecuteStoreCommand
        /// </summary>
        /// <param name="commandText">sqltest</param>
        /// <param name="parameters">parameters</param>
        /// <returns>affect rows</returns>
        int ExecuteStoreCommand(string commandText, params object[] parameters);

        /// <summary>
        /// Executes the store query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
         ObjectResult<T> ExecuteStoreQuery<T>(string commandText, params object[] parameters);

		 /// <summary>
         /// Bulk Insert
         /// </summary>
         /// <typeparam name="TEntity">The type of the entity.</typeparam>
         /// <param name="entities">The entities.</param>
         void BulkInsert<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        /// <summary>
        /// The save changes.
        /// </summary>
        void SaveChanges();

		/// <summary>
        /// SaveChangesAsync 
        /// </summary>
        Task<int> SaveChangesAsync();

        #endregion
    }

    /// <summary>
    /// ObjectContextAdapter
    /// </summary>
    public class ObjectContextAdapter : IObjectContext
    {
        #region Constants and Fields

        /// <summary>
        /// The object context.
        /// </summary>
        private readonly ObjectContext _context;

        /// <summary>
        /// The current database context
        /// </summary>
        private DbContext currentDbContext;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectContextAdapter"/> class.
        /// </summary>
        /// <param name="dbcontext">
        /// The dbcontext.
        /// </param>
        public ObjectContextAdapter(DbContext dbcontext)
        {
            this._context = (dbcontext as IObjectContextAdapter).ObjectContext;
            currentDbContext = dbcontext;
        }

        #endregion

        #region Implemented Interfaces

        #region IDisposable

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this._context.Dispose();
        }

        #endregion

        #region IObjectContext

		    /// <summary>
        /// Gets or sets a value indicating whether [lazy loading enabled].
        /// </summary>
        /// <value><c>true</c> if [lazy loading enabled]; otherwise, <c>false</c>.</value>
        public bool LazyLoadingEnabled
        {
            get
            {
                return this._context.ContextOptions.LazyLoadingEnabled;
            }
            set
            {
                this._context.ContextOptions.LazyLoadingEnabled = value;
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [proxy creation enabled].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [proxy creation enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool ProxyCreationEnabled
        {
            get
            {
                return this._context.ContextOptions.ProxyCreationEnabled;
            }
            set
            {
                this._context.ContextOptions.ProxyCreationEnabled = value;
            }
        }

        /// <summary>
        /// Changes the state of the object.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="entityState">
        /// State of the entity.
        /// </param>
        /// <remarks>EF4 or EF5</remarks>
        public void ChangeObjectState(object entity, EntityState entityState)
        {
            this._context.ObjectStateManager.ChangeObjectState(entity, entityState);
        }


        /// <summary>
        /// Changes the state of the object for EF6
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="entityState">State of the entity.</param>
        public void ChangeObjectState<TEntity>(TEntity entity, EntityState entityState)  where TEntity : class
        {
            this.currentDbContext.Entry<TEntity>(entity).State = entityState;
        }

        /// <summary>
        /// Creates the object set.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return this._context.CreateObjectSet<T>();
        }

		    /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>affect rows</returns>
        public int ExecuteFunction(string functionName, params ObjectParameter[] parameters)
        {
            return this._context.ExecuteFunction(functionName, parameters);
        }
        
        /// <summary>
        /// ExecuteStoreCommand
        /// </summary>
        /// <param name="commandText">sqltest</param>
        /// <param name="parameters">parameters</param>
        /// <returns>affect rows</returns>
        public int ExecuteStoreCommand(string commandText, params object[] parameters)
        {
            return this._context.ExecuteStoreCommand(commandText, parameters);
        }

         /// <summary>
        /// Executes the store query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public ObjectResult<T> ExecuteStoreQuery<T>(string commandText, params object[] parameters)
        {
            return _context.ExecuteStoreQuery<T>( commandText,parameters);
        }

		 /// <summary>
        /// Bulk Insert 
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        public void BulkInsert<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            this.currentDbContext.BulkInsert<TEntity>(entities);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

		/// <summary>
        /// SaveChangesAsync 
        /// </summary>
        public async Task<int> SaveChangesAsync()
        {
            return await this._context.SaveChangesAsync();
        }

        #endregion

        #endregion
    }

    public class FakeContextAdapter : IObjectContext
    {
        #region Constants and Fields

        /// <summary>
        /// The object context.
        /// </summary>
        //private readonly IObjectContext _context;

        /// <summary>
        /// The current database context
        /// </summary>
        //private DbContext currentDbContext;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// https://effort.codeplex.com/wikipage?title=Create%20a%20fake%20DbContext%20instance&referringTitle=Tutorials
        /// </summary>
        public FakeContextAdapter()
        {
           // DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
           // currentDbContext = new MessageCenterEntities(connection);
           // this._context = (currentDbContext as IObjectContextAdapter).ObjectContext;

            //System.Data.Entity.Core.EntityClient.EntityConnection connection = Effort.EntityConnectionFactory.CreateTransient("name=MessageCenterEntities");
            //this.currentDbContext  = new BusinessEntities.MessageCenterEntities(connection);
            //this._context = (currentDbContext as IObjectContextAdapter).ObjectContext;
        }

        #endregion

        #region Implemented Interfaces

        #region IDisposable

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            
        }

        #endregion

        #region IObjectContext

        /// <summary>
        /// Gets or sets a value indicating whether [lazy loading enabled].
        /// </summary>
        /// <value><c>true</c> if [lazy loading enabled]; otherwise, <c>false</c>.</value>
        public bool LazyLoadingEnabled
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets a value indicating whether [proxy creation enabled].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [proxy creation enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool ProxyCreationEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Changes the state of the object.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="entityState">
        /// State of the entity.
        /// </param>
        /// <remarks>EF4 or EF5</remarks>
        public void ChangeObjectState(object entity, EntityState entityState)
        {
           
        }


        /// <summary>
        /// Changes the state of the object for EF6
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="entityState">State of the entity.</param>
        public void ChangeObjectState<TEntity>(TEntity entity, EntityState entityState) where TEntity : class
        {
           
        }

        /// <summary>
        /// Creates the object set.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return new MockObjectSet<T>();
        }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>affect rows</returns>
        public int ExecuteFunction(string functionName, params ObjectParameter[] parameters)
        {
            return 0;
        }

        /// <summary>
        /// ExecuteStoreCommand
        /// </summary>
        /// <param name="commandText">sqltest</param>
        /// <param name="parameters">parameters</param>
        /// <returns>affect rows</returns>
        public int ExecuteStoreCommand(string commandText, params object[] parameters)
        {
            return 0;
        }

        /// <summary>
        /// Executes the store query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public ObjectResult<T> ExecuteStoreQuery<T>(string commandText, params object[] parameters)
        {
            return null;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
         
        }

		 public void BulkInsert<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
           
        }

		public Task<int> SaveChangesAsync()
        {
            return Task.Factory.StartNew<int>(()=> { return 1; });
        }

        #endregion

        #endregion
    }

    public partial class MockObjectSet<T> : IObjectSet<T> where T : class
    {
        private readonly IList<T> collection = new List<T>();

        #region IObjectSet<T> Members

        public void AddObject(T entity)
        {
            collection.Add(entity);
        }

        public void Attach(T entity)
        {
            collection.Add(entity);
        }

        public void DeleteObject(T entity)
        {
            collection.Remove(entity);
        }

        public void Detach(T entity)
        {
            collection.Remove(entity);
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        #endregion

        #region IQueryable<T> Members

        public Type ElementType
        {
            get { return typeof(T); }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return collection.AsQueryable<T>().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return collection.AsQueryable<T>().Provider; }
        }

        #endregion
    }

	public class TestDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public TestDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestDbAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute(expression));
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }
    }

    public class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public TestDbAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<T>(this); }
        }
    }

    public class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public TestDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    } 
}
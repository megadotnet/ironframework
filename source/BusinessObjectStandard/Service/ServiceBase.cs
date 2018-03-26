using IronFramework.Common.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BusinessObjectStandard.Service
{

    /// <summary>
    /// Service<TEntity>
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        /// <summary>
        /// The repository
        /// </summary>
        protected readonly IRepository<TEntity> Repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected Service(IRepository<TEntity> repository)
            => Repository = repository;

        /// <summary>
        /// Attaches the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Attach(TEntity item)
            => Repository.Attach(item);

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Delete(TEntity item)
            => Repository.Delete(item);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default)
                    => await Repository.DeleteAsync(keyValues, cancellationToken);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
                    => await Repository.DeleteAsync(keyValue, cancellationToken);

        /// <summary>
        /// Detaches the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Detach(TEntity item)
                    => Repository.Detach(item);

        /// <summary>
        /// Existses the asynchronous.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> ExistsAsync(object[] keyValues, CancellationToken cancellationToken = default)
                    => await Repository.ExistsAsync(keyValues, cancellationToken);

        /// <summary>
        /// Existses the asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> ExistsAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
                    => await Repository.ExistsAsync(keyValue, cancellationToken);

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default)
                    => await Repository.FindAsync(keyValues, cancellationToken);

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
                    => await Repository.FindAsync(keyValue, cancellationToken);

        /// <summary>
        /// Inserts the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Insert(TEntity item)
                    => Repository.Insert(item);

        /// <summary>
        /// Loads the property asynchronous.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="property">The property.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property, CancellationToken cancellationToken = default)
                    => await Repository.LoadPropertyAsync(item, property, cancellationToken);

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <returns></returns>
        public virtual IQuery<TEntity> Query()
                    => Repository.Query();

        /// <summary>
        /// Queryables this instance.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Queryable()
                    => Repository.Queryable();

        /// <summary>
        /// Queryables the SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> QueryableSql(string sql, params object[] parameters)
                    => Repository.QueryableSql(sql, parameters);

        /// <summary>
        /// Selects the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> SelectAsync(CancellationToken cancellationToken = default)
                    => await Repository.Query().SelectAsync(cancellationToken);

        /// <summary>
        /// Selects the SQL asynchronous.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> SelectSqlAsync(string sql, object[] parameters, CancellationToken cancellationToken = default)
                    => await Repository.Query().SelectSqlAsync(sql, parameters, cancellationToken);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Update(TEntity item)
                    => Repository.Update(item);
    }
}

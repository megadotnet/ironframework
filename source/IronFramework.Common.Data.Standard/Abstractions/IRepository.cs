#region

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace IronFramework.Common.Data.Abstractions
{
    /// <summary>
    /// IRepository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TEntity> FindAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default);

        /// <summary>
        /// Existses the asynchronous.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<bool> ExistsAsync(object[] keyValues, CancellationToken cancellationToken = default);

        /// <summary>
        /// Existses the asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<bool> ExistsAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default);
        /// <summary>
        /// Loads the property asynchronous.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="property">The property.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property, CancellationToken cancellationToken = default);
        /// <summary>

        /// Attaches the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Attach(TEntity item);

        /// <summary>
        /// Detaches the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Detach(TEntity item);

        /// <summary>
        /// Inserts the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Insert(TEntity item);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Update(TEntity item);

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Delete(TEntity item);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<bool> DeleteAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default);

        /// <summary>
        /// Queryables this instance.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Queryable();

        /// <summary>
        /// Queryables the SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IQueryable<TEntity> QueryableSql(string sql, params object[] parameters);

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <returns></returns>
        IQuery<TEntity> Query();
    }
}
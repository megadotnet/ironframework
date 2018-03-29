using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace IronFramework.Common.Data.Abstractions
{
    /// <summary>
    /// IQuery
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IQuery<TEntity> where TEntity : class
    {
        /// <summary>
        /// Wheres the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        IQuery<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Includes the specified navigation property.
        /// </summary>
        /// <param name="navigationProperty">The navigation property.</param>
        /// <returns></returns>
        IQuery<TEntity> Include(Expression<Func<TEntity, object>> navigationProperty);

        /// <summary>
        /// Orders the by.
        /// </summary>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        IQuery<TEntity> OrderBy(Expression<Func<TEntity, object>> keySelector);

        /// <summary>
        /// Orders the by descending.
        /// </summary>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        IQuery<TEntity> OrderByDescending(Expression<Func<TEntity, object>> keySelector);

        /// <summary>
        /// Selects the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> SelectAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Skips the specified skip.
        /// </summary>
        /// <param name="skip">The skip.</param>
        /// <returns></returns>
        IQuery<TEntity> Skip(int skip);

        /// <summary>
        /// Takes the specified take.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        IQuery<TEntity> Take(int take);

        /// <summary>
        /// Thens the by.
        /// </summary>
        /// <param name="thenBy">The then by.</param>
        /// <returns></returns>
        IQuery<TEntity> ThenBy(Expression<Func<TEntity, object>> thenBy);

        /// <summary>
        /// Thens the by descending.
        /// </summary>
        /// <param name="thenByDescending">The then by descending.</param>
        /// <returns></returns>
        IQuery<TEntity> ThenByDescending(Expression<Func<TEntity, object>> thenByDescending);

        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> CountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Firsts the or default asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        /// <summary>
        /// Singles the or default asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        /// <summary>
        /// Selects the SQL asynchronous.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> SelectSqlAsync(string sql, object[] parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Anies the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        /// <summary>
        /// Anies the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<bool> AnyAsync(CancellationToken cancellationToken);
    }
}
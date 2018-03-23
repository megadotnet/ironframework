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
        IQuery<TEntity> Include(Expression<Func<TEntity, object>> navigationProperty);
        IQuery<TEntity> OrderBy(Expression<Func<TEntity, object>> keySelector);
        IQuery<TEntity> OrderByDescending(Expression<Func<TEntity, object>> keySelector);
        Task<IEnumerable<TEntity>> SelectAsync(CancellationToken cancellationToken = default);
        IQuery<TEntity> Skip(int skip);
        IQuery<TEntity> Take(int take);
        IQuery<TEntity> ThenBy(Expression<Func<TEntity, object>> thenBy);
        IQuery<TEntity> ThenByDescending(Expression<Func<TEntity, object>> thenByDescending);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> SelectSqlAsync(string sql, object[] parameters, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<bool> AnyAsync(CancellationToken cancellationToken);
    }
}
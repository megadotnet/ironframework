using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IronFramework.Common.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace IronFramework.Common.Data.Implementation.EF
{
    /// <summary>
    /// Query
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class Query<TEntity> : IQuery<TEntity> where TEntity : class
    {
        private int? _skip;
        private int? _take;
        private IQueryable<TEntity> _query;
        private IOrderedQueryable<TEntity> _orderedQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="Query{TEntity}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public Query(IRepository<TEntity> repository) => _query = repository.Queryable();

        /// <summary>
        /// Wheres the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public virtual IQuery<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
            => Set(q => q._query = q._query.Where(predicate));

        /// <summary>
        /// Includes the specified navigation property.
        /// </summary>
        /// <param name="navigationProperty">The navigation property.</param>
        /// <returns></returns>
        public virtual IQuery<TEntity> Include(Expression<Func<TEntity, object>> navigationProperty)
            => Set(q => q._query = q._query.Include(navigationProperty));

        /// <summary>
        /// Orders the by.
        /// </summary>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        public virtual IQuery<TEntity> OrderBy(Expression<Func<TEntity, object>> keySelector)
        {
            if (_orderedQuery == null) _orderedQuery = _query.OrderBy(keySelector);
            else _orderedQuery.OrderBy(keySelector);
            return this;
        }

        /// <summary>
        /// Thens the by.
        /// </summary>
        /// <param name="thenBy">The then by.</param>
        /// <returns></returns>
        public virtual IQuery<TEntity> ThenBy(Expression<Func<TEntity, object>> thenBy)
            => Set(q => q._orderedQuery.ThenBy(thenBy));

        /// <summary>
        /// Orders the by descending.
        /// </summary>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        public virtual IQuery<TEntity> OrderByDescending(Expression<Func<TEntity, object>> keySelector)
        {
            if (_orderedQuery == null) _orderedQuery = _query.OrderByDescending(keySelector);
            else _orderedQuery.OrderByDescending(keySelector);
            return this;
        }

        /// <summary>
        /// Thens the by descending.
        /// </summary>
        /// <param name="thenByDescending">The then by descending.</param>
        /// <returns></returns>
        public virtual IQuery<TEntity> ThenByDescending(Expression<Func<TEntity, object>> thenByDescending)
            => Set(q => q._orderedQuery.ThenByDescending(thenByDescending));

        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
                    => await _query.CountAsync(cancellationToken);

        /// <summary>
        /// Skips the specified skip.
        /// </summary>
        /// <param name="skip">The skip.</param>
        /// <returns></returns>
        public virtual IQuery<TEntity> Skip(int skip)
                    => Set(q => q._skip = skip);

        /// <summary>
        /// Takes the specified take.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public virtual IQuery<TEntity> Take(int take)
                    => Set(q => q._take = take);

        /// <summary>
        /// Selects the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> SelectAsync(CancellationToken cancellationToken = default)
        {
            _query = _orderedQuery ?? _query;

            if (_skip.HasValue) _query = _query.Skip(_skip.Value);
            if (_take.HasValue) _query = _query.Take(_take.Value);

            return await _query.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Firsts the or default asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
                    => await _query.FirstOrDefaultAsync(predicate, cancellationToken);

        /// <summary>
        /// Singles the or default asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
                    => await _query.SingleOrDefaultAsync(predicate, cancellationToken);

        /// <summary>
        /// Anies the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
                    => await _query.AnyAsync(predicate, cancellationToken);

        /// <summary>
        /// Anies the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> AnyAsync(CancellationToken cancellationToken)
                    => await _query.AnyAsync(cancellationToken);

        /// <summary>
        /// Alls the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
                    => await _query.AllAsync(predicate, cancellationToken);

        /// <summary>
        /// Selects the SQL asynchronous.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> SelectSqlAsync(string sql, object[] parameters, CancellationToken cancellationToken = default)
                    => await _query.FromSql(sql, parameters).ToListAsync(cancellationToken);

        /// <summary>
        /// Sets the specified set parameter.
        /// </summary>
        /// <param name="setParameter">The set parameter.</param>
        /// <returns></returns>
        private IQuery<TEntity> Set(Action<Query<TEntity>> setParameter)
        {
            setParameter(this);
            return this;
        }
    }
}

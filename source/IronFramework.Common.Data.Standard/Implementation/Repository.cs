#region

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IronFramework.Common.Data.Abstractions;
using Microsoft.EntityFrameworkCore;


#endregion

namespace IronFramework.Common.Data.Implementation.EF
{
    /// <summary>
    /// Repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IQuery<TEntity> _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(DbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
            _query = new Query<TEntity>(this);
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        protected DbContext Context { get; }
        /// <summary>
        /// Gets the set.
        /// </summary>
        /// <value>
        /// The set.
        /// </value>
        protected DbSet<TEntity> Set { get; }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default)
                    => await Set.FindAsync(keyValues, cancellationToken);

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
                    => await FindAsync(new object[] { keyValue }, cancellationToken);

        /// <summary>
        /// Existses the asynchronous.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> ExistsAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            var item = await FindAsync(keyValues, cancellationToken);
            return item != null;
        }

        /// <summary>
        /// Existses the asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> ExistsAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
                    => await ExistsAsync(new object[] { keyValue }, cancellationToken);

        /// <summary>
        /// Loads the property asynchronous.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="property">The property.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property, CancellationToken cancellationToken = default)
                    => await Context.Entry(item).Reference(property).LoadAsync(cancellationToken);

        /// <summary></summary>
        /// <param name="item"></param>
        public virtual void Attach(TEntity item)
                    => Set.Attach(item);

        /// <summary>
        /// Detaches the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Detach(TEntity item)
                    => Context.Entry(item).State = EntityState.Detached;

        /// <summary>
        /// Inserts the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Insert(TEntity item)
                    => Context.Entry(item).State = EntityState.Added;

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Update(TEntity item)
                    => Context.Entry(item).State = EntityState.Modified;

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Delete(TEntity item)
                    => Context.Entry(item).State = EntityState.Deleted;

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            var item = await FindAsync(keyValues, cancellationToken);
            if (item == null) return false;
            Context.Entry(item).State = EntityState.Deleted;
            return true;
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
                    => await DeleteAsync(new object[] { keyValue }, cancellationToken);

        /// <summary>
        /// Queryables this instance.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Queryable() => Set;

        /// <summary>
        /// Queryables the SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> QueryableSql(string sql, params object[] parameters)
                    => Set.FromSql(sql, parameters);

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <returns></returns>
        public virtual IQuery<TEntity> Query() => _query;
    }
}
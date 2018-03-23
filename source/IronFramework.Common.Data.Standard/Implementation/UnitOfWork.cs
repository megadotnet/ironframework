using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IronFramework.Common.Data.Abstractions;
using Microsoft.EntityFrameworkCore;


namespace IronFramework.Common.Data.Implementation.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await Context.SaveChangesAsync(cancellationToken);

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
            => await Context.Database.ExecuteSqlCommandAsync(sql, parameters, cancellationToken);
    }
}
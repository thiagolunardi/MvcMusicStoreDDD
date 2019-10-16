using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrimeMusicStore.Domain.Interfaces.Repository.Common;

namespace PrimeMusicStore.Data.Repository.EntityFramework.Common
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        protected DbContext Context { get; }

        protected DbSet<TEntity> DbSet { get; }

        public Repository(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
            => DbSet.Add(entity);        

        public virtual void Delete(TEntity entity)
            => DbSet.Remove(entity);

        public ValueTask<TEntity> GetAsync(int id)
            => DbSet.FindAsync(id);

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual IAsyncEnumerable<TEntity> AllAsync()
        {
            return DbSet.AsAsyncEnumerable();
        }

        public virtual IAsyncEnumerable<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsAsyncEnumerable();
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion
    }
}

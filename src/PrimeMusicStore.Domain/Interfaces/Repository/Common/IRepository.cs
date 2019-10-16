using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimeMusicStore.Domain.Interfaces.Repository.Common
{
    public interface IRepository<TEntity>
      where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        ValueTask<TEntity> GetAsync(int id);
        IAsyncEnumerable<TEntity> AllAsync();
        IAsyncEnumerable<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
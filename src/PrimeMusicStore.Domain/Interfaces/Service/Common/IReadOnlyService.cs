using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimeMusicStore.Domain.Interfaces.Service.Common
{
    public interface IReadOnlyService<TEntity>
          where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        IAsyncEnumerable<TEntity> AllAsync();
        IAsyncEnumerable<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
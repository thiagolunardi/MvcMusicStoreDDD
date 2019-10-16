using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimeMusicStore.Application.Interfaces.Common
{
    public interface IAppService<TEntity> : IWriteOnlyAppService<TEntity>, IDisposable
        where TEntity : class
    {
        ValueTask<TEntity> GetAsync(int id);
        IAsyncEnumerable<TEntity> AllAsync();
        IAsyncEnumerable<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
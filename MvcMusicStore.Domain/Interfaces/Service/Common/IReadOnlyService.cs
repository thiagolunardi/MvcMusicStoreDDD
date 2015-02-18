using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcMusicStore.Domain.Interfaces.Service.Common
{
    public interface IReadOnlyService<TEntity>
          where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
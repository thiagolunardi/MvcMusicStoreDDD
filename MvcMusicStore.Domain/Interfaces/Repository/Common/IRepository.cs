using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcMusicStore.Domain.Interfaces.Repository.Common
{
    public interface IRepository<TEntity>
      where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> All(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}
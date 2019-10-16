using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace PrimeMusicStore.Domain.Interfaces.Service.Common
{
    public interface IService<TEntity>
        where TEntity : class
    {
        ValueTask<TEntity> GetAsync(int id);
        IAsyncEnumerable<TEntity> AllAsync();
        IAsyncEnumerable<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        ValidationResult Add(TEntity department);
        ValidationResult Update(TEntity department);
        ValidationResult Delete(TEntity entity);
    }
}
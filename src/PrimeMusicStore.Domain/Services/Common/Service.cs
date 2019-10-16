using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation.Results;
using PrimeMusicStore.Domain.Interfaces.Repository.Common;
using PrimeMusicStore.Domain.Interfaces.Service.Common;
using PrimeMusicStore.Domain.Interfaces.Validation;

namespace PrimeMusicStore.Domain.Services.Common
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : class
    {
        protected IRepository<TEntity> Repository { get; }        
        protected ValidationResult ValidationResult { get; }

        public Service(
            IRepository<TEntity> repository)
        {
            Repository = repository;
            ValidationResult = new ValidationResult();
        }

        #region Read Methods

        public virtual ValueTask<TEntity> GetAsync(int id)
        {
            return Repository.GetAsync(id);
        }

        public virtual IAsyncEnumerable<TEntity> AllAsync()
        {
            return Repository.AllAsync();
        }

        public virtual IAsyncEnumerable<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.FindAsync(predicate);
        }

        #endregion

        #region CRUD Methods

        public virtual ValidationResult Add(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;


            Repository.Add(entity);
            return ValidationResult;
        }

        public virtual ValidationResult Update(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            Repository.Update(entity);
            return ValidationResult;
        }

        public virtual ValidationResult Delete(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            Repository.Delete(entity);
            return ValidationResult;
        }

        #endregion
    }
}

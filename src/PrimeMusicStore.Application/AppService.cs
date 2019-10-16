using FluentValidation.Results;
using PrimeMusicStore.Data.Context.Interfaces;

namespace PrimeMusicStore.Application
{
    public abstract class AppService
    {
        private IUnitOfWork _uow;

        public AppService(IUnitOfWork uow)
        {
            _uow = uow;
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult { get; set; }

        public virtual void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }
    }

}

using Microsoft.Practices.ServiceLocation;
using MvcMusicStore.Application.Interfaces.Common;
using MvcMusicStore.Data.Context.Interfaces;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Application
{
    public class AppService<TContext> : ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _uow;

        public AppService()
        {
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult { get; private set; }

        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }
    }

}

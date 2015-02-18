using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Domain.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}
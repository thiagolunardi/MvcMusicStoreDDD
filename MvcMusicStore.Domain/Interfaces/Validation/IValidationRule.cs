namespace MvcMusicStore.Domain.Interfaces.Validation
{
    public interface IValidationRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Valid(TEntity entity);
    }
}
namespace MvcMusicStore.Domain.Interfaces.Validation
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
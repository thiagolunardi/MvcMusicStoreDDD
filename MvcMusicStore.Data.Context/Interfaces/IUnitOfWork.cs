namespace MvcMusicStore.Data.Context.Interfaces
{
    public interface IUnitOfWork<TContext>
        where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void SaveChanges();
    }
}
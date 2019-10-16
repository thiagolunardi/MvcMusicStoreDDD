using PrimeMusicStore.Data.Context;
using PrimeMusicStore.Data.Repository.EntityFramework.Common;
using PrimeMusicStore.Domain.Entities;
using PrimeMusicStore.Domain.Interfaces.Repository;

namespace PrimeMusicStore.Data.Repository.EntityFramework
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(PrimeMusicStoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}

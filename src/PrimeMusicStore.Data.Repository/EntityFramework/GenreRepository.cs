using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PrimeMusicStore.Data.Context;
using PrimeMusicStore.Data.Repository.EntityFramework.Common;
using PrimeMusicStore.Domain.Entities;
using PrimeMusicStore.Domain.Interfaces.Repository;

namespace PrimeMusicStore.Data.Repository.EntityFramework
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(PrimeMusicStoreDbContext dbContext) 
            : base(dbContext)
        {
        }

        public IAsyncEnumerable<Genre> GetWithAlbumsAsync(string genreName)
        {
            return DbSet
                .Include(g => g.Albums)
                .Where(g => g.Name == genreName)
                .AsAsyncEnumerable();
        }
    }
}

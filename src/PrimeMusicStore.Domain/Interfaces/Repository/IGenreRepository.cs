using System.Collections.Generic;
using PrimeMusicStore.Domain.Entities;
using PrimeMusicStore.Domain.Interfaces.Repository.Common;

namespace PrimeMusicStore.Domain.Interfaces.Repository
{
    public interface IGenreRepository : IRepository<Genre>
    {
        IAsyncEnumerable<Genre> GetWithAlbumsAsync(string genreName);
    }
}
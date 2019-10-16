using System.Collections.Generic;
using PrimeMusicStore.Domain.Entities;
using PrimeMusicStore.Domain.Interfaces.Service.Common;

namespace PrimeMusicStore.Domain.Interfaces.Service
{
    public interface IGenreService : IService<Genre>
    {
        IAsyncEnumerable<Genre> GetWithAlbumsAsync(string genre);
    }
}
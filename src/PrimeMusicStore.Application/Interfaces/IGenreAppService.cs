using System.Collections.Generic;
using PrimeMusicStore.Application.Interfaces.Common;
using PrimeMusicStore.Domain.Entities;

namespace PrimeMusicStore.Application.Interfaces
{
    public interface IGenreAppService : IAppService<Genre>
    {
        IAsyncEnumerable<Genre> GetWithAlbumsAsync(string genreName);
    }
}

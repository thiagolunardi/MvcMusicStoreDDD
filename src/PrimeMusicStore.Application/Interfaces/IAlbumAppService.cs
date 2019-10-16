using System.Collections.Generic;
using PrimeMusicStore.Application.Interfaces.Common;
using PrimeMusicStore.Domain.Entities;

namespace PrimeMusicStore.Application.Interfaces
{
    public interface IAlbumAppService : IAppService<Album>
    {
        IAsyncEnumerable<Album> GetTopSellingAlbumsAsync(int count);        
    }
}

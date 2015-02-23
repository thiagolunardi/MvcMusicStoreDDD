using System.Collections.Generic;
using MvcMusicStore.Application.Interfaces.Common;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Application.Interfaces
{
    public interface IAlbumAppService : IAppService<Album>
    {
        IEnumerable<Album> GetTopSellingAlbums(int count);
        
    }
}

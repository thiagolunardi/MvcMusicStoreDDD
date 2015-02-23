using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Service.Common;

namespace MvcMusicStore.Domain.Interfaces.Service
{
    public interface IGenreService : IService<Genre>
    {
        Genre GetWithAlbums(string genre);
    }
}
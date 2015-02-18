using MvcMusicStore.Application.Interfaces.Common;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Application.Interfaces
{
    public interface IGenreAppService : IAppService<Genre>
    {
        Genre GetWithAlbums(string genreName);
    }
}

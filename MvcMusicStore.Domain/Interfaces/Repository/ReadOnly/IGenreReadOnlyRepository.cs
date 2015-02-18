using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository.Common;

namespace MvcMusicStore.Domain.Interfaces.Repository.ReadOnly
{
    public interface IGenreReadOnlyRepository : IReadOnlyRepository<Genre>
    {
        Genre GetWithAlbums(string genreName);
    }
}
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository;
using MvcMusicStore.Domain.Interfaces.Repository.ReadOnly;
using MvcMusicStore.Domain.Interfaces.Service;
using MvcMusicStore.Domain.Services.Common;

namespace MvcMusicStore.Domain.Services
{
    public class GenreService : Service<Genre>, IGenreService
    {
        private readonly IGenreReadOnlyRepository _readOnlyRepository;
        public GenreService(IGenreRepository repository, IGenreReadOnlyRepository readOnlyRepository, IGenreReadOnlyRepository readOnlyRepository1) 
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
        }

        public Genre GetWithAlbums(string genreName)
        {
            return _readOnlyRepository.GetWithAlbums(genreName);
        }
    }
}

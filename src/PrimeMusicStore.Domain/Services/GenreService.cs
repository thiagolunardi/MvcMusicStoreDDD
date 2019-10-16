using System.Collections.Generic;
using PrimeMusicStore.Domain.Entities;
using PrimeMusicStore.Domain.Interfaces.Repository;
using PrimeMusicStore.Domain.Interfaces.Service;
using PrimeMusicStore.Domain.Services.Common;

namespace PrimeMusicStore.Domain.Services
{
    public class GenreService : Service<Genre>, IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public IAsyncEnumerable<Genre> GetWithAlbumsAsync(string genreName)
        {
            return _repository.GetWithAlbumsAsync(genreName);
        }
    }
}

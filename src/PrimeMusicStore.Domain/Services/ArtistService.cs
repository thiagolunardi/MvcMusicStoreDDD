using PrimeMusicStore.Domain.Entities;
using PrimeMusicStore.Domain.Interfaces.Repository;
using PrimeMusicStore.Domain.Interfaces.Service;
using PrimeMusicStore.Domain.Services.Common;

namespace PrimeMusicStore.Domain.Services
{
    public class ArtistService : Service<Artist>, IArtistService
    {
        public ArtistService(IArtistRepository repository) 
            : base(repository)
        {
        }
    }
}

using MvcMusicStore.Domain.Interfaces.Specification;

namespace MvcMusicStore.Domain.Entities.Specifications.AlbumSpecs
{
    public class AlbumPriceIsRequiredSpec : ISpecification<Album>
    {
        public bool IsSatisfiedBy(Album album)
        {
            return album.Price > 0;
        }
    }
}

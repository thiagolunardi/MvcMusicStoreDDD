using MvcMusicStore.Domain.Interfaces.Specification;

namespace MvcMusicStore.Domain.Entities.Specifications.AlbumSpecs
{
    public class AlbumPriceMustBeLowerThan100Spec : ISpecification<Album>
    {
        public bool IsSatisfiedBy(Album album)
        {
            return album.Price > 0.01m && album.Price < 100.00m;
        }
    }
}

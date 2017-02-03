using MvcMusicStore.Domain.Interfaces.Specification;

namespace MvcMusicStore.Domain.Entities.Specifications.AlbumSpecs
{
    public class AlbumArtUrlLenthMustBeLowerThan1024Spec : ISpecification<Album>
    {
        public bool IsSatisfiedBy(Album album)
        {
            return album.AlbumArtUrl.Trim().Length < 1024;
        }
    }
}

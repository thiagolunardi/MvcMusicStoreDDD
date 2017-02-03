using System;
using MvcMusicStore.Domain.Interfaces.Specification;

namespace MvcMusicStore.Domain.Entities.Specifications.GenreSpecs
{
    public class GenreNameIsRequiredSpec : ISpecification<Genre>
    {
        public bool IsSatisfiedBy(Genre genre)
        {
            return !String.IsNullOrEmpty(genre.Name) && !String.IsNullOrWhiteSpace(genre.Name);
        }
    }
}

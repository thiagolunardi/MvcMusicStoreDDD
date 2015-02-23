using System;
using MvcMusicStore.Domain.Interfaces.Validation;

namespace MvcMusicStore.Domain.Entities.Specifications.GenreSpecs
{
    public class GenreDescriptionIsRequiredSpec : ISpecification<Genre>
    {
        public bool IsSatisfiedBy(Genre genre)
        {
            return !String.IsNullOrEmpty(genre.Description) && !String.IsNullOrWhiteSpace(genre.Description);
        }
    }
}

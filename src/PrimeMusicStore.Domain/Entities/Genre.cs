using System.Collections.Generic;
using FluentValidation.Results;
using PrimeMusicStore.Domain.Entities.Validations;
using PrimeMusicStore.Domain.Interfaces.Validation;

namespace PrimeMusicStore.Domain.Entities
{
    public class Genre : ISelfValidation
    {
        public Genre()
        {
            Albums = new List<Album>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Album> Albums { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new GenreIsValidValidation();
                ValidationResult = fiscal.Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}

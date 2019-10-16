using System.Collections.Generic;
using PrimeMusicStore.Domain.Entities.Validations;
using PrimeMusicStore.Domain.Interfaces.Validation;
using FluentValidation.Results;

namespace PrimeMusicStore.Domain.Entities
{
    public class Artist : ISelfValidation
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new ArtistIsValidValidation();
                ValidationResult = fiscal.Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
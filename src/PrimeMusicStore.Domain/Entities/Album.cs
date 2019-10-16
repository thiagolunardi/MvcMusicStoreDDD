using System.Collections.Generic;
using FluentValidation.Results;
using PrimeMusicStore.Domain.Entities.Validations;
using PrimeMusicStore.Domain.Interfaces.Validation;

namespace PrimeMusicStore.Domain.Entities
{
    public class Album : ISelfValidation
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new AlbumIsValidValidation();
                ValidationResult = fiscal.Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
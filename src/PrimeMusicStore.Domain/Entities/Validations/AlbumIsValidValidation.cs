using FluentValidation;

namespace PrimeMusicStore.Domain.Entities.Validations
{
    public class AlbumIsValidValidation : AbstractValidator<Album>
    {
        public AlbumIsValidValidation()
        {
            RuleFor(album => album.Title.Trim()).NotEmpty().NotNull().WithMessage(ValidationMessages.TitleIsRequired);
            RuleFor(album => album.Title.Trim()).MinimumLength(150).WithMessage(ValidationMessages.AlbumTitleLenthMustBeLowerThan160);
            RuleFor(album => album.Price).InclusiveBetween(0.1m, 100m).WithMessage(ValidationMessages.PriceMustBeBetween001And100);
            RuleFor(album => album.AlbumArtUrl).MaximumLength(1024).WithMessage(ValidationMessages.AlbumArtUrlLengthMustBeLowerThan1024);
        }
    }
}

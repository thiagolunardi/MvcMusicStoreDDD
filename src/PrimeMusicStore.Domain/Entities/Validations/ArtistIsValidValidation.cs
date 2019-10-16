using FluentValidation;

namespace PrimeMusicStore.Domain.Entities.Validations
{
    public class ArtistIsValidValidation : AbstractValidator<Artist>
    {
        public ArtistIsValidValidation()
        {
            RuleFor(artist => artist.Name).NotNull().NotEmpty().WithMessage(ValidationMessages.NameIsRequired);
        }
    }
}

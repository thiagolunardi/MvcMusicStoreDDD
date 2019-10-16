using FluentValidation;

namespace PrimeMusicStore.Domain.Entities.Validations
{
    public class GenreIsValidValidation : AbstractValidator<Genre>
    {
        public GenreIsValidValidation()
        {
            RuleFor(genre => genre.Name).NotNull().NotEmpty().WithMessage(ValidationMessages.NameIsRequired);
            RuleFor(genre => genre.Description).NotNull().NotEmpty().WithMessage(ValidationMessages.DescriptionIsRequired);
        }
    }
}

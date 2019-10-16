using FluentValidation;

namespace PrimeMusicStore.Domain.Entities.Validations
{
    public class CartIsValidValidation : AbstractValidator<Cart>
    {
        public CartIsValidValidation()
        {
            RuleFor(cart => cart.Count).GreaterThan(0).WithMessage(ValidationMessages.NameIsRequired);
        }
    }
}

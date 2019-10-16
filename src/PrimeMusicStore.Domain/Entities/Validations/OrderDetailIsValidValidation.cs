using FluentValidation;

namespace PrimeMusicStore.Domain.Entities.Validations
{
    public class OrderDetailIsValidValidation : AbstractValidator<OrderDetail>
    {
        public OrderDetailIsValidValidation()
        {
            RuleFor(detail => detail.Quantity).GreaterThan(0).WithMessage(ValidationMessages.QuantityIsInvalid);
            RuleFor(detail => detail.UnitPrice).GreaterThan(0).WithMessage(ValidationMessages.UnityPriceIsInvalid);
        }
    }
}

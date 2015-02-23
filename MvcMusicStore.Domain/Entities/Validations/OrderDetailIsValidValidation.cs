using MvcMusicStore.Domain.Entities.Specifications.OrderDetailSpecs;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Domain.Entities.Validations
{
    public class OrderDetailIsValidValidation : Validation<OrderDetail>
    {
        public OrderDetailIsValidValidation()
        {
            base.AddRule(new ValidationRule<OrderDetail>(new OrderDetailQuantityShouldBeGraterThanZeroSpec(), ValidationMessages.QuantityIsInvalid));
            base.AddRule(new ValidationRule<OrderDetail>(new OrderDetailUnityPriceShouldBeGraterThanZeroSpec(), ValidationMessages.UnityPriceIsInvalid));
        }
    }
}

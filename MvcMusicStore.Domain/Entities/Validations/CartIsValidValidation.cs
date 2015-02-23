using MvcMusicStore.Domain.Entities.Specifications.CartSpecs;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Domain.Entities.Validations
{
    public class CartIsValidValidation : Validation<Cart>
    {
        public CartIsValidValidation()
        {
            base.AddRule(new ValidationRule<Cart>(new CartCountShouldBeGreaterThanZeroSpec(), ValidationMessages.NameIsRequired));
        }
    }
}

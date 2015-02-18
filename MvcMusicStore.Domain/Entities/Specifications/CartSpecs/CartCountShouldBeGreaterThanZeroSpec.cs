using MvcMusicStore.Domain.Interfaces.Validation;

namespace MvcMusicStore.Domain.Entities.Specifications.CartSpecs
{
    public class CartCountShouldBeGreaterThanZeroSpec : ISpecification<Cart>
    {
        public bool IsSatisfiedBy(Cart cart)
        {
            return cart.Count > 0;
        }
    }
}

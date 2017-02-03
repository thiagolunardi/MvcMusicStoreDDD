using MvcMusicStore.Domain.Interfaces.Specification;

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

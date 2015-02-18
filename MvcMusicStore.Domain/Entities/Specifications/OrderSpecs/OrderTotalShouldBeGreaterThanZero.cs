using MvcMusicStore.Domain.Interfaces.Validation;

namespace MvcMusicStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderTotalShouldBeGreaterThanZero : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return order.Total > 0;
        }
    }
}

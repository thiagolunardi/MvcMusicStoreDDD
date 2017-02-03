using MvcMusicStore.Domain.Interfaces.Specification;

namespace MvcMusicStore.Domain.Entities.Specifications.OrderDetailSpecs
{
    public class OrderDetailQuantityShouldBeGraterThanZeroSpec : ISpecification<OrderDetail>
    {
        public bool IsSatisfiedBy(OrderDetail orderDetail)
        {
            return orderDetail.Quantity > 0;
        }
    }
}

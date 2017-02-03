using MvcMusicStore.Domain.Interfaces.Specification;

namespace MvcMusicStore.Domain.Entities.Specifications.OrderDetailSpecs
{
    public class OrderDetailUnityPriceShouldBeGraterThanZeroSpec : ISpecification<OrderDetail>
    {
        public bool IsSatisfiedBy(OrderDetail orderDetail)
        {
            return orderDetail.UnitPrice > 0;
        }
    }
}

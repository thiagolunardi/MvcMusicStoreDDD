using System;
using MvcMusicStore.Domain.Interfaces.Specification;

namespace MvcMusicStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderStateIsRequiredSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return !String.IsNullOrEmpty(order.State) && !String.IsNullOrWhiteSpace(order.State);
        }
    }
}

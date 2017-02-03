using System;
using MvcMusicStore.Domain.Interfaces.Specification;

namespace MvcMusicStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderEmailIsRequiredSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return !String.IsNullOrEmpty(order.Email) && !String.IsNullOrWhiteSpace(order.Email);
        }
    }
}

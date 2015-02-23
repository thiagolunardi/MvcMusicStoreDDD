using System;
using MvcMusicStore.Domain.Interfaces.Validation;

namespace MvcMusicStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderFirstNameIsRequiredSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return !String.IsNullOrEmpty(order.FirstName) && !String.IsNullOrWhiteSpace(order.FirstName);
        }
    }
}

using System;
using MvcMusicStore.Domain.Interfaces.Validation;

namespace MvcMusicStore.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderPostalCodeIsRequiredSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            return !String.IsNullOrEmpty(order.PostalCode) && !String.IsNullOrWhiteSpace(order.PostalCode);
        }
    }
}

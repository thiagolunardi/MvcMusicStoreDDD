using System;
using System.Collections.Generic;
using MvcMusicStore.Domain.Entities.Validations;
using MvcMusicStore.Domain.Interfaces.Validation;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Domain.Entities
{
    public  class Order : ISelfValidation
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new OrderIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}

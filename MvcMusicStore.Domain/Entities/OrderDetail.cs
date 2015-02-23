using MvcMusicStore.Domain.Entities.Validations;
using MvcMusicStore.Domain.Interfaces.Validation;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Domain.Entities
{
    public class OrderDetail : ISelfValidation
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Album Album { get; set; }
        public virtual Order Order { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new OrderDetailIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}

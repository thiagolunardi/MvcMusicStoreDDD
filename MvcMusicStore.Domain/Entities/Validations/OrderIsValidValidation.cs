using MvcMusicStore.Domain.Entities.Specifications.OrderSpecs;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Domain.Entities.Validations
{
    public class OrderIsValidValidation : Validation<Order>
    {
        public OrderIsValidValidation()
        {
            base.AddRule(new ValidationRule<Order>(new OrderDateShouldBeLowerThanTodaySpec(), ValidationMessages.OrderDateIsInvalid));
            base.AddRule(new ValidationRule<Order>(new OrderUsernameIsRequiredSpec(), ValidationMessages.UsernameIsRequired));
            base.AddRule(new ValidationRule<Order>(new OrderFirstNameIsRequiredSpec(), ValidationMessages.FirstNameIsRequired));
            base.AddRule(new ValidationRule<Order>(new OrderFirstNameLengthMustBeLowerThan160Spec(), ValidationMessages.FirstNameTooLong));
            base.AddRule(new ValidationRule<Order>(new OrderLastNameIsRequiredSpec(), ValidationMessages.LastNameIsRequired));
            base.AddRule(new ValidationRule<Order>(new OrderLastNameLengthMustBeLowerThan160Spec(), ValidationMessages.LastNameTooLong));
            base.AddRule(new ValidationRule<Order>(new OrderAddressIsRequiredSpec(), ValidationMessages.AddressIsRequired));
            base.AddRule(new ValidationRule<Order>(new OrderAddressLengthMustBeLowerThan70Spec(), ValidationMessages.AddressTooLong));
            base.AddRule(new ValidationRule<Order>(new OrderCityIsRequiredSpec(), ValidationMessages.CityIsRequired));
            base.AddRule(new ValidationRule<Order>(new OrderCityLengthMustBeLowerThan40Spec(), ValidationMessages.CityTooLong));
            base.AddRule(new ValidationRule<Order>(new OrderStateIsRequiredSpec(), ValidationMessages.StateIsRequired));
            base.AddRule(new ValidationRule<Order>(new OrderStateLengthMustBeLowerThan40Spec(), ValidationMessages.StateTooLong));
            base.AddRule(new ValidationRule<Order>(new OrderPostalCodeIsRequiredSpec(), ValidationMessages.PostalCodeIsRequired));
            base.AddRule(new ValidationRule<Order>(new OrderCountryIsRequiredSpec(), ValidationMessages.CountryIsRequired));
            base.AddRule(new ValidationRule<Order>(new OrderPhoneIsRequiredSpec(), ValidationMessages.PhoneIsRequired));
            base.AddRule(new ValidationRule<Order>(new OrderEmailIsRequiredSpec(), ValidationMessages.EmailIsRequired));
            base.AddRule(new ValidationRule<Order>(new OrderEmailShouldbeValidEmailAddressSpec(), ValidationMessages.EmailIsInvalid));
            base.AddRule(new ValidationRule<Order>(new OrderTotalShouldBeGreaterThanZero(), ValidationMessages.TotalIsInvalid));
        }
    }
}

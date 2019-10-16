using System;
using FluentValidation;

namespace PrimeMusicStore.Domain.Entities.Validations
{
    public class OrderIsValidValidation : AbstractValidator<Order>
    {
        public OrderIsValidValidation()
        {
            RuleFor(order => order.OrderDate).LessThanOrEqualTo(DateTime.Today).WithMessage(ValidationMessages.OrderDateIsInvalid);
            RuleFor(order => order.Username).NotNull().NotNull().WithMessage(ValidationMessages.UsernameIsRequired);
            RuleFor(order => order.FirstName).NotNull().NotEmpty().WithMessage(ValidationMessages.FirstNameIsRequired);
            RuleFor(order => order.FirstName).MaximumLength(160).WithMessage(ValidationMessages.FirstNameTooLong);
            RuleFor(order => order.LastName).NotNull().NotEmpty().WithMessage(ValidationMessages.LastNameIsRequired);
            RuleFor(order => order.LastName).MaximumLength(160).WithMessage(ValidationMessages.LastNameTooLong);
            RuleFor(order => order.Address).NotNull().NotEmpty().WithMessage(ValidationMessages.AddressIsRequired);
            RuleFor(order => order.Address).MaximumLength(70).WithMessage(ValidationMessages.AddressTooLong);
            RuleFor(order => order.City).NotNull().NotEmpty().WithMessage(ValidationMessages.CityIsRequired);
            RuleFor(order => order.City).MaximumLength(40).WithMessage(ValidationMessages.CityTooLong);
            RuleFor(order => order.State).NotNull().NotEmpty().WithMessage(ValidationMessages.StateIsRequired);
            RuleFor(order => order.State).NotNull().NotEmpty().WithMessage(ValidationMessages.StateTooLong);
            RuleFor(order => order.PostalCode).NotNull().NotEmpty().WithMessage(ValidationMessages.PostalCodeIsRequired);
            RuleFor(order => order.Country).NotNull().NotEmpty().WithMessage(ValidationMessages.CountryIsRequired);
            RuleFor(order => order.Phone).NotNull().NotEmpty().WithMessage(ValidationMessages.PhoneIsRequired);
            RuleFor(order => order.Email).NotNull().NotEmpty().WithMessage(ValidationMessages.EmailIsRequired);
            RuleFor(order => order.Email).EmailAddress().WithMessage(ValidationMessages.EmailIsInvalid);
            RuleFor(order => order.Total).GreaterThan(0).WithMessage(ValidationMessages.TotalIsInvalid);
        }
    }
}

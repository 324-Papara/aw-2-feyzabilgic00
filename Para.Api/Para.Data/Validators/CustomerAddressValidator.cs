using FluentValidation;
using Para.Data.Domain;

namespace Para.Data.Validators;

public class CustomerAddressValidator : AbstractValidator<CustomerAddress>
{
    public CustomerAddressValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(50).WithMessage("Country cannot be longer than 50 characters.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(50).WithMessage("City cannot be longer than 50 characters.");

        RuleFor(x => x.AddressLine)
            .NotEmpty().WithMessage("Address line is required.")
            .MaximumLength(200).WithMessage("Address line cannot be longer than 200 characters.");

        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("Zip code is required.")
            .MaximumLength(10).WithMessage("Zip code cannot be longer than 10 characters.");

        RuleFor(x => x.IsDefault)
            .NotNull().WithMessage("IsDefault is required.");
    }
}

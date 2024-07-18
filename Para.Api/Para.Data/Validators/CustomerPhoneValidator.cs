using FluentValidation;
using Para.Data.Domain;

namespace Para.Data.Validators;

public class CustomerPhoneValidator : AbstractValidator<CustomerPhone>
{
    public CustomerPhoneValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

        RuleFor(x => x.CountyCode)
            .NotEmpty().WithMessage("Country code is required.")
            .MaximumLength(3).WithMessage("Country code cannot be longer than 3 characters.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone is required.")
            .MaximumLength(20).WithMessage("Phone cannot be longer than 20 characters.");

        RuleFor(x => x.IsDefault)
            .NotNull().WithMessage("IsDefault is required.");
    }
}


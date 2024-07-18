using FluentValidation;
using Para.Data.Domain;

namespace Para.Data.Validators;
public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(20).WithMessage("First name cannot be longer than 20 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(20).WithMessage("Last name cannot be longer than 20 characters.");

        RuleFor(x => x.IdentityNumber)
            .NotEmpty().WithMessage("Identity number is required.")
            .MaximumLength(20).WithMessage("Identity number cannot be longer than 20 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.CustomerNumber)
            .GreaterThan(0).WithMessage("Customer number must be greater than 0.");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");

        RuleForEach(x => x.CustomerAddresses).SetValidator(new CustomerAddressValidator());
        RuleForEach(x => x.CustomerPhones).SetValidator(new CustomerPhoneValidator());
    }
}

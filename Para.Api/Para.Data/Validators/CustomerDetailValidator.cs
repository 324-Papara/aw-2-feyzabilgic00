using FluentValidation;
using Para.Data.Domain;

namespace Para.Data.Validators;

public class CustomerDetailValidator : AbstractValidator<CustomerDetail>
{
    public CustomerDetailValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

        RuleFor(x => x.FatherName)
            .MaximumLength(50).WithMessage("Father name cannot be longer than 50 characters.");

        RuleFor(x => x.MotherName)
            .MaximumLength(50).WithMessage("Mother name cannot be longer than 50 characters.");

        RuleFor(x => x.EducationStatus)
            .MaximumLength(100).WithMessage("Education status cannot be longer than 100 characters.");

        RuleFor(x => x.MontlyIncome)
            .MaximumLength(50).WithMessage("Monthly income cannot be longer than 50 characters.");

        RuleFor(x => x.Occupation)
            .MaximumLength(100).WithMessage("Occupation cannot be longer than 100 characters.");
    }
}
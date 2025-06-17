using FluentValidation;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_APICreation.Validators
{
    public class CustomersValidator : AbstractValidator<CustomersModel>
    {
        public CustomersValidator()
        {
            //RuleFor(c => c.CustomerID)
            //    .NotEmpty().WithMessage("Customer Id must not be empty.")
            //    .NotNull().WithMessage("Customer Id must not be null.");

            RuleFor(c => c.FirstName)
                .NotNull().WithMessage("First name must not be null.")
                .NotEmpty().WithMessage("First name must not be empty.")
                .Length(3, 50).WithMessage("First name must be between 3 and 50 characters.")
                .Matches("^[A-Za-z ]*$").WithMessage("First name must contain only letters and spaces.");

            RuleFor(c => c.LastName)
                .NotNull().WithMessage("Last name must not be null.")
                .NotEmpty().WithMessage("Last name must not be empty.")
                .Length(3, 50).WithMessage("Last name must be between 3 and 50 characters.")
                .Matches("^[A-Za-z ]*$").WithMessage("Last name must contain only letters and spaces.");

            RuleFor(c => c.ContactNumber)
                .NotNull().WithMessage("Contact number must not be null.")
                .NotEmpty().WithMessage("Contact number must not be empty.")
                .Matches(@"^\d{10}$").WithMessage("Contact number must be 10 digits.");

            RuleFor(c => c.Email)
                .NotNull().WithMessage("Client email must not be null.")
                .NotEmpty().WithMessage("Client email must not be empty.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(c => c.Address)
                .NotNull().WithMessage("Address must not be null.")
                .NotEmpty().WithMessage("Address must not be empty.")
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.")
                .Matches("^[A-Za-z0-9,.' ]*$").WithMessage("Address must contain only letters, numbers, commas, periods, apostrophes, and spaces.");

            RuleFor(c => c.PreferredBudget)
                .NotNull().WithMessage("Preferred Budget must not be null.")
                .NotEmpty().WithMessage("Preferred Budget must not be empty.")
                .GreaterThanOrEqualTo(0).WithMessage("Preferred budget must be a positive number.")
                .LessThanOrEqualTo(100000).WithMessage("Preferred budget must not exceed 100,000.");
       
            RuleFor(c => c.InterestedThemes)
                .NotNull().WithMessage("Interested themes must not be null.")
                .NotEmpty().WithMessage("Interested themes must not be empty.")
                .Length(3, 200).WithMessage("Interested themes must be between 3 and 200 characters.")
                .Matches("^[A-Za-z0-9,.' ]*$").WithMessage("Interested themes must contain only letters, numbers, commas, periods, apostrophes, and spaces.");
        }
    }
}

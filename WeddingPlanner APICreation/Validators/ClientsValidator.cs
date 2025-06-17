using FluentValidation;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_APICreation.Validators
{
    public class ClientsValidator : AbstractValidator<ClientsModel>
    {
        public ClientsValidator()
        {
            //RuleFor(c => c.ClientID)
            //    .NotEmpty().WithMessage("Client Id must not be empty.")
            //    .NotNull().WithMessage("Client Id must not be null.");

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

            RuleFor(c => c.Password)
                .NotNull().WithMessage("Password must not be null.")
                .NotEmpty().WithMessage("Password must not be empty.")
                .Length(8, 20).WithMessage("Password must be between 8 and 20 characters.")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.");

        }
    }
}

using FluentValidation;
using WeddingPlanner_APICreation.Models;
namespace WeddingPlanner_APICreation.Validators
{
    public class VendorsValidator : AbstractValidator<VendorsModel>
    {
        public VendorsValidator() 
        {
            //RuleFor(v =>v.VendorID)
            //    .NotEmpty().WithMessage("Vendor Id must not be empty.")
            //    .NotNull().WithMessage("Vendor Id must not be null.");

            RuleFor(v =>v.VendorName)
                .NotNull().WithMessage("Vendor name must not be null.")
                .NotEmpty().WithMessage("Vendor name must not be empty.")
                .Length(3, 50).WithMessage("Vendor name must be between 3 and 50 characters.")
                .Matches("^[A-Za-z ]*$").WithMessage("Vendor name must contain only letters and spaces.");

            RuleFor(v => v.Category)
                .NotEmpty().WithMessage("Category must not be empty.")
                .NotNull().WithMessage("Category must not be null.")
                .MaximumLength(50).WithMessage("Category must not exceed 50 characters.")
                .Matches("^[A-Za-z ]*$").WithMessage("Category must contain only letters and spaces.");

            RuleFor(v => v.ContactNumber)
                .NotNull().WithMessage("Contact number must not be null.")
                .NotEmpty().WithMessage("Contact number must not be empty.")
                .Matches(@"^\d{10}$").WithMessage("Contact number must be 10 digits.");

            RuleFor(v => v.Email)
                .NotNull().WithMessage("Email must not be null.")
                .NotEmpty().WithMessage("Email must not be empty.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(v => v.Address)
                .NotNull().WithMessage("Address must not be null.")
                .NotEmpty().WithMessage("Address must not be empty.")
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.")
                .Matches("^[A-Za-z0-9,.' ]*$").WithMessage("Address must contain only letters, numbers, commas, periods, apostrophes, and spaces.");

        }
    }
}

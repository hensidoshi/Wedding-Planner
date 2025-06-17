using FluentValidation;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_APICreation.Validators
{
    public class WeddingsValidator : AbstractValidator<WeddingsModel>
    {
        public WeddingsValidator() 
        {
            //RuleFor(w => w.WeddingID)
            //    .NotEmpty().WithMessage("Wedding Id must not be empty.")
            //    .NotNull().WithMessage("Wedding Id must not be null.");

            //RuleFor(w => w.ClientID)
            //    .NotEmpty().WithMessage("Client Id must not be empty.")
            //    .NotNull().WithMessage("Client Id must not be null.");

            RuleFor(w => w.Bride)
                .NotNull().WithMessage("Bride name must not be null.")
                .NotEmpty().WithMessage("Bride name must not be empty.")
                .Length(3, 50).WithMessage("Bride name must be between 3 and 50 characters.")
                .Matches("^[A-Za-z ]*$").WithMessage("Bride name must contain only letters and spaces.");

            RuleFor(w => w.Groom)
                .NotNull().WithMessage("Groom name must not be null.")
                .NotEmpty().WithMessage("Groom name must not be empty.")
                .Length(3, 50).WithMessage("Groom name must be between 3 and 50 characters.")
                .Matches("^[A-Za-z ]*$").WithMessage("Groom name must contain only letters and spaces.");

            RuleFor(w => w.WeddingDate)
                .NotNull().WithMessage("Wedding date must not be null.")
                .NotEmpty().WithMessage("Wedding date must not be empty.")
                .GreaterThan(new DateTime(2020, 1, 1)).WithMessage("Date must be after January 1, 2020.")
                .GreaterThan(DateTime.Today).WithMessage("Wedding date must be in the future.");

            RuleFor(w => w.WeddingLocation)
                .NotEmpty().WithMessage("Wedding location must not be empty.")
                .NotNull().WithMessage("Wedding location must not be null.")
                .MaximumLength(100).WithMessage("Wedding location must not exceed 100 characters.")
                .Matches("^[A-Za-z0-9,.' ]*$").WithMessage("Wedding location must contain only letters, numbers, commas, periods, apostrophes, and spaces.");

            RuleFor(w => w.NumberOfGuests)
                .GreaterThan(0).WithMessage("Number of guests must be greater than 0.")
                .LessThanOrEqualTo(1000).WithMessage("Number of guests must not exceed 1000.")
                .NotNull().WithMessage("Number of guests must not be null.")
                .NotEmpty().WithMessage("Number of guests must not be empty.");

            RuleFor(w => w.Budget)
                .GreaterThan(0).WithMessage("Budget must be greater than 0.")
                .NotNull().WithMessage("Budget must not be null.")
                .NotEmpty().WithMessage("Budget must not be empty.");
        }
    }
}

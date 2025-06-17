using FluentValidation;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_APICreation.Validators
{
    public class GuestsValidator : AbstractValidator<GuestsModel>
    {
        public GuestsValidator() 
        {
            //RuleFor(g => g.GuestID)
            //    .NotEmpty().WithMessage("Guest Id must not be empty.")
            //    .NotNull().WithMessage("Guest Id must not be null.");

            RuleFor(g => g.WeddingID)
                .NotEmpty().WithMessage("Wedding Id must not be empty.")
                .NotNull().WithMessage("Wedding Id must not be null.");

            RuleFor(g => g.GuestName)
               .NotNull().WithMessage("Guest name must not be null.")
               .NotEmpty().WithMessage("Guest name must not be empty.")
               .Length(3, 50).WithMessage("Guest name must be between 3 and 50 characters.")
               .Matches("^[A-Za-z ]*$").WithMessage("Guest name must contain only letters and spaces.");

            RuleFor(g => g.ContactNumber)
               .NotNull().WithMessage("Contact number must not be null.")
               .NotEmpty().WithMessage("Contact number must not be empty.")
               .Matches(@"^\d{10}$").WithMessage("Contact number must be 10 digits.");

            RuleFor(g => g.RSVPStatus)
                .NotNull().WithMessage("RSVP status must not be null.")
                .NotEmpty().WithMessage("RSVP status must not be empty.")
                .Must(status => new[] { "Accepted", "Declined", "Pending" }.Contains(status))
                .WithMessage("RSVP status must be one of the following: Accepted, Declined, or Pending.");

            RuleFor(g => g.MealPreference)
                .NotNull().WithMessage("Meal preference must not be null.")
                .NotEmpty().WithMessage("Meal preference must not be empty.")
                .Must(preference => new[] { "Vegetarian", "Non-Vegetarian", "Vegan" }.Contains(preference))
                .WithMessage("Meal preference must be one of the following: Vegetarian, Non-Vegetarian, or Vegan.");
        }
    }
}

using FluentValidation;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_APICreation.Validators
{
    public class FeedbackValidator : AbstractValidator<FeedbacksModel>
    {
        public FeedbackValidator()
        {
            //RuleFor(r =>r.RatingID)
            //    .NotEmpty().WithMessage("Rating Id must not be empty.")
            //    .NotNull().WithMessage("Rating Id must not be null.");

            RuleFor(f => f.ClientID)
                .NotEmpty().WithMessage("Client Id must not be empty.")
                .NotNull().WithMessage("Client Id must not be null.");

            RuleFor(f => f.WeddingID)
                .NotEmpty().WithMessage("Wedding Id must not be empty.")
                .NotNull().WithMessage("Wedding Id must not be null.");

            RuleFor(f => f.Rating)
                .NotEmpty().WithMessage("Rating Score must not be empty.")
                .NotNull().WithMessage("Rating Score must not be null.")
                .InclusiveBetween(1, 5).WithMessage("Rating Score must be between 1 and 5.");

            RuleFor(f => f.Comments)
                .NotEmpty().WithMessage("Feedback must not be empty.")
                .NotNull().WithMessage("Feedback must not be null.")
                .MaximumLength(500).WithMessage("Feedback must not exceed 500 characters.");

            RuleFor(f => f.FeedbackDate)
                .NotNull().WithMessage("Feedback Date must not be null.")
                .NotEmpty().WithMessage("Feedback Date must not be empty.")
                .GreaterThan(new DateTime(2020, 1, 1)).WithMessage("Date must be after January 1, 2020.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Date cannot be in the future.");
        }
    }
}

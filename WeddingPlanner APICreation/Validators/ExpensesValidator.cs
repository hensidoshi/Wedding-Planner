using FluentValidation;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_APICreation.Validators
{
    public class ExpensesValidator : AbstractValidator<ExpensesModel>
    {
        public ExpensesValidator() 
        { 
            //RuleFor(e => e.ExpenseID)
            //    .NotEmpty().WithMessage("Expense Id must not be empty.")
            //    .NotNull().WithMessage("Expense Id must not be null.");

            RuleFor(e => e.WeddingID)
                .NotEmpty().WithMessage("Wedding Id must not be empty.")
                .NotNull().WithMessage("Wedding Id must not be null.");

            RuleFor(e => e.ExpenseDescription)
                .NotNull().WithMessage("Expense description must not be null.")
                .NotEmpty().WithMessage("Expense description must not be empty.")
                .Length(10, 250).WithMessage("Expense description must be between 10 and 250 characters.")
                .Matches("^[A-Za-z0-9,.' ]*$").WithMessage("Expense description must contain only letters, numbers, commas, periods, apostrophes, and spaces.");
            
            RuleFor(e =>e.Amount)
                .NotEmpty().WithMessage("Amount must not be empty.")
                .NotNull().WithMessage("Amount must not be null.")
                .GreaterThanOrEqualTo(0).WithMessage("Amount must be a positive number.")
                .LessThanOrEqualTo(100000).WithMessage("Amount must not exceed 100,000.");

            RuleFor(e => e.Date)
                .NotNull().WithMessage("Date must not be null.")
                .NotEmpty().WithMessage("Date must not be empty.")
                .GreaterThan(new DateTime(2020, 1, 1)).WithMessage("Date must be after January 1, 2020.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Date cannot be in the future.");
        }
    }
}

using FluentValidation;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_APICreation.Validators
{
    public class PaymentsValidator : AbstractValidator<PaymentsModel>
    {
        public PaymentsValidator() 
        {
            //RuleFor(p => p.PaymentID)
            //    .NotEmpty().WithMessage("Payment Id must not be empty.")
            //    .NotNull().WithMessage("Payment Id must not be null.");

            RuleFor(p => p.WeddingID)
                .NotEmpty().WithMessage("Wedding Id must not be empty.")
                .NotNull().WithMessage("Wedding Id must not be null.");

            RuleFor(p => p.VendorID)
                .NotEmpty().WithMessage("Vendor Id must not be empty.")
                .NotNull().WithMessage("Vendor Id must not be null.");

            RuleFor(p => p.AmountPaid)
                .NotEmpty().WithMessage("Amount paid must not be empty.")
                .NotNull().WithMessage("Amount paid must not be null.")
                .GreaterThanOrEqualTo(0).WithMessage("Amount paid must be a positive number.")
                .LessThanOrEqualTo(100000).WithMessage("Amount paid must not exceed 100,000.");

            RuleFor(p => p.PaymentDate)
                .NotNull().WithMessage("Payment Date must not be null.")
                .NotEmpty().WithMessage("Payment Date must not be empty.")
                .GreaterThan(new DateTime(2020, 1, 1)).WithMessage("Date must be after January 1, 2020.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Date cannot be in the future.");

            RuleFor(p => p.PaymentMethod)
                .NotNull().WithMessage("Payment method must not be null.")
                .NotEmpty().WithMessage("Payment method must not be empty.")
                .Must(method => new[] { "Credit Card", "Debit Card", "Cash", "Bank Transfer", "UPI" }.Contains(method))
                .WithMessage("Payment method must be one of the following: Credit Card, Debit Card, Cash, Bank Transfer, or UPI.");
        }
    }
}

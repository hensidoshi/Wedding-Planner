using FluentValidation;
using WeddingPlanner_APICreation.Models;
namespace WeddingPlanner_APICreation.Validators
{
    public class VendorBookingsValidator : AbstractValidator<VendorBookingsModel>
    {
        public VendorBookingsValidator() 
        {
            //RuleFor(vb => vb.BookingID)
            //    .NotEmpty().WithMessage("Booking Id must not be empty.")
            //    .NotNull().WithMessage("Booking Id must not be null.");

            RuleFor(vb => vb.WeddingID)
                .NotEmpty().WithMessage("Wedding Id must not be empty.")
                .NotNull().WithMessage("Wedding Id must not be null.");

            RuleFor(vb => vb.VendorID)
                .NotEmpty().WithMessage("Vendor Id must not be empty.")
                .NotNull().WithMessage("Vendor Id must not be null.");

            RuleFor(vb => vb.ServiceCost)
                .NotEmpty().WithMessage("Service cost must not be empty.")
                .NotNull().WithMessage("Service cost must not be null.")
                .GreaterThanOrEqualTo(0).WithMessage("Service cost must be a positive number.")
                .LessThanOrEqualTo(100000).WithMessage("Service cost must not exceed 100,000.");

            RuleFor(vb => vb.BookingDate)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Booking Date must not be in the past.")
                .NotNull().WithMessage("Booking Date must not be null.")
                .NotEmpty().WithMessage("Booking Date must not be empty.");

            RuleFor(s => s.Remarks)
                .NotNull().WithMessage("Remarks must not be null.")
                .NotEmpty().WithMessage("Remarks must not be empty.")
                .MaximumLength(200).WithMessage("Remarks must not exceed 200 characters.")
                .Matches("^[A-Za-z0-9,.' ]*$").WithMessage("Remarks must contain only letters, numbers, commas, periods, apostrophes, and spaces.");  
        }
    }
}

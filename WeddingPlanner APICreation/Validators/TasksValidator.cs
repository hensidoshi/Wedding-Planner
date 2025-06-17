using FluentValidation;
using WeddingPlanner_APICreation.Models;
namespace WeddingPlanner_APICreation.Validators
{
    public class TasksValidator : AbstractValidator<TasksModel>
    {
        public TasksValidator() 
        {
            //RuleFor(t =>t.TaskID)
            //    .NotEmpty().WithMessage("Task Id must not be empty.")
            //    .NotNull().WithMessage("Task Id must not be null.");

            RuleFor(t =>t.WeddingID)
                .NotEmpty().WithMessage("Wedding Id must not be empty.")
                .NotNull().WithMessage("Wedding Id must not be null.");

            RuleFor(t => t.TaskDescription)
                .NotEmpty().WithMessage("Task description must not be empty.")
                .NotNull().WithMessage("Task description must not be null.")
                .Length(10, 200).WithMessage("Task description must be between 10 and 200 characters.");

            RuleFor(t => t.AssignedTo)
                .NotEmpty().WithMessage("Assigned To field must not be empty.")
                .NotNull().WithMessage("Assigned To field must not be null.")
                .Matches("^[A-Za-z ]*$").WithMessage("Assigned To must contain only letters and spaces.");

            RuleFor(t => t.Deadline)
                 .NotNull().WithMessage("Deadline must not be null.")
                 .NotEmpty().WithMessage("Deadline must not be empty.")
                 .LessThanOrEqualTo(DateTime.Today).WithMessage("Deadline must not be in the past.");

            RuleFor(t => t.Status)
                .NotEmpty().WithMessage("Status must not be empty.")
                .NotNull().WithMessage("Status must not be null.")
                .Must(status => new[] { "Pending", "In Progress", "Completed" }.Contains(status))
                .WithMessage("Status must be one of the following: Pending, In Progress, or Completed.");

        }
    }
}

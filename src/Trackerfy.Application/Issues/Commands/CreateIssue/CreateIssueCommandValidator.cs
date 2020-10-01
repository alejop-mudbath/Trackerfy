using FluentValidation;

namespace Trackerfy.Application.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandValidator: AbstractValidator<CreateIssueCommand>
    {
        public CreateIssueCommandValidator()
        {
            RuleFor(v => v.Summary)
                .NotEmpty().WithMessage("Summary is required.")
                .MaximumLength(100).WithMessage("Summary must not exceed 200 characters.");

            RuleFor(v => v.IssueTypeId)
                .NotEmpty().WithMessage("Issue Type Id is required.");
        }
    }
}
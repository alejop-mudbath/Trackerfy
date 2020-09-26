using FluentValidation;

namespace Trackerfy.Application.Commands.AssignAssignee
{
    public class AssignIssueCommandValidator: AbstractValidator<AssignAssigneeCommand>
    {
        public AssignIssueCommandValidator()
        {
            RuleFor(v => v.AssigneeUserId)
                .NotEmpty().WithMessage("Assignee Id required.");

            RuleFor(v => v.IssuedId)
                .NotEmpty().WithMessage("Issue Id is required.");
        }
    }
}
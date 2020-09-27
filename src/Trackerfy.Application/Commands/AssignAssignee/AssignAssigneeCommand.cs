using MediatR;

namespace Trackerfy.Application.Commands.AssignAssignee
{
    public class AssignAssigneeCommand : IRequest<int>
    {
        public AssignAssigneeCommand(int issueId, string assigneeUserId)
        {
            IssueId = issueId;
            AssigneeUserId = assigneeUserId;
        }

        public string AssigneeUserId { get; }

        public int IssueId { get; }
    }
}
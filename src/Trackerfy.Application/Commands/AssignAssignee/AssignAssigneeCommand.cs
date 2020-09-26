using MediatR;

namespace Trackerfy.Application.Commands.AssignAssignee
{
    public class AssignAssigneeCommand : IRequest<int>
    {
        public AssignAssigneeCommand(int issuedId, string assigneeUserId)
        {
            IssuedId = issuedId;
            AssigneeUserId = assigneeUserId;
        }

        public string AssigneeUserId { get; }

        public int IssuedId { get; }
    }
}
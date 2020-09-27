using MediatR;

namespace Trackerfy.Application.Commands.UpdateIssueState
{
    public class UpdateIssueStateCommand: IRequest
    {
        public int IssueId { get; private set; }
        public int IssueStateId { get; private set; }

        public UpdateIssueStateCommand(int IssueId, int IssueStateId)
        {
            this.IssueId = IssueId;
            this.IssueStateId = IssueStateId;
        }
    }
}
using MediatR;

namespace Trackerfy.Application.Commands.CreateIssue
{
    public class CreateIssueCommand: IRequest<int>
    {
        public CreateIssueCommand(string summary, int issueTypeId)
        {
            Summary = summary;
            IssueTypeId = issueTypeId;
        }
        public string Summary { get; }
        public int IssueTypeId { get; }
    }
}
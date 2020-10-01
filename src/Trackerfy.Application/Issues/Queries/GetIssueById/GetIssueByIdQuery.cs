using MediatR;
using Trackerfy.Application.Issues.Queries.GetAllIssues;

namespace Trackerfy.Application.Issues.Queries.GetIssueById
{
    public class GetIssueByIdQuery : IRequest<IssueDTO>
    {
        public GetIssueByIdQuery(int issueId)
        {
            IssueId = issueId;
        }

        public int IssueId { get; private set; }
    }
}
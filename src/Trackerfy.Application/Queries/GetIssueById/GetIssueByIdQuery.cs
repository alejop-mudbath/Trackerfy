using MediatR;
using Trackerfy.Application.Queries.GetAllIssues;

namespace Trackerfy.Application.Queries.GetIssueById
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
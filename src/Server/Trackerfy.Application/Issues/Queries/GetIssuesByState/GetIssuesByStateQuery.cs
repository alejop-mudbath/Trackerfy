using System.Collections.Generic;
using MediatR;
using Trackerfy.Application.Issues.Queries.GetAllIssues;

namespace Trackerfy.Application.Issues.Queries.GetIssuesByState
{
    public class GetIssuesByStateQuery : IRequest<List<IssueDTO>>
    {
        public int StateId { get; }

        public GetIssuesByStateQuery(in int stateId)
        {
            StateId = stateId;
        }
    }
}
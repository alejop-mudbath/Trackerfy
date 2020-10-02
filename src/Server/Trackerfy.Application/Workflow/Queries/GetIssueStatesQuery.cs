using System.Collections.Generic;
using MediatR;

namespace Trackerfy.Application.Workflow.Queries
{
    public class GetIssueStatesQuery : IRequest<List<IssueStateDTO>>
    {
    }
}
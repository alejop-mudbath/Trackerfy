using System.Collections.Generic;
using MediatR;

namespace Trackerfy.Application.Issues.Queries.GetAllIssues
{
    public class GetAllIssuesQuery: IRequest<List<IssueDTO>>
    {

    }
}
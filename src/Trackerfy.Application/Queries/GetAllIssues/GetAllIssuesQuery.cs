using System.Collections.Generic;
using MediatR;

namespace Trackerfy.Application.Queries.GetAllIssues
{
    public class GetAllIssuesQuery: IRequest<List<IssueDTO>>
    {

    }
}
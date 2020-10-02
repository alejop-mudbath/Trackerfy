using System.Collections.Generic;
using MediatR;

namespace Trackerfy.Application.IssueTypes.Queries.GetIssueTypes
{
    public class GetIssueTypesQuery: IRequest<List<IssueTypesDTO>>
    {

    }
}
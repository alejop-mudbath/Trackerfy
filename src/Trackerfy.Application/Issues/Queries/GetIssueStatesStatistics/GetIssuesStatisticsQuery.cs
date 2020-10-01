using System.Collections.Generic;
using MediatR;

namespace Trackerfy.Application.Issues.Queries.GetIssueStatesStatistics
{
    public class GetIssuesStatisticsQuery : IRequest<List<IssueStateStatisticDTO>>
    {
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Common.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Issues.Queries.GetIssueStatesStatistics
{
    public class
        GetIssuesStatisticsQueryHandler : IRequestHandler<GetIssuesStatisticsQuery, List<IssueStateStatisticDTO>>
    {
        private IContext _context;
        private IMapper _mapper;

        public GetIssuesStatisticsQueryHandler(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IssueStateStatisticDTO>> Handle(GetIssuesStatisticsQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Set<Issue>()
                .AsNoTracking()
                .GroupBy(issue => new {issue.IssueStateId, issue.IssueState.Description})
                .Select(s => new IssueStateStatisticDTO
                {
                    stateId = s.Key.IssueStateId,
                    stateDescription = s.Key.Description,
                    count = s.Sum(x => x.Id)
                }).ToListAsync(cancellationToken);
        }
    }
}
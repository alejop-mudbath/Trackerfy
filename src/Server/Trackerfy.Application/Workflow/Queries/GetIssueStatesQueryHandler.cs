using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Common.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Workflow.Queries
{
    public class GetIssueStatesQueryHandler : IRequestHandler<GetIssueStatesQuery, List<IssueStateDTO>>
    {
        private readonly IContext _context;

        public GetIssueStatesQueryHandler(IContext context)
        {
            _context = context;
        }

        public async Task<List<IssueStateDTO>> Handle(GetIssueStatesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<IssueState>()
                .Select(x => new IssueStateDTO
                {
                    Id = x.Id,
                    Description = x.Description
                })
                .ToListAsync(cancellationToken);
        }
    }
}
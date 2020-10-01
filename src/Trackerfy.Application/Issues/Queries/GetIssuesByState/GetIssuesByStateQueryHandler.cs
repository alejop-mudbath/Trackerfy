using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Common.Interfaces;
using Trackerfy.Application.Issues.Queries.GetAllIssues;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Issues.Queries.GetIssuesByState
{
    public class GetIssuesByStateQueryHandler : IRequestHandler<GetIssuesByStateQuery, List<IssueDTO>>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetIssuesByStateQueryHandler(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IssueDTO>> Handle(GetIssuesByStateQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<Issue>()
                .Where(i => i.IssueStateId.Equals(request.StateId))
                .ProjectTo<IssueDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
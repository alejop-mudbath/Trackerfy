using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Queries.GetAllIssues
{
    public class GetAllIssuesQueryHandler: IRequestHandler<GetAllIssuesQuery, List<IssueDTO>>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetAllIssuesQueryHandler(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<IssueDTO>> Handle(GetAllIssuesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<Issue>()
                .ProjectTo<IssueDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
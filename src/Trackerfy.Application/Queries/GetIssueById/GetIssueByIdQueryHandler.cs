using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Common.Exceptions;
using Trackerfy.Application.Interfaces;
using Trackerfy.Application.Queries.GetAllIssues;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Queries.GetIssueById
{
    public class GetIssueByIdQueryHandler: IRequestHandler<GetIssueByIdQuery, IssueDTO>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetIssueByIdQueryHandler(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IssueDTO> Handle(GetIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var issue =  await _context.Set<Issue>()
                .Where(x => x.Id == request.IssueId)
                .ProjectTo<IssueDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if(issue == null)
                throw new NotFoundException(nameof(Issue), request.IssueId);

            return issue;
        }
    }
}
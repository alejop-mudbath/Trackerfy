using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Common.Exceptions;
using Trackerfy.Application.Common.Interfaces;
using Trackerfy.Application.Issues.Queries.GetAllIssues;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Issues.Queries.GetIssueById
{
    public class GetIssueByIdQueryHandler : IRequestHandler<GetIssueByIdQuery, IssueDTO>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetIssueByIdQueryHandler(IContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IssueDTO> Handle(GetIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var issue = await _context.Set<Issue>()
                .Where(x => x.Id == request.IssueId)
                .ProjectTo<IssueDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);


            if (issue == null)
                throw new NotFoundException(nameof(Issue), request.IssueId);

            var users = await _userService.GetAll();
            if (!string.IsNullOrEmpty(issue.LastModifiedBy))
                issue.LastModifiedByName = users.First(x => x.user_id.Equals(issue.LastModifiedBy)).name;

            issue.CreatedByName = users.First(x => x.user_id.Equals(issue.CreatedBy)).name;

            return issue;
        }
    }
}
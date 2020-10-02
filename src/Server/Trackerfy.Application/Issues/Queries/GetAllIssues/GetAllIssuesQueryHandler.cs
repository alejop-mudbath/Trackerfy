using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Common.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Issues.Queries.GetAllIssues
{
    public class GetAllIssuesQueryHandler: IRequestHandler<GetAllIssuesQuery, List<IssueDTO>>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetAllIssuesQueryHandler(IContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<List<IssueDTO>> Handle(GetAllIssuesQuery request, CancellationToken cancellationToken)
        {
            var issues = await _context.Set<Issue>()
                .ProjectTo<IssueDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var users = await _userService.GetAll();
            foreach (var issueDto in issues)
            {
                if(!string.IsNullOrEmpty(issueDto.LastModifiedBy))
                    issueDto.LastModifiedByName = users.First(x => x.user_id.Equals(issueDto.LastModifiedBy)).name;

                issueDto.CreatedByName = users.First(x => x.user_id.Equals(issueDto.CreatedBy)).name;
            }
            return issues;
        }
    }
}
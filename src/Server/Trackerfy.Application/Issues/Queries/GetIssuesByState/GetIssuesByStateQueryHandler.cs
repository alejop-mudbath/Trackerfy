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
        private readonly IUserService _userService;

        public GetIssuesByStateQueryHandler(IContext context, IMapper mapper,  IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<List<IssueDTO>> Handle(GetIssuesByStateQuery request, CancellationToken cancellationToken)
        {
            var issues = await _context.Set<Issue>()
                .Where(i => i.IssueStateId.Equals(request.StateId))
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
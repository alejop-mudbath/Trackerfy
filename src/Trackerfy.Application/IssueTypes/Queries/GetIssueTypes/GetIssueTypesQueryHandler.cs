using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.IssueTypes.Queries.GetIssueTypes
{
    public class GetIssueTypesQueryHandler : IRequestHandler<GetIssueTypesQuery, List<IssueTypesDTO>>
    {
        private readonly IContext _context;

        public GetIssueTypesQueryHandler(IContext context)
        {
            _context = context;
        }

        public Task<List<IssueTypesDTO>> Handle(GetIssueTypesQuery request, CancellationToken cancellationToken)
        {
            return _context.Set<IssueType>()
                .Select(x => new IssueTypesDTO
                {
                    Id = x.Id,
                    Description = x.Description
                })
                .ToListAsync(cancellationToken);
        }
    }
}
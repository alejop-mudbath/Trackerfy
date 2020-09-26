using System.Threading;
using System.Threading.Tasks;
using Trackerfy.Application.Common.Exceptions;
using Trackerfy.Application.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Infrastructure.Persistence.Issues
{
    public class IssueRepository : IIssueRepository
    {
        private readonly Context _context;

        public IssueRepository(Context context)
        {
            _context = context;
        }

        public void Add(Issue issue)
        {
            _context.Set<Issue>().Add(issue);
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Issue> findByIdAsync(int issueId)
        {
            var issue = await _context.Set<Issue>().FindAsync(issueId);

            if(issue == null)
                throw new NotFoundException(nameof(Issue), issueId);

            return issue;
        }
    }
}
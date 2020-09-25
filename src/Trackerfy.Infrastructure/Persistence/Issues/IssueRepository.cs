using System.Threading;
using System.Threading.Tasks;
using Trackerfy.Application.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Infrastructure.Persistence.Issues
{
    public class IssueRepository: IIssueRepository
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
    }
}
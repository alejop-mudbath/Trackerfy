using System.Linq;
using System.Threading;
using Trackerfy.Application.Common.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Infrastructure.Persistence.IssueTypes
{
    public class IssueTypeRepository : IIssueTypeRepository
    {
        private readonly Context _context;

        public IssueTypeRepository(Context context)
        {
            _context = context;
        }

        public void Add(IssueType issueType)
        {
            _context.Set<IssueType>().Add(issueType);
        }

        public IssueType GetFirst()
        {
            return _context.Set<IssueType>().First();
        }

        public void Commit(CancellationToken cancellationToken = new CancellationToken())
        {
            _context.SaveChangesAsync(cancellationToken);
        }
    }
}
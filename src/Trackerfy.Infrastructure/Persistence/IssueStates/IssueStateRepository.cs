using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Common.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Infrastructure.Persistence.IssueStates
{
    public class IssueStateRepository: IIssueStateRepository
    {
        private readonly Context _context;

        public IssueStateRepository(Context context)
        {
            _context = context;
        }

        public Task<IssueState> GetDefaultState()
        {
            return _context.Set<IssueState>().OrderBy(x => x.Id).FirstAsync();
        }
    }
}
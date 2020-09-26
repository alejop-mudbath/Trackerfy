using System.Threading;
using System.Threading.Tasks;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Interfaces
{
    public interface IIssueRepository
    {
        void Add(Issue issue);
        Task<int> Commit(CancellationToken cancellationToken = new CancellationToken());
        Task<Issue> findByIdAsync(int issueId);
    }
}
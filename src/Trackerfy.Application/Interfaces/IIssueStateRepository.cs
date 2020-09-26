using System.Threading.Tasks;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Interfaces
{
    public interface IIssueStateRepository
    {
        Task<IssueState> GetDefaultState();
    }
}
using System.Threading.Tasks;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Common.Interfaces
{
    public interface IIssueStateRepository
    {
        Task<IssueState> GetDefaultState();
    }
}
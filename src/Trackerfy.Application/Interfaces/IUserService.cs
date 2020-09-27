using System.Threading.Tasks;

namespace Trackerfy.Application.Interfaces
{
    public interface IUserService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<string> CreateUserAsync(string userName, string password, string name);
    }
}
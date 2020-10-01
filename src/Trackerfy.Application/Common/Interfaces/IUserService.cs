using System.Collections.Generic;
using System.Threading.Tasks;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
    }
}
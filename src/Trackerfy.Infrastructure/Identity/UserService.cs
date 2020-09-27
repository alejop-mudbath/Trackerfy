using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Interfaces;

namespace Trackerfy.Infrastructure.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<string> CreateUserAsync(string userName, string password, string name)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
                Name = name
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                throw new Exception("Create error");

            return user.Id;
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trackerfy.Application.Interfaces;

namespace Trackerfy.API.Controllers.UserAccess
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            await _userService.CreateUserAsync(request.Username, request.Password, request.Name);

            return Ok();
        }
    }
}
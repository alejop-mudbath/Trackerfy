using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trackerfy.Application.Interfaces;

namespace Trackerfy.API.Controllers.UserAccess
{
    [Route("api/[controller]")]
    [ApiController]
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
            var userId = await _userService.CreateUserAsync(request.Name, request.Email, request.Password);

            return Ok(userId);
        }
    }
}
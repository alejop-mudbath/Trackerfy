using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Trackerfy.Application;
using Trackerfy.Application.Common.Interfaces;

namespace Trackerfy.API
{
    public class CurrentUserService: ICurrentUserService
    {
        public string GetUserId()
        {
            return UserId;
        }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    }
}
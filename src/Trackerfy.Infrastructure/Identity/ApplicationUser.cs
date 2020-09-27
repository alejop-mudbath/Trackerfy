using Microsoft.AspNetCore.Identity;

namespace Trackerfy.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

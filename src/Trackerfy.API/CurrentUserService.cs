using Trackerfy.Application;

namespace Trackerfy.API
{
    public class CurrentUserService: ICurrentUserService
    {
        public string GetUserId()
        {
            return "123";
        }
    }
}
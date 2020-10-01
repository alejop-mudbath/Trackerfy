using Trackerfy.Application;
using Trackerfy.Application.Common.Interfaces;

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
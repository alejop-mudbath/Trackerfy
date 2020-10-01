using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Trackerfy.Application.Common.Interfaces;

namespace Trackerfy.Application.Users.Queries.GetAll
{
    public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQuery, List<UserDTO>>
    {
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAll();
            return users.Select(s => new UserDTO
            {
                Id = s.user_id,
                Name = s.name,
                Email = s.email,
                Username = s.username,
                Picture = s.picture
            }).ToList();

        }
    }
}
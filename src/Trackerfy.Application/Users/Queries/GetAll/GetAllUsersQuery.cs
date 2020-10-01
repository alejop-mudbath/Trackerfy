using System.Collections.Generic;
using MediatR;

namespace Trackerfy.Application.Users.Queries.GetAll
{
    public class GetAllUsersQuery: IRequest<List<UserDTO>>
    {
        
    }
}
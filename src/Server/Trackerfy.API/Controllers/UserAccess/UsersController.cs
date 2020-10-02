using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trackerfy.Application.Users.Queries.GetAll;

namespace Trackerfy.API.Controllers.UserAccess
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async  Task<ActionResult<List<UserDTO>>>  GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllUsersQuery();
            return await _mediator.Send(query, cancellationToken);
        }
    }

}
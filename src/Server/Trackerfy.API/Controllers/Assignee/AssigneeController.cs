using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trackerfy.Application.Issues.Commands.AssignAssignee;

namespace Trackerfy.API.Controllers.Assignee
{
    [Route("api/issues/[controller]")]
    [ApiController]
    public class AssigneeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssigneeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Assign(AssignAssigneeRequest request, CancellationToken cancellationToken)
        {
            var command = new AssignAssigneeCommand(request.IssueId, request.AssigneeUserId);
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
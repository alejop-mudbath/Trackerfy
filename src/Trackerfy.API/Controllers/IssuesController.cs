using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trackerfy.Application.Commands.CreateIssue;

namespace Trackerfy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IssuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateIssueRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateIssueCommand(request.Summary, request.IssueTypeId);
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
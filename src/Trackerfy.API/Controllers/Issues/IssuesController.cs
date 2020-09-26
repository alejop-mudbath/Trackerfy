using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trackerfy.Application.Commands.CreateIssue;
using Trackerfy.Application.Queries.GetAllIssues;

namespace Trackerfy.API.Controllers.Issues
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
        
        [HttpGet]
        public async Task<ActionResult<List<IssueDTO>>> Get(CancellationToken cancellationToken)
        {
            var command = new GetAllIssuesQuery();
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
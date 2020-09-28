using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trackerfy.Application.Commands.CreateIssue;
using Trackerfy.Application.Commands.UpdateIssueState;
using Trackerfy.Application.Queries.GetAllIssues;
using Trackerfy.Application.Queries.GetIssueById;

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
            var query = new GetAllIssuesQuery();
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet]
        [Route("{issueId}")]
        public async Task<ActionResult<IssueDTO>> GetById(int issueId, CancellationToken cancellationToken)
        {
            var query = new GetIssueByIdQuery(issueId);
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpPut("{issueId}/state")]
        public async Task<Unit> Update(int issueId, UpdateIssueStateRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateIssueStateCommand(issueId, request.IssueStateId);
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
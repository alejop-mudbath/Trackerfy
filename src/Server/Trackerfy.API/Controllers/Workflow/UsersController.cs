using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trackerfy.Application.Users.Queries.GetAll;
using Trackerfy.Application.Workflow.Queries;

namespace Trackerfy.API.Controllers.Workflow
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : Controller
    {
        private readonly IMediator _mediator;

        public WorkflowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("states")]
        public async  Task<ActionResult<List<IssueStateDTO>>>  GetStates(CancellationToken cancellationToken)
        {
            var query = new GetIssueStatesQuery();
            return await _mediator.Send(query, cancellationToken);
        }
    }

}
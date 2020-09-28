using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trackerfy.Application.IssueTypes.Queries.GetIssueTypes;

namespace Trackerfy.API.Controllers.IssueTypes
{
    [Route("api/issues/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<IssueTypesDTO>>> Assign(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetIssueTypesQuery(), cancellationToken));
        }
    }
}
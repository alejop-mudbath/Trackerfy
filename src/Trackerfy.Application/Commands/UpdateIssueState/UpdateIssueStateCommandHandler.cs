using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Trackerfy.Application.Interfaces;

namespace Trackerfy.Application.Commands.UpdateIssueState
{
    public class UpdateIssueStateCommandHandler: IRequestHandler<UpdateIssueStateCommand>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateIssueStateCommandHandler(IIssueRepository issueRepository,ICurrentUserService currentUserService)
        {
            _issueRepository = issueRepository;
            _currentUserService = currentUserService;
        }
        public async Task<Unit> Handle(UpdateIssueStateCommand request, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.findByIdAsync(request.IssueId);

            issue.UpdateState(request.IssueStateId);

            await _issueRepository.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
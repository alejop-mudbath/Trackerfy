using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Trackerfy.Application.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application.Commands.CreateIssue
{
    public class CreateIssueCommandHandler: IRequestHandler<CreateIssueCommand, int>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IIssueRepository _issueRepository;
        private readonly IIssueStateRepository _issueStateRepository;

        public CreateIssueCommandHandler(ICurrentUserService currentUserServiceService,
            IIssueRepository issueRepository,
            IIssueStateRepository issueStateRepository)
        {
            _currentUserService = currentUserServiceService;
            _issueRepository = issueRepository;
            _issueStateRepository = issueStateRepository;
        }

        public async Task<int> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var defaultState = await _issueStateRepository.GetDefaultState();

            var issue = new Issue(request.Summary, request.IssueTypeId, userId, defaultState);
            _issueRepository.Add(issue);

            await _issueRepository.Commit(cancellationToken);
            return issue.Id;
        }
    }
}
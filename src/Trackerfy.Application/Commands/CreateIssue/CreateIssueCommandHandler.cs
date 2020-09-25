using System.Threading;
using System.Threading.Tasks;
using Trackerfy.Application.Interfaces;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Application
{
    public class CreateIssueCommandHandler
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IIssueRepository _issueRepository;

        public CreateIssueCommandHandler(ICurrentUserService currentUserServiceService, IIssueRepository issueRepository)
        {
            _currentUserService = currentUserServiceService;
            _issueRepository = issueRepository;
        }

        public async Task<int> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var issue = new Issue(request.Summary, request.IssueTypeId, userId);

            _issueRepository.Add(issue);

            await _issueRepository.Commit(cancellationToken);
            return issue.Id;
        }
    }
}
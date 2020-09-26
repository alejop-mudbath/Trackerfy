using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Trackerfy.Application.Commands.AssignAssignee;
using Trackerfy.Application.Commands.CreateIssue;
using Trackerfy.Application.Interfaces;
using Trackerfy.Domain.Entities;
using Trackerfy.Infrastructure.Persistence.Issues;
using Xunit;

namespace Trackerfy.IntegrationTests
{
    public class AssignAssigneeCommandTests
    {
        private readonly IIssueRepository _issueRepository;

        public AssignAssigneeCommandTests()
        {
            _issueRepository = new IssueRepository(ContextFactory.CreateInMemoryContext());
        }

        [Fact]
        public async Task AddAssigned_ShouldAddUser()
        {
            const string assignedUserId = "12";
            var issue = await CreateIssue();
            var command = new AssignAssigneeCommand(issue.Id, assignedUserId);
            var handler = new AssignAssigneeCommandHandler(_issueRepository);

            var result = await handler.Handle(command, CancellationToken.None);

            result.ShouldNotBeNull();
            var issueUpdate = await _issueRepository.findByIdAsync(issue.Id);
            issueUpdate.Assignee.ShouldBe(assignedUserId);
        }

        private async Task<Issue> CreateIssue()
        {
            var issue = new Issue("sa", 1, "1", new IssueState("1"));
            _issueRepository.Add(issue);
            await _issueRepository.Commit();
            return issue;
        }
    }
}
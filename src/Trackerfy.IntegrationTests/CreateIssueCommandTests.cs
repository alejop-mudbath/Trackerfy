using System;
using System.Threading;
using Moq;
using Shouldly;
using Trackerfy.Application;
using Trackerfy.Application.Commands.CreateIssue;
using Trackerfy.Application.Interfaces;
using Trackerfy.Domain;
using Trackerfy.Infrastructure.Persistence.Issues;
using Trackerfy.Domain.Entities;
using Trackerfy.Infrastructure.Persistence.IssueStates;
using Trackerfy.Infrastructure.Persistence.IssueTypes;
using Xunit;

namespace Trackerfy.IntegrationTests
{
    public class CreateIssueCommandTests
    {
        private readonly CreateIssueCommandHandler _handler;
        private readonly IIssueRepository _issueRepository;
        private readonly string _currentUserId;
        private readonly IIssueTypeRepository _issueTypeRepository;
        private IssueType _issueType;
        private readonly CreateIssueCommand _request;
        private IIssueStateRepository _issueStateRepository;

        public CreateIssueCommandTests()
        {
            _currentUserId = "1a";
            var context = ContextFactory.CreateInMemoryContext();
            _issueTypeRepository = new IssueTypeRepository(context);
            _issueRepository = new IssueRepository(context);
            _issueStateRepository = new IssueStateRepository(context);
            SeedDataTest();

            var currentUserService = new Mock<ICurrentUserService>();
            currentUserService.Setup(x => x.GetUserId()).Returns(_currentUserId);

            _handler = new CreateIssueCommandHandler(currentUserService.Object, _issueRepository, _issueStateRepository);
            _request = new CreateIssueCommand("Summary 1", _issueType.Id);
        }

        [Fact]
        public async void CreateIssue_ShouldBe_Persisted()
        {

            var result = await _handler.Handle(_request, CancellationToken.None);

            result.ShouldNotBeNull();
        }

        [Fact]
        public async void CreateIssue_ShouldHas_requiredData()
        {
            var result = await _handler.Handle(_request, CancellationToken.None);

            var issue = await _issueRepository.findByIdAsync(result);
            issue.Summary.ShouldNotBeEmpty();
            issue.IssueTypeId.ShouldBe(_issueType.Id);
        }

        [Fact]
        public async void CreateIssue_ShouldHas_AuditCreationData()
        {
            var creationDate = DateTime.Now;
            SystemClock.Set(creationDate);

            var result = await _handler.Handle(_request, CancellationToken.None);

            var issue = await _issueRepository.findByIdAsync(result);
            issue.CreatedBy.ShouldBe(_currentUserId);
            issue.Created.ShouldBe(creationDate);
        }

        [Fact]
        public async void CreateIssue_ShouldHas_DefaultState()
        {
            var creationDate = DateTime.Now;
            SystemClock.Set(creationDate);

            var result = await _handler.Handle(_request, CancellationToken.None);

            var issue = await _issueRepository.findByIdAsync(result);
            issue.IssueState.ShouldBe(await _issueStateRepository.GetDefaultState());
        }

        private void SeedDataTest()
        {
            _issueTypeRepository.Add(new IssueType("Bug"));
            _issueTypeRepository.Commit();
            _issueType = _issueTypeRepository.GetFirst();
        }
    }
}
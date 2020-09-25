using System;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using Trackerfy.Application;
using Trackerfy.Application.Interfaces;
using Trackerfy.Infrastructure;
using Trackerfy.Infrastructure.Persistence.Issues;
using Trackerfy.Domain.Entities;
using Xunit;

namespace Trackerfy.IntegrationTests
{
    public class CreateIssueTests
    {
        private readonly Context _context;
        private readonly CreateIssueCommandHandler _handler;
        private readonly IIssueRepository _issueRepository;
        private readonly Mock<ICurrentUserService> _currentUserService;
        private readonly string _currentUserId;

        public CreateIssueTests()
        {
            _currentUserId = "1a";
            _context = ContextFactory.CreateInMemoryContext();
            _context.Set<IssueType>().Add(new IssueType("Bug"));
            _context.SaveChanges();

            _issueRepository = new IssueRepository(_context);
            _currentUserService = new Mock<ICurrentUserService>();
            _currentUserService.Setup(x => x.GetUserId()).Returns(_currentUserId);
            _handler = new CreateIssueCommandHandler(_currentUserService.Object, _issueRepository);
        }

        [Fact]
        public async void CreateIssue_ShouldBe_Persisted()
        {
            var issueType = _context.Set<IssueType>().First();
            const string summary = "Summary 1";

            var result = await _handler.Handle(new CreateIssueCommand(summary, issueType.Id), CancellationToken.None);

            result.ShouldNotBeNull();
        }

        [Fact]
        public async void CreateIssue_ShouldBeHas_requiredData()
        {
            var issueType = _context.Set<IssueType>().First();
            const string summary = "Summary 1";

            var result = await _handler.Handle(new CreateIssueCommand(summary, issueType.Id), CancellationToken.None);

            var issue = await _issueRepository.findByIdAsync(result);
            issue.Summary.ShouldNotBeEmpty();
            issue.IssueTypeId.ShouldBe(issueType.Id);
        }
    }
}
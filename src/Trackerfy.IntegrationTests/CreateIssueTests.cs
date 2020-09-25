using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
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
        [Fact]
        public async void CreateIssue_ShouldBe_Persisted()
        {
            var context = CreateInMemoryContext();
            await context.Set<IssueType>().AddAsync(new IssueType("Bug"));
            await context.SaveChangesAsync();

            IIssueRepository issueRepository = new IssueRepository(context);
            ICurrentUserService currentUser = new CurrentUserStub();
            var issueType = context.Set<IssueType>().First();

            var handler = new CreateIssueCommandHandler(currentUser, issueRepository);
            const string summary = "Summary 1";
            var result = await handler.Handle(new CreateIssueCommand(summary, issueType.Id), CancellationToken.None);

            result.ShouldNotBeNull();
            var issue = context.Set<Issue>().Find(result);
            issue.CreatedBy.ShouldBe(currentUser.GetUserId());
        }

        private static Context CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new Context(options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}

public class CurrentUserStub : ICurrentUserService
{
    public string GetUserId()
    {
        return "434";
    }
}
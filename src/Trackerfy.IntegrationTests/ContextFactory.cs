using System;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Application;
using Trackerfy.Application.Common.Interfaces;
using Trackerfy.Infrastructure;
using Trackerfy.Infrastructure.Persistence;

namespace Trackerfy.IntegrationTests
{
    public class ContextFactory
    {
        public static Context CreateInMemoryContext(ICurrentUserService currentUserService)
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new Context(options, currentUserService);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Trackerfy.Infrastructure;

namespace Trackerfy.IntegrationTests
{
    public class ContextFactory
    {
        public static Context CreateInMemoryContext()
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
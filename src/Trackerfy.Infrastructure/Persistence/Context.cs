using Microsoft.EntityFrameworkCore;
using Trackerfy.Application.Interfaces;
using Trackerfy.Infrastructure.Persistence.Issues;
using Trackerfy.Infrastructure.Persistence.IssueStates;
using Trackerfy.Infrastructure.Persistence.IssueTypes;

namespace Trackerfy.Infrastructure.Persistence
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IssueEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IssueTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IssueStateEntityTypeConfiguration());
        }
    }
}
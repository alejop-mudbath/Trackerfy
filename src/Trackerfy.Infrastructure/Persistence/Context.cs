using Microsoft.EntityFrameworkCore;
using Trackerfy.Infrastructure.Configurations;

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
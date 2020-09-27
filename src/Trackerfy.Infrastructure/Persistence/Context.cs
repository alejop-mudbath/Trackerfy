using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Trackerfy.Application;
using Trackerfy.Application.Interfaces;
using Trackerfy.Domain;
using Trackerfy.Domain.Entities;
using Trackerfy.Infrastructure.Identity;
using Trackerfy.Infrastructure.Persistence.Issues;
using Trackerfy.Infrastructure.Persistence.IssueStates;
using Trackerfy.Infrastructure.Persistence.IssueTypes;

namespace Trackerfy.Infrastructure.Persistence
{
    public class Context : ApiAuthorizationDbContext<ApplicationUser>, IContext
    {
        private readonly ICurrentUserService _currentUserService;

        public Context(DbContextOptions options, ICurrentUserService currentUserService)
            : base(options, new OperationalStoreOptionsMigrations())
        {
            _currentUserService = currentUserService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.GetUserId();
                        entry.Entity.Created = SystemClock.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.GetUserId();
                        entry.Entity.LastModified = SystemClock.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IssueEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IssueTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IssueStateEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
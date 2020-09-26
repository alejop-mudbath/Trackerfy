using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Infrastructure.Configurations
{
    public class IssueStateEntityTypeConfiguration: IEntityTypeConfiguration<IssueState>
    {
        public void Configure(EntityTypeBuilder<IssueState> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .IsRequired();

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<IssueState> builder)
        {
            builder.HasData(
                new IssueState("To Do") {Id = 1},
                new IssueState("In Progress") {Id = 2},
                new IssueState("Completed") {Id = 3});
        }
    }
}
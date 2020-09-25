using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Infrastructure.Configurations
{
    public class IssueEntityTypeConfiguration: IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Summary)
                .IsRequired();

            builder.Property(e => e.Created)
                .IsRequired();

            builder.Property(e => e.CreatedBy)
                .IsRequired();

            builder.HasOne(e => e.IssueState)
                .WithMany()
                .HasForeignKey(e => e.IssueStateId);

            builder.HasOne(e => e.IssueType)
                .WithMany()
                .HasForeignKey(e => e.IssueTypeId);
        }
    }
}
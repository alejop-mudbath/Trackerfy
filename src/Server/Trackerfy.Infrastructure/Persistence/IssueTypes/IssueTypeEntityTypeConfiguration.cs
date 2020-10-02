using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Infrastructure.Persistence.IssueTypes
{
    public class IssueTypeEntityTypeConfiguration: IEntityTypeConfiguration<IssueType>
    {
        public void Configure(EntityTypeBuilder<IssueType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .IsRequired();

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<IssueType> builder)
        {
            builder.HasData(
                new IssueType("Story") {Id = 1}, new IssueType("Bug") {Id = 2});
        }
    }
}
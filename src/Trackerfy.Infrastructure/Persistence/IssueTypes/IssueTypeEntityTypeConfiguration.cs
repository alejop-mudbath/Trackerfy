using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trackerfy.Domain.Entities;

namespace Trackerfy.Infrastructure.Configurations
{
    public class IssueTypeEntityTypeConfiguration: IEntityTypeConfiguration<IssueType>
    {
        public void Configure(EntityTypeBuilder<IssueType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .IsRequired();
        }
    }
}
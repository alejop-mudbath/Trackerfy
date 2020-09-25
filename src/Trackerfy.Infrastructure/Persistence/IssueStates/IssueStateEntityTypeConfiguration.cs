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
        }
    }
}
using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class TrackJobTitleAndLeaveHistoryConfig : IEntityTypeConfiguration<TrackJobTitleAndLeaveHistory>
{
    void IEntityTypeConfiguration<TrackJobTitleAndLeaveHistory>.Configure(EntityTypeBuilder<TrackJobTitleAndLeaveHistory> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "TrackJobTitleAndLeaveHistories");

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");
    }
}

using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class TrackJobTitleAndLeaveHistoryConfigurations : IEntityTypeConfiguration<TrackJobTitleAndLeaveHistory>
{
    void IEntityTypeConfiguration<TrackJobTitleAndLeaveHistory>.Configure(EntityTypeBuilder<TrackJobTitleAndLeaveHistory> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "TrackJobTitleAndLeaveHistories","hr");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}

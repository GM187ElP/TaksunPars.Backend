using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;

public class StartLeaveHistoryConfig : IEntityTypeConfiguration<StartLeaveHistory>
{
    void IEntityTypeConfiguration<StartLeaveHistory>.Configure(EntityTypeBuilder<StartLeaveHistory> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "StartLeaveHistories");
    }
}

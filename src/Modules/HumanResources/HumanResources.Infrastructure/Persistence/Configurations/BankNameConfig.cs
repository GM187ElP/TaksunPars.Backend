using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;

public class BankNameConfig : IEntityTypeConfiguration<BankName>
{
    void IEntityTypeConfiguration<BankName>.Configure(EntityTypeBuilder<BankName> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "BankNameList");
        builder.HasKey(x => x.Name);
    }
}

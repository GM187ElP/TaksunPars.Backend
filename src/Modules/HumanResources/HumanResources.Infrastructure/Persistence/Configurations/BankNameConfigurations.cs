using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class BankNameConfigurations : IEntityTypeConfiguration<BankName>
{
    void IEntityTypeConfiguration<BankName>.Configure(EntityTypeBuilder<BankName> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "BankNameList","hr");

        builder.HasKey(x => x.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasIndex(b => b.Name)
            .IsUnique();

        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}

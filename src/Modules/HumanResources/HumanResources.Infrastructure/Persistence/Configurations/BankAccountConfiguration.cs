using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Interfaces;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    void IEntityTypeConfiguration<BankAccount>.Configure(EntityTypeBuilder<BankAccount> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "BankAccounts","hr");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}



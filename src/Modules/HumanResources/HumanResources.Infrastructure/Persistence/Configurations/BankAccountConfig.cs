using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
{
    void IEntityTypeConfiguration<BankAccount>.Configure(EntityTypeBuilder<BankAccount> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "BankAccounts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");
        builder.Property(x => x.AccountNumber).HasMaxLength(21);
        builder.Property(x => x.Iban).HasMaxLength(22).IsRequired();
    }
}



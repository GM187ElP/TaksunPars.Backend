using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Persistence.Configurations;

public class ChequePromissionaryNoteConfigurations : IEntityTypeConfiguration<ChequePromissionaryNote>
{
    void IEntityTypeConfiguration<ChequePromissionaryNote>.Configure(EntityTypeBuilder<ChequePromissionaryNote> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "ChequePromissionaryNotes", "hr");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.Number)
            .IsRequired();

        builder.HasQueryFilter(b => !b.IsDeleted);

        //builder.Property(x => x.Type).HasConversion(c => Conversions.NoteType2String(c), c => Conversions.String2NoteType(c));
    }
}


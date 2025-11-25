using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;

public class ChequePromissionaryNoteConfig : IEntityTypeConfiguration<ChequePromissionaryNote>
{
    void IEntityTypeConfiguration<ChequePromissionaryNote>.Configure(EntityTypeBuilder<ChequePromissionaryNote> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "ChequePromissionaryNotes");
        builder.Property(x => x.Number).IsRequired();
        builder.Property(x => x.Type).HasConversion(c => Conversions.NoteType2String(c), c => Conversions.String2NoteType(c));
    }
}


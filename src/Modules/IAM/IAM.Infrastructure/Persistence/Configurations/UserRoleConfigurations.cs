using IAM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IAM.Infrastructure.Persistence.Configurations;

public class UserRoleConfigurations : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable(builder, "UserRoles", "iam");

        builder.HasKey(x => new { x.UserId, x.RoleId });
    }
}

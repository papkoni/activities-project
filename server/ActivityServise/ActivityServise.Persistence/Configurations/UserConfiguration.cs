using ActivityServise.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityServise.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.Property(u => u.DisplayName)
            .HasMaxLength(100);

        builder.Property(u => u.Bio)
            .HasMaxLength(500);

        builder.Property(u => u.ImageUrl)
            .HasMaxLength(500);

        builder.HasMany(u => u.Followings)
            .WithOne(uf => uf.Observer)
            .HasForeignKey(uf => uf.ObserverId);

        builder.HasMany(u => u.Followers)
            .WithOne(uf => uf.Target)
            .HasForeignKey(uf => uf.TargetId);
    }
}

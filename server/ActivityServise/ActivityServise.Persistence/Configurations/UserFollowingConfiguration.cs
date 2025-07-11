using ActivityServise.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityServise.Persistence.Configurations;

public class UserFollowingConfiguration : IEntityTypeConfiguration<UserFollowing>
{
    public void Configure(EntityTypeBuilder<UserFollowing> builder)
    {
        builder.ToTable("UserFollowings");

        builder.HasKey(uf => new { uf.ObserverId, uf.TargetId });

        builder.HasOne(uf => uf.Observer)
            .WithMany(u => u.Followings)
            .HasForeignKey(uf => uf.ObserverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(uf => uf.Target)
            .WithMany(u => u.Followers)
            .HasForeignKey(uf => uf.TargetId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

using ActivityServise.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityServise.Persistence.Configurations;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable("Activities");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(a => a.Category)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.Venue)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(a => a.Attendees)
            .WithOne(aa => aa.Activity)
            .HasForeignKey(aa => aa.ActivityId);

        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Activity)
            .HasForeignKey(c => c.ActivityId);
    }
}

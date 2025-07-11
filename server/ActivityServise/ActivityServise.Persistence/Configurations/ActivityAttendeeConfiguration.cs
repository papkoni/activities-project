using ActivityServise.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityServise.Persistence.Configurations;

public class ActivityAttendeeConfiguration : IEntityTypeConfiguration<ActivityAttendee>
{
    public void Configure(EntityTypeBuilder<ActivityAttendee> builder)
    {
        builder.ToTable("ActivityAttendees");

        builder.HasKey(aa => new { aa.UserId, aa.ActivityId });

        builder.Property(aa => aa.DateJoined)
            .IsRequired()
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        builder.HasOne(aa => aa.User)
            .WithMany(u => u.Activities)
            .HasForeignKey(aa => aa.UserId);

        builder.HasOne(aa => aa.Activity)
            .WithMany(a => a.Attendees)
            .HasForeignKey(aa => aa.ActivityId);
    }
}

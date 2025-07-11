using ActivityServise.Domain.Entities;
using ActivityServise.Persistence.Abstractions;
using ActivityServise.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ActivityServise.Persistence;

public class ActivityServiceDbContext: DbContext, IActivityServiceDbContext
{
    public ActivityServiceDbContext(DbContextOptions<ActivityServiceDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ActivityAttendee> ActivityAttendees { get; set; }
    public DbSet<UserFollowing> UserFollowing { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ActivityConfiguration());
        modelBuilder.ApplyConfiguration(new ActivityAttendeeConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new PhotoConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserFollowingConfiguration());
    }
} 
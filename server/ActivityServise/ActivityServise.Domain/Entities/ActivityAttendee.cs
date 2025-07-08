namespace ActivityServise.Domain.Entities;

public class ActivityAttendee
{
    public Guid? UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid? ActivityId { get; set; }
    public Activity Activity { get; set; } = null!;
    public bool IsHost { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;
}
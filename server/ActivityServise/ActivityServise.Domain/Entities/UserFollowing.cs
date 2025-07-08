namespace ActivityServise.Domain.Entities;

public class UserFollowing
{
    public required Guid ObserverId { get; set; }
    public User Observer { get; set; } = null!; // Follower
    public required Guid TargetId { get; set; }
    public User Target { get; set; } = null!; // Followee
}
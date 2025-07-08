namespace ActivityServise.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Body { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Nav properties
    public required Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public required Guid ActivityId { get; set; }
    public Activity Activity { get; set; } = null!;
}
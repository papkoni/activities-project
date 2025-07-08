using System.Text.Json.Serialization;

namespace ActivityServise.Domain.Entities;

public class Photo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Url { get; set; }
    public required string PublicId { get; set; }

    // nav properties
    public required string UserId { get; set; }

    [JsonIgnore]
    public User User { get; set; } = null!;
}
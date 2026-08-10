namespace WebApplicationREAlreel.Models;

public class Video
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string FileUrl { get; set; } = string.Empty;
    public string MetadataHash { get; set; } = string.Empty;
    public bool IsUnedited { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  
    
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}

using System.ComponentModel.DataAnnotations;

namespace WebApplicationREAlreel.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    /// <summary>
    /// Navigation property for the videos uploaded by the user.
    /// </summary>
    public ICollection<Video> Videos { get; set; } = new List<Video>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public ICollection<Follow> Following { get; set; } = new List<Follow>(); // кого я фолловлю
    public ICollection<Follow> Followers { get; set; } = new List<Follow>(); // кто фолловит меня

}

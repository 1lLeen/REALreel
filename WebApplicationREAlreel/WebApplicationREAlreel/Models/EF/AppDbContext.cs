using Microsoft.EntityFrameworkCore; 

namespace WebApplicationREAlreel.Models.EF;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Video> Videos => Set<Video>();
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Follow> Follows => Set<Follow>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // --- Follow: two FK on User, need to explicitly specify both relationships ---
        modelBuilder.Entity<Follow>()
            .HasOne(f => f.Follower)
            .WithMany(u => u.Following)
            .HasForeignKey(f => f.FollowerId)
            .OnDelete(DeleteBehavior.Restrict); // not cascade delete, because we don't want to delete all followers if a user is deleted

        modelBuilder.Entity<Follow>()
            .HasOne(f => f.Followed)
            .WithMany(u => u.Followers)
            .HasForeignKey(f => f.FollowedId)
            .OnDelete(DeleteBehavior.Restrict);

        // --- uniquie: no like one video twice ---
        modelBuilder.Entity<Like>()
            .HasIndex(l => new { l.UserId, l.VideoId })
            .IsUnique();

        // --- uniquie: no one person can follow another person twice ---
        modelBuilder.Entity<Follow>()
            .HasIndex(f => new { f.FollowerId, f.FollowedId })
            .IsUnique();

        // --- uniquie  email/username ---
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }
}

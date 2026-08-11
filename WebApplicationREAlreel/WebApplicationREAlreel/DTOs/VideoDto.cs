namespace WebApplicationREAlreel.DTOs;

public record CreateVideoRequest(string FileUrl, string MetadataHash, bool IsUnedited);

public record VideoResponse(
    Guid Id, Guid UserId, string Username,
    string FileUrl, bool IsUnedited,
    int LikesCount, int CommentsCount, DateTime CreatedAt);

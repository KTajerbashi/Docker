namespace RazorAppProfile.Services;

public sealed record ActivityItemDto(string Title, string Description, DateTimeOffset Timestamp, ActivityKind Kind);

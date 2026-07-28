namespace RazorAppProfile.Services;

public sealed class DashboardViewModel
{
    public required ProviderSummaryDto ProviderSummary { get; init; }
    public required ClientSummaryDto ClientSummary { get; init; }
    public required IReadOnlyList<ActivityItemDto> RecentActivity { get; init; }

    public static DashboardViewModel Empty => new()
    {
        ProviderSummary = ProviderSummaryDto.Empty,
        ClientSummary = ClientSummaryDto.Empty,
        RecentActivity = []
    };
}

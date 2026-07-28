namespace RazorAppProfile.Services;

public sealed record ProviderSummaryDto(int TotalActive, int PendingOnboarding, decimal GrowthPercent)
{
    public static ProviderSummaryDto Empty => new(0, 0, 0m);
}

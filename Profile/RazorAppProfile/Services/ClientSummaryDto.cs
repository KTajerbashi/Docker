namespace RazorAppProfile.Services;

public sealed record ClientSummaryDto(int TotalActive, int NewThisMonth, decimal GrowthPercent)
{
    public static ClientSummaryDto Empty => new(0, 0, 0m);
}

namespace RazorAppProfile.Services;

// Application-layer contracts — implement these in Infrastructure against your DbContext.
public interface IProviderMetricsService
{
    Task<ProviderSummaryDto> GetSummaryAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<ActivityItemDto>> GetRecentActivityAsync(int take, CancellationToken cancellationToken);
}

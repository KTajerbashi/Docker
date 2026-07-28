namespace RazorAppProfile.Services;

public sealed class InMemoryClientMetricsService : IClientMetricsService
{
    public Task<ClientSummaryDto> GetSummaryAsync(CancellationToken cancellationToken) =>
        Task.FromResult(new ClientSummaryDto(TotalActive: 342, NewThisMonth: 18, GrowthPercent: 6.8m));
}
using RazorAppProfile.Pages;

namespace RazorAppProfile.Services;
public sealed class InMemoryProviderMetricsService : IProviderMetricsService
{
    public Task<ProviderSummaryDto> GetSummaryAsync(CancellationToken cancellationToken) =>
        Task.FromResult(new ProviderSummaryDto(TotalActive: 128, PendingOnboarding: 7, GrowthPercent: 4.2m));

    public Task<IReadOnlyList<ActivityItemDto>> GetRecentActivityAsync(int take, CancellationToken cancellationToken)
    {
        var items = new List<ActivityItemDto>
        {
            new("New provider onboarded", "Acme Health Group joined the platform", DateTimeOffset.UtcNow.AddHours(-2), ActivityKind.ProviderOnboarded),
            new("Client onboarded", "Contoso Retail signed up", DateTimeOffset.UtcNow.AddHours(-5), ActivityKind.ClientOnboarded),
        };

        return Task.FromResult<IReadOnlyList<ActivityItemDto>>(items.Take(take).ToList());
    }
}

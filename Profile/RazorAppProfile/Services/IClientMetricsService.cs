namespace RazorAppProfile.Services;

public interface IClientMetricsService
{
    Task<ClientSummaryDto> GetSummaryAsync(CancellationToken cancellationToken);
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAppProfile.Services;

namespace RazorAppProfile.Pages;

public sealed class IndexModel : PageModel
{
    private readonly IProviderMetricsService _providerMetrics;
    private readonly IClientMetricsService _clientMetrics;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        IProviderMetricsService providerMetrics,
        IClientMetricsService clientMetrics,
        ILogger<IndexModel> logger)
    {
        _providerMetrics = providerMetrics;
        _clientMetrics = clientMetrics;
        _logger = logger;
    }

    public DashboardViewModel Dashboard { get; private set; } = DashboardViewModel.Empty;

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        // Fan-out independent reads in parallel; each service should own its own
        // DbContext scope (scoped lifetime) to avoid concurrency issues on shared contexts.
        var providerStatsTask = _providerMetrics.GetSummaryAsync(cancellationToken);
        var clientStatsTask = _clientMetrics.GetSummaryAsync(cancellationToken);
        var recentActivityTask = _providerMetrics.GetRecentActivityAsync(take: 6, cancellationToken);

        try
        {
            await Task.WhenAll(providerStatsTask, clientStatsTask, recentActivityTask);
        }
        catch (Exception ex)
        {
            // Task.WhenAll only surfaces the first exception; log and degrade gracefully
            // rather than failing the whole dashboard render.
            _logger.LogError(ex, "Failed to load one or more dashboard widgets.");
        }

        Dashboard = new DashboardViewModel
        {
            ProviderSummary = providerStatsTask.IsCompletedSuccessfully ? providerStatsTask.Result : ProviderSummaryDto.Empty,
            ClientSummary = clientStatsTask.IsCompletedSuccessfully ? clientStatsTask.Result : ClientSummaryDto.Empty,
            RecentActivity = recentActivityTask.IsCompletedSuccessfully ? recentActivityTask.Result : []
        };
    }
}


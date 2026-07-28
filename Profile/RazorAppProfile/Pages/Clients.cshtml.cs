using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAppProfile.Services;

namespace RazorAppProfile.Pages;

public sealed class ClientsModel : PageModel
{
    public IReadOnlyList<ClientRowDto> Clients { get; private set; } = [];

    public void OnGet()
    {
        // TODO: Replace with IClientQueryService.GetAllAsync() once Infrastructure is wired up.
        Clients = GetFakeClients();
    }

    private static IReadOnlyList<ClientRowDto> GetFakeClients() =>
    [
        new(1, "Globex Corporation", "Manufacturing", "Detroit, MI", ClientStatus.Active, ClientTier.Enterprise,
            "Robert Hale", "robert.hale@globex.com", "+1 (313) 555-0110",
            new DateOnly(2021, 6, 1), 128_500m),

        new(2, "Initech Solutions", "Software", "San Jose, CA", ClientStatus.Active, ClientTier.Growth,
            "Amanda Cole", "amanda.cole@initech.com", "+1 (408) 555-0157",
            new DateOnly(2022, 9, 15), 42_000m),

        new(3, "Umbrella Retail Group", "Retail", "Miami, FL", ClientStatus.PendingRenewal, ClientTier.Enterprise,
            "Carlos Vega", "carlos.vega@umbrellaretail.com", "+1 (305) 555-0184",
            new DateOnly(2020, 2, 10), 210_000m),

        new(4, "Wayne Logistics", "Transportation", "Gotham, NJ", ClientStatus.OnHold, ClientTier.Growth,
            "Lucia Ferrer", "lucia.ferrer@waynelogistics.com", "+1 (973) 555-0129",
            new DateOnly(2023, 4, 22), 18_750m),

        new(5, "Stark Analytics", "Technology", "Palo Alto, CA", ClientStatus.Active, ClientTier.Startup,
            "Noah Brenner", "noah.brenner@starkanalytics.com", "+1 (650) 555-0163",
            new DateOnly(2024, 3, 3), 6_200m),
    ];
}


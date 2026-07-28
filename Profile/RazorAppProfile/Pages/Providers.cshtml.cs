using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAppProfile.Services;

namespace RazorAppProfile.Pages;

public sealed class ProvidersModel : PageModel
{
    public IReadOnlyList<ProviderRowDto> Providers { get; private set; } = [];

    public void OnGet()
    {
        // TODO: Replace with IProviderQueryService.GetAllAsync() once Infrastructure is wired up.
        Providers = GetFakeProviders();
    }

    private static IReadOnlyList<ProviderRowDto> GetFakeProviders() =>
    [
        new(1, "Acme Health Group", "Cardiology", "Chicago, IL", ProviderStatus.Active,
            "Dr. Sarah Mitchell", "sarah.mitchell@acmehealth.com", "+1 (312) 555-0142",
            new DateOnly(2021, 3, 12), 42),

        new(2, "Contoso Medical Partners", "Orthopedics", "Austin, TX", ProviderStatus.Active,
            "Dr. James Whitfield", "j.whitfield@contosomed.com", "+1 (512) 555-0198",
            new DateOnly(2022, 7, 4), 28),

        new(3, "Fabrikam Family Clinic", "General Practice", "Denver, CO", ProviderStatus.PendingOnboarding,
            "Dr. Elena Ruiz", "elena.ruiz@fabrikamclinic.com", "+1 (720) 555-0176",
            new DateOnly(2024, 1, 20), 0),

        new(4, "Northwind Diagnostics", "Radiology", "Seattle, WA", ProviderStatus.Suspended,
            "Dr. Michael Chen", "m.chen@northwinddiag.com", "+1 (206) 555-0133",
            new DateOnly(2020, 11, 8), 15),

        new(5, "Adventure Works Pediatrics", "Pediatrics", "Phoenix, AZ", ProviderStatus.Active,
            "Dr. Priya Nair", "priya.nair@advworks-peds.com", "+1 (602) 555-0111",
            new DateOnly(2023, 5, 30), 33),
    ];
}


namespace RazorAppProfile.Services;

public sealed record ProviderRowDto(
    int Id,
    string Name,
    string Specialty,
    string Location,
    ProviderStatus Status,
    string ContactName,
    string Email,
    string Phone,
    DateOnly OnboardedOn,
    int ActiveClientCount);

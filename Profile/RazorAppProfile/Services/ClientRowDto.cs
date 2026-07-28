namespace RazorAppProfile.Services;

public sealed record ClientRowDto(
    int Id,
    string Name,
    string Industry,
    string Location,
    ClientStatus Status,
    ClientTier Tier,
    string ContactName,
    string Email,
    string Phone,
    DateOnly OnboardedOn,
    decimal AnnualContractValue);

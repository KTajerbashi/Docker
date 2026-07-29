namespace RazorAppProfile.Services;

public class ClientInputModel
{
    public string Name { get; set; } = "";

    public string Industry { get; set; } = "";

    public string Location { get; set; } = "";

    public ClientStatus Status { get; set; }

    public ClientTier Tier { get; set; }

    public string ContactName { get; set; } = "";

    public string Email { get; set; } = "";

    public string Phone { get; set; } = "";

    public DateOnly OnboardedOn { get; set; }

    public decimal AnnualContractValue { get; set; }
}
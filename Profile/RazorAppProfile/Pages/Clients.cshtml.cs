using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAppProfile.Services;

namespace RazorAppProfile.Pages;

public sealed class ClientsModel : PageModel
{
    private static readonly List<ClientRowDto> _clients =
    [
        new(1,"Globex Corporation","Manufacturing","Detroit, MI",
            ClientStatus.Active,ClientTier.Enterprise,
            "Robert Hale","robert.hale@globex.com","+1 (313) 555-0110",
            new DateOnly(2021,6,1),128500),

        new(2,"Initech Solutions","Software","San Jose, CA",
            ClientStatus.Active,ClientTier.Growth,
            "Amanda Cole","amanda.cole@initech.com","+1 (408) 555-0157",
            new DateOnly(2022,9,15),42000)
    ];

    public IReadOnlyList<ClientRowDto> Clients => _clients;

    [BindProperty]
    public ClientInputModel Input { get; set; } = new();

    public void OnGet()
    {

    }

    public IActionResult OnPostCreate()
    {
        var id = _clients.Max(x => x.Id) + 1;

        _clients.Add(new ClientRowDto(
            id,
            Input.Name,
            Input.Industry,
            Input.Location,
            Input.Status,
            Input.Tier,
            Input.ContactName,
            Input.Email,
            Input.Phone,
            Input.OnboardedOn,
            Input.AnnualContractValue));

        return RedirectToPage();
    }

    public IActionResult OnPostEdit(int id)
    {
        var client = _clients.FirstOrDefault(x => x.Id == id);

        if (client == null)
            return NotFound();

        _clients.Remove(client);

        _clients.Add(new ClientRowDto(
            id,
            Input.Name,
            Input.Industry,
            Input.Location,
            Input.Status,
            Input.Tier,
            Input.ContactName,
            Input.Email,
            Input.Phone,
            Input.OnboardedOn,
            Input.AnnualContractValue));

        return RedirectToPage();
    }

    public IActionResult OnPostDelete(int id)
    {
        var client = _clients.FirstOrDefault(x => x.Id == id);

        if (client != null)
            _clients.Remove(client);

        return RedirectToPage();
    }
}
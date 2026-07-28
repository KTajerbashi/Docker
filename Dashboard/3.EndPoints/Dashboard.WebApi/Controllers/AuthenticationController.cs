using Dashboard.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.WebApi.Controllers;

public class AuthenticationController : AuthController
{
    [HttpGet("Login")]
    public async Task<IActionResult> Login()
    {
        await Task.CompletedTask;
        return Ok("Login");
    }
    [HttpGet("LoginAs")]
    public async Task<IActionResult> LoginAs()
    {
        await Task.CompletedTask;
        return Ok("LoginAs");
    }
    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        await Task.CompletedTask;
        return Ok("Logout");
    }
}

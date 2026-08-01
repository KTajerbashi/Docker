using Dockerize.WebApi.Controllers.Common;
using Dockerize.WebApi.Models.Security.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Dockerize.WebApi.Controllers.Security;

public class UserCotroller : AuthCotroller
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.CompletedTask;
        return Ok(Enumerable.Empty<UserDTO>().ToList());
    }
    [HttpGet("{entityId}")]
    public async Task<IActionResult> Get(int entityId)
    {
        await Task.CompletedTask;
        return Ok(entityId);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDTO parameter)
    {
        await Task.CompletedTask;
        return Ok(parameter);
    }

    [HttpPut("{entityId}")]
    public async Task<IActionResult> Update(int entityId, UserDTO parameter)
    {
        await Task.CompletedTask;
        return Ok(parameter);
    }

    [HttpDelete("{entityId}")]
    public async Task<IActionResult> Delete(int entityId)
    {
        await Task.CompletedTask;
        return Ok(true);
    }
}

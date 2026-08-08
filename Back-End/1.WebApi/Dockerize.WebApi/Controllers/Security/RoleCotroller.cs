namespace Dockerize.WebApi.Controllers.Security;

public class RoleCotroller : AuthCotroller
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.CompletedTask;
        return Ok(Enumerable.Empty<RoleDTO>().ToList());
    }
    [HttpGet("{entityId}")]
    public async Task<IActionResult> Get(int entityId)
    {
        await Task.CompletedTask;
        return Ok(entityId);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RoleDTO parameter)
    {
        await Task.CompletedTask;
        return Ok(parameter);
    }

    [HttpPut("{entityId}")]
    public async Task<IActionResult> Update(int entityId, RoleDTO parameter)
    {
        await Task.CompletedTask;
        return Ok(new
        {
            entityId,
            parameter,
        });
    }

    [HttpDelete("{entityId}")]
    public async Task<IActionResult> Delete(int entityId)
    {
        await Task.CompletedTask;
        return Ok(new
        {
            entityId
        });
    }
}

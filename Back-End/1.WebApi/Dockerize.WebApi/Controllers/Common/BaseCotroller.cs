using Dockerize.WebApi.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Dockerize.WebApi.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseCotroller : Controller
{
    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
    {
        return base.Ok(ApiResult.Success(value));
    }

    public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object? error)
    {
        return base.BadRequest(ApiResult.Faild(error));
    }
}

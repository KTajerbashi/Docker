using Microsoft.AspNetCore.Authorization;

namespace Dashboard.WebApi.Controllers.Base;

[Authorize]
public abstract class AuthController : BaseController
{
}

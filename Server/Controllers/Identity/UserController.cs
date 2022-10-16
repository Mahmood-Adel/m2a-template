using Application.Interfaces.Services.Identity;
using Application.Requests.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Server.Resources.Shared;

namespace Server.Controllers.Identity;

[Route("api/identity/user")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public UserController(IUserService userService, IStringLocalizer<SharedResource> localizer)
    {
        _userService = userService;
        _localizer = localizer;
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromBody]RegisterRequest request)
    {
        return Ok(await _userService.RegisterAsync(request));
    }
}
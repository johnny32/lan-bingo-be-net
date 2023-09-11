using LANBingoBE.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace LANBingoBE.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{user}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    public ActionResult IsUserAllowed([FromRoute] string user)
    {
        if (_userService.IsUserAllowed(user))
            return NoContent();

        return Unauthorized();
    }
}

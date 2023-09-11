using System.Net;
using LANBingoBE.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace LANBingoBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly IUserService _userService;

        public CardsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(201)]
        public ActionResult CreateBingo([FromRoute] int userId)
        {
            _userService.CreateUserBingo(userId);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
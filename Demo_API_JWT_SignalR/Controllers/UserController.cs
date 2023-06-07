using Demo_API_JWT_SignalR.Hubs;
using Demo_API_JWT_SignalR.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API_JWT_SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TokenManager _token;
        private readonly UserService _userService;
        private readonly ChatHub _hub;

        public UserController(TokenManager token, UserService userService, ChatHub hub)
        {
            _token = token;
            _userService = userService;
            _hub = hub;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_token.GenerateToken(_userService.GetById(id)));
        }

        [Authorize("adminPolicy")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage()
        {
            await _hub.SendMessage("System", "test");
            return Ok();
        }
    }
}

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

        public UserController(TokenManager token, UserService userService)
        {
            _token = token;
            _userService = userService;
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
    }
}

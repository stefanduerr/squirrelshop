using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using squirrels.Models;
using squirrels.Services;

namespace squirrels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // Route: GET /api/users/
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<User>> AddUser([FromBody]User user)
        {
            var newUser = await _userService.AddUser(user);
            return Ok(newUser);
        }
    }
}

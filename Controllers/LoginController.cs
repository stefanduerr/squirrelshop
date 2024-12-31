using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using squirrels.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace squirrels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            if (login.Username == "test" && login.Password == "password")
            {
                var claims = new[]
                {
            new Claim(ClaimTypes.Name, login.Username),
            new Claim("Role", "Admin")
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key-123-8888777766665555"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "your-issuer",
                    audience: "your-audience",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized();
        }

        [Authorize]
        [HttpGet("isauthorized")]
        public IActionResult IsAuthorized()
        {
            return Ok("You are authorized to view this message!");
        }
    }
}

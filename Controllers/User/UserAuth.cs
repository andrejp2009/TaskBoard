using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TaskBoard.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Swashbuckle.AspNetCore.Annotations;

namespace TaskBoard.Controllers.User
{
    [Route("api/user")]
    [ApiController]
    public class UserAuthController : ControllerBase 
    {
        private readonly SignInManager<Models.User> _signInManager;

        public UserAuthController(SignInManager<Models.User> signInManager)
        {
            _signInManager = signInManager;
        }
     
        [HttpPost("login")]
        [SwaggerOperation(Summary = "User login", Description = "Allows a user to log in with their username and password.", Tags = new[] { "User" })]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(loginRequest.UserName, loginRequest.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Invalid login attempt." });
            }

            return Ok(new { message = "Login successful" });
        }
    }

    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

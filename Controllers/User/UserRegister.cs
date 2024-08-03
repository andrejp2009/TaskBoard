using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using TaskBoard.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace TaskBoard.Controllers.User
{
    [Route("api/user")]
    [ApiController]
    public class UserRegisterController : ControllerBase 
    {
        private readonly UserManager<Models.User> _userManager;

        public UserRegisterController(UserManager<Models.User> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpPost("register")]
                [SwaggerOperation(Summary = "User registration", Description = "Allows a new user to register by providing their username, email, and password.", Tags = new[] { "User" })]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Models.User
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.Email
            };

            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { message = "User registered successfully" });
        }
    }

        public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        [MinLength(1)]

        public string Email { get; set; }

        [Required]
        [MinLength(1)]

        public string UserName { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Passwords must be at least 6 characters.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\W).+$", ErrorMessage = "Passwords must have at least one non alphanumeric character and one uppercase ('A'-'Z').")]
        public string Password { get; set; }
    }
}



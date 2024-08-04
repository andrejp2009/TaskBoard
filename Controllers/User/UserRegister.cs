using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TaskBoard.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace TaskBoard.Controllers.User
{
    [Route("api/user")]
    [ApiController]
    public class UserRegisterController : ControllerBase 
    {
        private readonly UserManager<Models.User> _userManager;
        private readonly ILogger<UserRegisterController> _logger;

        public UserRegisterController(UserManager<Models.User> userManager, ILogger<UserRegisterController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Model state is invalid: {ModelState}", ModelState);
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
                _logger.LogError("User creation failed: {Errors}", result.Errors);
                return BadRequest(new { errors = result.Errors });
            }

            _logger.LogInformation("User registered successfully: {UserName}", user.UserName);
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

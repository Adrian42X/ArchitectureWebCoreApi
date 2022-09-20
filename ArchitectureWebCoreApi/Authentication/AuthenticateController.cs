using ArchitectureWebCoreApi.Helpers;
using ArchitectureWebCoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectDatabase.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ArchitectureWebCoreApi.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public AuthenticateController(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            ILogger logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var autheClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                var token = TokenHelper.GetToken(autheClaims, _configuration);
                return Ok(new
                {
                    token = token,
                    expiration = token.ValidTo,
                    message = "Login Succesful"
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<ActionResult> Register(NewUserModel newUserModel)
        {
            var dbUser = await _userManager.FindByNameAsync(newUserModel.UserName);
            if (dbUser != null)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        Status = "error",
                        Message = "This username is already used"
                    }
                    );
            }

            var applicationUser = new ApplicationUser()
            {
                UserName = newUserModel.UserName,
                Email = newUserModel.EMail,
                FirstName = newUserModel.FirstName,
                LastName = newUserModel.LastName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var response = await _userManager.CreateAsync(applicationUser);
            if (response.Succeeded)
            {
                return Ok(new
                {
                    Status = "error",
                    Message = "Can't create user"
                });
            }
            return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        Status = "error",
                        Message = "Can't create user"
                    }
                    );
        }
    }
}

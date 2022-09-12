using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ProjectDatabase.Models;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace ArchitectureWebCoreApi.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            UserManager<ApplicationUser> userManager): base(options,logger,encoder,clock)
        {
            _userManager = userManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var authHeader = Request.Headers.Authorization[0];
                var token = authHeader.Substring("Basic".Length).Trim();
                var credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var credential = credentialString.Split(':');

                var user = await _userManager.FindByNameAsync(credential[0]);
                if (user == null)
                {
                    return AuthenticateResult.Fail("Invalid user name");
                }

                bool isPasswordOk = await _userManager.CheckPasswordAsync(user, credential[0]);
                if (!isPasswordOk)
                {
                    return AuthenticateResult.Fail("Invalid Password");
                }

                var claims = new[] { new Claim("name", user.UserName), new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };
                var identity = new ClaimsIdentity(claims, "Basic");
                var claimsPrincipal = new ClaimsPrincipal(identity);

                return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
            }
            catch(Exception ex)
            {
                return AuthenticateResult.Fail("Could not read auth header");
            }
        }
    }
}

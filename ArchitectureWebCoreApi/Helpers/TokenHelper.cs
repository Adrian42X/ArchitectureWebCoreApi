using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArchitectureWebCoreApi.Helpers
{
    public static class TokenHelper
    {
        public static JwtSecurityToken GetToken(List<Claim> claims, IConfiguration config)
        {
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecurityKey"]));

        return new JwtSecurityToken(
                issuer: config["JWT:ValidIssuer"],
                audience: config["JWT:ValidAudience"],
                claims: claims,
                signingCredentials:new SigningCredentials(signInKey, SecurityAlgorithms.Sha256)
                );

        }
    }
}

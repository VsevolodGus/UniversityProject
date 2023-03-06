using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UP.Domain;

namespace UP.Web.Helpers;

public class AuthenticationHelper
{
    private ClaimsIdentity _claimsIdentity;
    private readonly HttpContext _httpContext;

    public async Task SingInAsync(User user)
    {
        var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.Login) };
        var jwt = new JwtSecurityToken(
                issuer: "MyAuthServer",
                audience: "MyAuthClient",
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    }
}

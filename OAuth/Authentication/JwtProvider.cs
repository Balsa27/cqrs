using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OAuth.Properties;

namespace OAuth.Authentication;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string Generate(User user)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, user.Name.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email.ToString()),
        };

        var signingCredentials = 
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.Secret)),
                SecurityAlgorithms.HmacSha256);
            
        var token = new JwtSecurityToken(
            _options.Issuer, _options.Audience, 
            claims, null,
            DateTime.UtcNow.AddHours(1), null);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue; 
    }
}
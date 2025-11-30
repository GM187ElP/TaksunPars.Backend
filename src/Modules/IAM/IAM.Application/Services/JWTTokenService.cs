using IAM.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace IAM.Application.Services;


public class JWTTokenService : IJWTTokenService
{
    private readonly IConfiguration _configuration;
    private readonly string _jwtSecret;

    public JWTTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        _jwtSecret = _configuration["Jwt:Secret"]; // Fetch secret from config
    }

    public string GenerateToken(Guid userId, string role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Role, role),
            // Add any other claims you need
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1), // Token expiration
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token); // Return the token as a string
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));

        var handler = new JwtSecurityTokenHandler();
        try
        {
            var principal = handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = key
            }, out SecurityToken validatedToken);

            return principal;
        }
        catch
        {
            return null; // Invalid token or expired token
        }
    }
}

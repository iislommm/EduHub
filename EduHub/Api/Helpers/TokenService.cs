using Application.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Helpers;

public class TokenService
{
    private readonly IConfiguration _config;

    public TokenService(IConfiguration configuration)
    {
        _config = configuration.GetSection("Jwt");
    }

    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }

    public string GenerateTokent(VideoGetDto edu)
    {
        var identityClaims = new Claim[]
        {
            new Claim("VideoId",edu.VideoId.ToString()),
            new Claim("Name",edu.Name.ToString()),
            new Claim("MB",edu.MB.ToString()),
            new Claim("Description",edu.Description.ToString()),
            new Claim("Views",edu.Views.ToString()),
            new Claim("Comments",edu.Comments.ToString()),
            new Claim("VideoUrl",edu.VideoUrl.ToString()),
            new Claim("Category",edu.Category.ToString()),
            new Claim("Instructor",edu.Instructor.ToString()),
            //new Claim(ClaimTypes.Category,user.Category.ToString()),
            //new Claim(ClaimTypes.Instructor,user.Instructor.ToString())
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]!));

        SigningCredentials keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        int expiresHours = int.Parse(_config["LifeTime"]);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _config["Issuer"],
            audience: _config["Audience"],
            claims: identityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = _config["Issuer"],
            ValidateAudience = true,
            ValidAudience = _config["Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]!))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
    }
}

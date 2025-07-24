using Application.Dtos;
using System.Security.Claims;

namespace Application.Helpers;

public interface ITokenService
{
    public string GenerateTokent(VideoGetDto edu);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}

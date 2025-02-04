using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Web_UI.Helper;

public static class JwtHelper
{
    /// <summary>
    /// JWT token içinden kullanıcının rollerini döndürür.
    /// </summary>
    public static List<string> GetRoles(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        return jwtToken.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
    }

    /// <summary>
    /// JWT token içinden kullanıcı adını döndürür.
    /// </summary>
    public static string GetUsername(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        return jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
    }
}

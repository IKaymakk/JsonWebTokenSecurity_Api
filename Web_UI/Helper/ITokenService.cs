using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Web_UI.Helper;

public interface ITokenService
{
    string GetToken();
}

public class TokenService : ITokenService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TokenService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetToken()
    {
        // Burada session veya cookie'den token'ı alabiliriz
        return _httpContextAccessor.HttpContext.Session.GetString("AccessToken");
    }
}

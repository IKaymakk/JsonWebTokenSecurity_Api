using JsonWebTokenSecurity.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JsonWebTokenSecurity.Security
{
    public class TokenGenerator
    {
        public static TokenResponseDto GenerateToken(UserDataDto entity)
        {
            if (JwtDefaults.Key == null) throw new Exception("Key Null Olamaz");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtDefaults.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, entity.Username!),
                new Claim(ClaimTypes.Role, entity.Role)
            };

            var expireDate = DateTime.UtcNow.AddHours(JwtDefaults.ExpireTime);

            var token = new JwtSecurityToken(
               issuer: JwtDefaults.Issuer,
               audience: JwtDefaults.Audience,
               claims: claim,
               expires: expireDate,
               signingCredentials: credentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(handler.WriteToken(token), expireDate);

        }
    }
}

using JsonWebTokenSecurity.Models;
using JsonWebTokenSecurity.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JsonWebTokenSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authorization : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] Entity entity)
        {
            var user = CheckUser(entity);
            if (user == null) return NotFound("Kullanıcı Bulunamadı");

            var token = GenerateToken(user);
            return Ok(token);

        }

        private string GenerateToken(Entity entity)
        {
            if (JwtDefaults.Key == null) throw new Exception("Key Null Olamaz");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtDefaults.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, entity.KullaniciAdi!),
                new Claim(ClaimTypes.Role, entity.Rol!)
            };

            var expireDate = DateTime.UtcNow.AddHours(JwtDefaults.ExpireTime);

            var token = new JwtSecurityToken(
               issuer: JwtDefaults.Issuer,
               audience: JwtDefaults.Audience,
               claims: claim,
               expires: expireDate,
               signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private Entity? CheckUser(Entity entity)
        {
            return Users
                .userList
                .FirstOrDefault(x =>
                    x.KullaniciAdi?.ToLower() == entity.KullaniciAdi
                    && x.Sifre == entity.Sifre
                );
        }
    }
}

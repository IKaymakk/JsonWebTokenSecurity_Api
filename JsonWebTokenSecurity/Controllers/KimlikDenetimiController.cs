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
    public class KimlikDenetimiController : ControllerBase
    {
        [HttpPost("Giris")]
        public IActionResult Giris([FromBody] Entity apiKullanicisiBilgileri)
        {
            var apiKullanicisi = KimlikDenetimiYap(apiKullanicisiBilgileri);
            if (apiKullanicisi == null) return NotFound("Kullanıcı Bulunamadı");

            var token = TokenOlustur(apiKullanicisi);
            return Ok(token);

        }

        private string TokenOlustur(Entity apiKullanicisi)
        {
            if (JwtDefaults.Key == null) throw new Exception("Key Null Olamaz");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtDefaults.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimDizisi = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, apiKullanicisi.KullaniciAdi!),
                new Claim(ClaimTypes.Role, apiKullanicisi.Rol!)
            };

            var expireDate = DateTime.UtcNow.AddHours(JwtDefaults.ExpireTime);

            var token = new JwtSecurityToken(
               issuer : JwtDefaults.Issuer,
               audience : JwtDefaults.Audience,
               claims : claimDizisi,
                expires: expireDate,
                signingCredentials:credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private Entity? KimlikDenetimiYap(Entity apiKullanicisiBilgileri)
        {
            return Users
                .Kullanicilar
                .FirstOrDefault(x =>
                    x.KullaniciAdi?.ToLower() == apiKullanicisiBilgileri.KullaniciAdi
                    && x.Sifre == apiKullanicisiBilgileri.Sifre
                );
        }
    }
}

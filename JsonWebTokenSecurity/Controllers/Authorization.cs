using JsonWebTokenSecurity._BusinessLayer.Abstract;
using JsonWebTokenSecurity._DataAccessLayer.Abstract;
using JsonWebTokenSecurity._DataAccessLayer.Concrete;
using JsonWebTokenSecurity._EntityLayer.Concrete;
using JsonWebTokenSecurity.Models;
using JsonWebTokenSecurity.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IAppUserService _repository;
        private readonly IAppRoleRepository _apprepository;

        public Authorization(IAppUserService repository, IAppRoleRepository apprepository)
        {
            _repository = repository;
            _apprepository = apprepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] CheckUserDto dto)
        {
            var user = await CheckUser(dto);
            if (user == null || user.IsExist == false) return NotFound("Kullanıcı Bulunamadı");

            var token = GenerateToken(user);
            return Ok(token);

        }

        private async Task<UserDataDto> CheckUser(CheckUserDto dto)
        {
            UserDataDto responseDto = new();
            var user = await _repository.GetAsync(x =>
                    x.Username == dto.Username &&
                        x.Password == dto.Password
            );
            if (user == null)
            {
                responseDto.IsExist = false;
                throw new Exception("Kullanıcı Kaydı Bulunamadı");
            }
            else
            {
                responseDto.IsExist = true;
                responseDto.Username = user.Username;
                responseDto.Role = (await _apprepository.GetFilterAsync(x => x.AppRoleId == user.AppRoleId)).Role;
                responseDto.AppUserId = user.AppUserId;
            }
            return responseDto;
        }

        private TokenResponseDto GenerateToken(UserDataDto entity)
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
            return new TokenResponseDto(handler.WriteToken(token),expireDate);

        }

    }
}

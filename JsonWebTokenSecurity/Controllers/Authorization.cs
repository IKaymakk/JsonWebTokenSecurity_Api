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

            var user = await _repository.CheckUser(dto);
            if (user == null || user.IsExist == false) return NotFound("Hatalı Kullanıcı Adı Veya Şifre");

            var token = TokenGenerator.GenerateToken(user);
            return Ok(token);

        }

    }
}

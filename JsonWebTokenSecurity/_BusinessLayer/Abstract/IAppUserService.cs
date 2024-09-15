using JsonWebTokenSecurity._EntityLayer.Concrete;
using JsonWebTokenSecurity.Models;

namespace JsonWebTokenSecurity._BusinessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<UserDataDto> CheckUser(CheckUserDto checkUserDto);
    }
}

using JsonWebTokenSecurity._EntityLayer.Concrete;
using JsonWebTokenSecurity.Models.AppUserManagerDtos;

namespace JsonWebTokenSecurity._DataAccessLayer.Abstract
{
    public interface IAppUserRepository:IGenericRepository<AppUser>
    {
        Task<string> GetAppUserRoleAsync(int id);
    }
}

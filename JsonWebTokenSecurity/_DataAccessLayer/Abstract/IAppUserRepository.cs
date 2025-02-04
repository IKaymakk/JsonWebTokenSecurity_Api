using JsonWebTokenSecurity._EntityLayer.Concrete;

namespace JsonWebTokenSecurity._DataAccessLayer.Abstract
{
    public interface IAppUserRepository:IGenericRepository<AppUser>
    {
        Task<string> GetAppUserRoleAsync(int id);
    }
}

using JsonWebTokenSecurity._DataAccessLayer.Abstract;
using JsonWebTokenSecurity._EntityLayer.Concrete;

namespace JsonWebTokenSecurity._DataAccessLayer.Concrete
{
    public class AppUserRepository:GenericRepository<AppUser>,IAppUserRepository
    {
    }
}

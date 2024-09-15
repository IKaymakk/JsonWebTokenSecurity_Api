using JsonWebTokenSecurity._DataAccessLayer.Abstract;
using JsonWebTokenSecurity._DataAccessLayer.Context;
using JsonWebTokenSecurity._EntityLayer.Concrete;
using JsonWebTokenSecurity.Models.AppUserManagerDtos;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace JsonWebTokenSecurity._DataAccessLayer.Concrete
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private readonly SQLContext _sqlContext;

        public AppUserRepository(SQLContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<string> GetAppUserRoleAsync(int id)
        {
            var userrole = await _sqlContext.AppUsers
               .Include(x => x.AppRole)
               .Where(x => x.AppUserId == id)
               .Select(x => x.AppRole.Role)
               .FirstOrDefaultAsync();

            if (userrole == null)
            {
                // Hata durumunda uygun bir işlem yapılabilir (örn. özel bir exception fırlatılabilir)
                throw new KeyNotFoundException("Rol bulunamadı.");
            }

            return userrole;
        }

    }
}

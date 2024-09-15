using Microsoft.EntityFrameworkCore;
using JsonWebTokenSecurity._EntityLayer.Concrete;

namespace JsonWebTokenSecurity._DataAccessLayer.Context
{
    public class SQLContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=KAYMAK\\SQLEXPRESS;database=JWTSecurity; integrated security=true; TrustServerCertificate=True;");
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
    }
}

namespace JsonWebTokenSecurity.Models
{
    public class Users
    {
        public static List<Entity> userList = new()
        {
            new Entity { Id =1,KullaniciAdi="ibrahim",Sifre="ibo123",Rol="Admin"},
            new Entity { Id =2,KullaniciAdi="deneme",Sifre="deneme",Rol="Üye"}
        };
    }
}

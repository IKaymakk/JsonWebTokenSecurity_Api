namespace JsonWebTokenSecurity._EntityLayer.Concrete
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public AppRole AppRole { get; set; }
        public int AppRoleId { get; set; }
    }
}

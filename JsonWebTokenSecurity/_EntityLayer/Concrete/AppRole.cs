namespace Web_UI._EntityLayer.Concrete
{
    public class AppRole
    {
        public int AppRoleId { get; set; }
        public string Role { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}

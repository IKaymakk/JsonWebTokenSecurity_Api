namespace JsonWebTokenSecurity.Models
{
    public class UserDataDto
    {
        public int AppUserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string? Message{ get; set; }
        public bool IsExist { get; set; }
    }
}

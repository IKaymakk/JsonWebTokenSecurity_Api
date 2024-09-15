namespace JsonWebTokenSecurity.Models
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }

        public TokenResponseDto(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }
    }
}

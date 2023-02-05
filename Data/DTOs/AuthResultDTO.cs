namespace Data.DTOs
{
    public class AuthResultDTO
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}

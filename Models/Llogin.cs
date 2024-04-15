namespace apiTest.Models
{
    public class Llogin
    {
        public string username { get; set; } = string.Empty;
        public string accessToken { get; set; } = string.Empty;
        public DateTime expiresAt { get; set; }
    }
}

namespace AuthenticationService.DAL.Entitys
{
    public class RefreshToken
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTime TokenCreated { get; set; }

    }
}

namespace AuthenticationService.DAL.Entitys
{
    public class AccessToken
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTime TokenCreated { get; set; }
    }
}

namespace AuthenticationService.Entitys
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        //[JsonIgnore]
        public string Password { get; set; }
    }
}

namespace Identity.Models
{
    public enum UserStatus { User, Admin }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}

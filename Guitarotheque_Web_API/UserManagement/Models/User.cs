namespace Guitarotheque_Web_API.UserManagement.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public bool IsAdmin { get; set; }
    }
}

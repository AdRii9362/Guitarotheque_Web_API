using System.ComponentModel.DataAnnotations;

namespace Guitarotheque_Web_API.UserManagement.Models
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

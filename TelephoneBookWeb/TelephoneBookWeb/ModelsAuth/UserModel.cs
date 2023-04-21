using System.ComponentModel.DataAnnotations;

namespace TelephoneBookWeb.ModelsAuth
{
    public class UserModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}

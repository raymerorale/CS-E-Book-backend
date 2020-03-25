using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class AuthUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
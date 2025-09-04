using System.ComponentModel.DataAnnotations;

namespace migApp.Shared.Dtos.Auth
{
    public class LoginDto
    {
        [Required, MinLength(1)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Captcha { get; set; }
    }
}

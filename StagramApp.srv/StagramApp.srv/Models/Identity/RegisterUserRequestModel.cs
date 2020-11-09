using StagramApp.srv.Common;
using System.ComponentModel.DataAnnotations;

namespace StagramApp.srv.Models.Identity
{
    public class RegisterUserRequestModel
    {
        [Required]
        [MinLength(UserDataRequirements.UsernameMinLegth)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(UserDataRequirements.PasswordMinLength)]
        public string Password { get; set; }
    }
}
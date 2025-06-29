using System.ComponentModel.DataAnnotations;

namespace Showsphere.Models
{
    public class User
    {
        

        [Required]
        public required string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password
        {
            get; set;
        }
        

    }
    public class Signup
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        [MinLength(50)]
        public required string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password do not match")]
        public required string RetypePassword { get; set; }

        public bool AgreeToTerms { get; set; }
    }
}

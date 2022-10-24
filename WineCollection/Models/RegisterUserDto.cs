using System.ComponentModel.DataAnnotations;

namespace WineCollection.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string ConfirmPassword { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}

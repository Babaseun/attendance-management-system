using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class SignUpModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Max is 30 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Max is 30 characters")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Photo { get; set; } = "avatar.jpg";

    }
}

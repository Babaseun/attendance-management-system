using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class CheckInDto
    {
        [Required]
        public bool CheckedIn { get; set; }


    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class AttendanceModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Only 30 characters are allowed")]
        public string Reason { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Only 30 characters are allowed")]
        public string Comment { get; set; } = "pending.....";
        public bool CheckIn { get; set; } = false;
        public bool CheckOut { get; set; } = false;
        public DateTime CheckedInAt { get; set; }
        public DateTime CheckedOutAt { get; set; }
        [Required]
        public string OwnerId { get; set; }

    }
}

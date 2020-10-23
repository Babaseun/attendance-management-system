using Microsoft.AspNetCore.Identity;
using System;

namespace Api.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Photo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;



    }
}

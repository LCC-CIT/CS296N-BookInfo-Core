using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class Reader: IdentityUser
    {
        public int ReaderId { get; set; }

        [Required]
       public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}

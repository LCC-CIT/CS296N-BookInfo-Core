using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class IdentityReader : IdentityUser
    {
        [Required]
       public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}

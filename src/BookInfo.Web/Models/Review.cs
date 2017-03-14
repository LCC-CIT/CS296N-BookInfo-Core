using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "You must enter at least 10 characters")]
        [Display(Name = "Review Text")]
        public string Body { get; set; }

        [Required]
        [Range(1.0, 5.0, ErrorMessage = "Please enter a number from 1 to 5")]
        [Display(Name = "Book Rating")]
        public int Rating { get; set; }

        public Reader BookReader { get; set; }
    }
}

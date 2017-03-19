using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "You must enter at least 10 characters")]
        public string Body { get; set; }

        [Required]
        [Range(1.0, 5.0, ErrorMessage = "Please enter a number from 1 to 5")]
        public int Rating { get; set; }

        [Required]
        public Reader BookReader { get; set; }
    }
}

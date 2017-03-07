using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Required(ErrorMessage = "Please enter some text")]
        [MinLength(5, ErrorMessage = "You must enter at least 5 characters")]
        [Display(Name = "Review Text")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Please enter a number")]
        [Display(Name = "Book Rating")]
        public int Rating { get; set; }
        // TODO Add a member property
    }
}

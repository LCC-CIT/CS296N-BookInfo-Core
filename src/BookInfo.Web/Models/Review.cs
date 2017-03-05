using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Required(ErrorMessage = "Please enter some text")]
        [Display(Name = "Review Text")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Please enter a number from 1 to 5")]
        [Display(Name = "Book Rating")]
        public int Rating { get; set; }
        // TODO Add a member property
    }
}

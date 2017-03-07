using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class ReviewViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        /*
        [Required]
        public string ReviewText { get; set; }

        [Range(1.0, 5.0, ErrorMessage = "Please enter a number from 1 to 5")]
        public int Rating { get; set; }
        */
       public Review BookReview {get; set;}
    }
}

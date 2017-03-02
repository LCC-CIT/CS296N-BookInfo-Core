using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Display(Name = "Review Text")]
        public string Body { get; set; }

        [Display(Name = "Book Rating")]
        public int Rating { get; set; }
        // TODO Add a member property
    }
}

using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class ReviewViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Body {get; set;}
        public int Rating { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Models
{
    public class ReviewViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public Review BookReview {get; set;}
    }
}

﻿using System;
using System.Collections.Generic;

namespace BookInfo.Models
{
    public class Book
    {
        public int BookId { get; set; }
        private List<Author> authors = new List<Author>();
        public string Title { get; set; }
        public List<Author> Authors { get { return authors; } }
        public DateTime Date { get; set; }
        public string Genre { get; set; }
        private List<Review> reviews = new List<Review>();
        public List<Review> BookReviews { get { return reviews; } }
    }
}

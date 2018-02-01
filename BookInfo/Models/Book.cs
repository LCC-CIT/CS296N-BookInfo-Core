﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Models
{
    public class Book
    {
        private List<Author> authors = new List<Author>();
        public string Title { get; set; }
        public List<Author> Authors { get { return authors; } }
        public DateTime Date { get; set; }
    }
}

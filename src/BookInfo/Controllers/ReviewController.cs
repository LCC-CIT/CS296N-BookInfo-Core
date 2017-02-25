using BookInfo.Models;
using BookInfo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Controllers
{
    public class ReviewController : Controller
    {
        private IBookRepository bookRepo;

        public ReviewController(IBookRepository repo)
        {
            bookRepo = repo;
        }

        [HttpGet]
        public ViewResult ReviewForm(string title, int id)
        {
            var reviewVm = new ReviewViewModel();
            reviewVm.BookId = id;
            reviewVm.Title = title;
            reviewVm.BookReview = new Models.Review();
            // For testing
            //reviewVm.BookReview.Body = "Testing the body";
            //reviewVm.BookReview.Rating = 5;

            return View(reviewVm);
        }

        [HttpPost]
        public IActionResult ReviewForm(ReviewViewModel reviewVm)
        {
            // Get the book object from the database
            Book book = (from b in bookRepo.GetAllBooks()
                         where b.BookId == reviewVm.BookId
                         select b).FirstOrDefault<Book>();
            book.BookReviews.Add(reviewVm.BookReview);
            bookRepo.Update(book);
            return RedirectToAction("Index", "Book");
        }
       
    }
}

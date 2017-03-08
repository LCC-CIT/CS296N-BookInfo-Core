using BookInfo.Models;
using BookInfo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public ActionResult ReviewForm(ReviewViewModel reviewVm)
        {
            string body = reviewVm.BookReview.Body;
            if (string.IsNullOrEmpty(body) || body.IndexOf(" ", System.StringComparison.Ordinal) < 1)
            {
                //string prop = nameof(reviewVm.BookReview.Rating); // Doesn't get the object.property name
                string prop = "BookReview.Body";
                ModelState.AddModelError(prop, "Please enter at least two words");
            }
            

            if (ModelState.IsValid)
            {
                // Get the full model object for the book being reviewed
                Book book = (from b in bookRepo.GetAllBooks()
                             where b.BookId == reviewVm.BookId
                             select b).FirstOrDefault<Book>();

                // add the review and save the book object to the db
                book.BookReviews.Add(new Review { Body = reviewVm.BookReview.Body, Rating = reviewVm.BookReview.Rating });
                bookRepo.Update(book);

               return RedirectToAction("Index", "Book");
            }
            else
            {
                return View(reviewVm);
            }
        }
       
    }
}



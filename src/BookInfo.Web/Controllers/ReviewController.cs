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
            //reviewVm.BookReview = new Models.Review();
            // For testing
            //reviewVm.BookReview.Body = "Testing the body";
            //reviewVm.BookReview.Rating = 5;

            return View(reviewVm);
        }


        [HttpPost]
        public ActionResult ReviewForm(ReviewViewModel reviewVm)
        {
            if (reviewVm.Rating < 1 || reviewVm.Rating > 5)
            {
                string prop = nameof(reviewVm.Rating);
                //string prop = "BookReview.Rating";
                ModelState.AddModelError(prop, "Server says: please enter a number from 1 to 5");
            }

            if (ModelState.IsValid)
            {
                // Get the full model object for the book being reviewed
                Book book = (from b in bookRepo.GetAllBooks()
                             where b.BookId == reviewVm.BookId
                             select b).FirstOrDefault<Book>();

                // add the review and save the book object to the db
                book.BookReviews.Add(new Review { Body = reviewVm.ReviewText, Rating = reviewVm.Rating });
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



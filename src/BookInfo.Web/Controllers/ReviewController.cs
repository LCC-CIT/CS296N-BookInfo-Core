using BookInfo.Models;
using BookInfo.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Controllers
{
    public class ReviewController : Controller
    {
        private IBookRepository bookRepo;
        private UserManager<Reader> userManager;

        public ReviewController(UserManager<Reader> userMgr, IBookRepository repo)
        {
            bookRepo = repo;
            userManager = userMgr;
        }

        [HttpGet]
        public ViewResult ReviewForm(string title, int id)
        {
            var reviewVm = new ReviewViewModel();
            reviewVm.BookId = id;
            reviewVm.Title = title;

            return View(reviewVm);
        }


        [HttpPost]
        public async Task<IActionResult> ReviewForm(ReviewViewModel reviewVm)
        {
            string body = reviewVm.Body;
            if (string.IsNullOrEmpty(body) || body.IndexOf(" ", System.StringComparison.Ordinal) < 1)
            {
                string prop = nameof(reviewVm.Body);
                ModelState.AddModelError(prop, "Please enter at least two words");
            }
            

            if (ModelState.IsValid)
            {
                // Get the full model object for the book being reviewed
                Book book = (from b in bookRepo.GetAllBooks()
                             where b.BookId == reviewVm.BookId
                             select b).FirstOrDefault<Book>();

                // add the review and save the book object to the db
                Review review = new Review { Body = reviewVm.Body, Rating = reviewVm.Rating };
                string name = HttpContext.User.Identity.Name;
                review.BookReader = await userManager.FindByNameAsync(name);

                book.BookReviews.Add(review);
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



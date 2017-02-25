using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Repositories;
using BookInfo.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
// TODO Add a Review controller

namespace BookInfo.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepo;

        public BookController(IBookRepository repo)
        {
            bookRepo = repo;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            ViewBag.Genre = "All";
            return View(bookRepo.GetAllBooks().ToList());
        }

        public ViewResult BooksByGenre(string genre)
        {
            ViewBag.Genre = genre;
            return View("Index", bookRepo.GetAllBooks().
                Where(b => b.Genre == genre).ToList());
        }

        public ViewResult AuthorsOfBook(Book book)
        {
            return View(bookRepo.GetAuthorsByBook(book));
        }

        public ViewResult BooksByAuthor(Author author)
        {
            return View(bookRepo.GetBooksByAuthor(author));
        }

        public ViewResult BookByTitle(string title)
        {
            return View(bookRepo.GetBookByTitle(title));
        }
    }
}

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Repositories;
using BookInfo.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookInfo.Controllers
{
    public class HomeController : Controller
    {
        private IAuthorRepository authorRepo;

        public HomeController(IAuthorRepository repo)
        {
            authorRepo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var readerVm = new ReaderViewModel { Authenticated = false };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                readerVm.FirstName = HttpContext.User.Identity.Name;
                //readerVm.LastName = HttpContext.User.F
                readerVm.Authenticated = true;
            }
            return View(readerVm);
        }

        public ViewResult Authors()
        {
            var authors = authorRepo.GetAllAuthors().ToList();
            return View(authors);
        }
    }
}

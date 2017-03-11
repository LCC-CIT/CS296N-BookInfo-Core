using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Repositories;
using Microsoft.AspNetCore.Identity;
using BookInfo.Models;
using BookInfo.Web.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookInfo.Controllers
{
    public class HomeController : Controller
    {
        private IAuthorRepository authorRepo;
        private UserManager<Reader> userManager;

        public HomeController(UserManager<Reader> um, IAuthorRepository repo)
        {
            authorRepo = repo;
            userManager = um;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var readerVm = new ReaderViewModel { Authenticated = false };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                readerVm.Name = HttpContext.User.Identity.Name;
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

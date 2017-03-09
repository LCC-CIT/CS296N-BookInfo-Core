using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookInfo.Web.Controllers
{
    public class AuthController : Controller
    {
        // GET: /<controller>/
        public IActionResult Register()
        {
            return View(new AuthViewModel() );
        }

        public IActionResult Login()
        {
            return View(new AuthViewModel());
        }
    }
}

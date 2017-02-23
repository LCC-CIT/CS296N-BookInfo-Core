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
            ViewBag.BookTitle = title;
            ViewBag.Id = id;
            // TODO Create a view model

            return View(new Review());
        }

        [HttpPost]
        public ViewResult ReviewForm(int rating, string body)
        {
            return null;
        }

    }
}

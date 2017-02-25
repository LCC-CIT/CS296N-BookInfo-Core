﻿using BookInfo.Models;
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
        public IActionResult ReviewForm(int id, int rating, string body)
        {
            // Get the full model object for the book being reviewed
            Book book = (from b in bookRepo.GetAllBooks()
                         where b.BookId == id
                         select b).FirstOrDefault<Book>();

            // add the review and save the book object to the db
            book.BookReviews.Add(new Review { Rating = rating, Body = body });
            bookRepo.Update(book);

            return RedirectToAction("Index", "Book");
        }

    }
}

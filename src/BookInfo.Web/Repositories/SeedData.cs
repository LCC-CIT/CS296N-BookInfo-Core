using BookInfo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Repositories
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            // Add a user for testing
            string firstName = "Bilbo";
            string lastName = "Baggins";
            string userName = firstName + lastName;
            string email = "BilboB@theshire.org";
            string password = "friend";
            string role = "Reviewers";

            UserManager<IdentityReader> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityReader>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            ReaderRepository readerRepo = new ReaderRepository(userManager, context);
            if (!context.Books.Any())
            {
                IdentityResult result;
                Reader reader = readerRepo.CreateReader(firstName, lastName, email, password, role, out result);

                Author author = new Author { Name = "J. R. R. Tolkien" };
                context.Authors.Add(author);
                Book book = new Book { Title = "Lord of the Rings", Date = DateTime.Parse("1/1/1937"), Genre = "Fantasy" }; // month/day/year
                book.Authors.Add(author);
                context.Books.Add(book);

                author = new Author { Name = "C. S. Lewis" };
                context.Authors.Add(author);
                book = new Book { Title = "The Lion, the Witch, and the Wardrobe", Date = DateTime.Parse("1/1/1950"), Genre = "Fantasy" };
                book.Authors.Add(author);
                context.Books.Add(book);

                author = new Author { Name = "Samuel Shellabarger" };
                book = new Book { Title = "Prince of Foxes", Date = DateTime.Parse("1/1/1947"), Genre = "Historical Fiction" };
                context.Authors.Add(author);
                book.Authors.Add(author);
                Review review = new Review { Body = "Amazing characters!", Rating = 5, BookReader = reader};
                book.BookReviews.Add(review);
                context.Books.Add(book);

                author = new Author { Name = "Wilbur Smith" };
                book = new Book { Title = "River God", Date = DateTime.Parse("1/1/1975"), Genre = "Historical Fiction" };
                context.Authors.Add(author);
                book.Authors.Add(author);
                review = new Review{Body = "Wow, really great book!", Rating = 5, BookReader = reader};
                book.BookReviews.Add(review);
                context.Books.Add(book);

                context.SaveChanges();
            }
        }
    }
}

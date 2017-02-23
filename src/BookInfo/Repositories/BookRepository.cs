using System.Collections.Generic;
using System.Linq;
using BookInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace BookInfo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext context;

        public BookRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books.Include(b => b.Authors).
                Include(b => b.BookReviews);
        }

        public Book GetBookByTitle(string title)
        {
            return context.Books.First(b => b.Title == title);
        }

        public List<Book> GetBooksByAuthor(Author author)
        {
            return (from b in context.Books
                   where b.Authors.Contains(author)
                   select b).ToList();
        }

        public List<Author> GetAuthorsByBook(Book book)
        {
            return book.Authors;
        }
    }
}

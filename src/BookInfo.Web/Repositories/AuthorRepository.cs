using System;
using System.Collections.Generic;
using BookInfo.Models;
using System.Collections;

namespace BookInfo.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private ApplicationDbContext context;

        public AuthorRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return context.Authors;
        }

        public Author GetAuthorByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAuthorsByBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}

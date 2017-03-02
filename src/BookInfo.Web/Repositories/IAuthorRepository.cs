using BookInfo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAuthorsByBook(Book book);
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorByName(string name);
    }
}

using BookInfo.Models;

namespace BookInfo.Repositories
{
    public interface IReaderRepository
    {
        Reader CreateReader(string firstName, string lastName, string eMail, string password, string role);
        IdentityReader GetIdentityReaderById(string id);
        IdentityReader GetIdentityReaderByName(string userName);
    }
}
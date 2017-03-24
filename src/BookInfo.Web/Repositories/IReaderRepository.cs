using BookInfo.Models;
using Microsoft.AspNetCore.Identity;

namespace BookInfo.Repositories
{
    public enum ReaderRole { Admins, Reviewers };

    public interface IReaderRepository
    {
        Reader CreateReader(string firstName, string lastName, string eMail, string password, ReaderRole role, out IdentityResult identityResult);
        IdentityReader GetIdentityReaderById(string id);
        Reader GetReaderByName(string userName);
        IdentityReader GetIdentityReaderByName(string userName);
    }
}
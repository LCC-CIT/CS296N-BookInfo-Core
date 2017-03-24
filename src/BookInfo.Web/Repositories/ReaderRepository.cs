using BookInfo.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace BookInfo.Repositories
{
    public class ReaderRepository : IReaderRepository
    {

        private UserManager<IdentityReader> userManager;
        private ApplicationDbContext context;

        public ReaderRepository(UserManager<IdentityReader> um, ApplicationDbContext ctx)
        {
            userManager = um;
            context = ctx;
        }

        public IdentityReader GetIdentityReaderByName(string userName)
        {
            var asyncTask = userManager.FindByNameAsync(userName);
            var identityReader = asyncTask.Result;
            return identityReader;
        }

        public IdentityReader GetIdentityReaderById(string id)
        {
            var asyncTask = userManager.FindByIdAsync(id);
            var identityReader = asyncTask.Result;
            return identityReader;
        }

        public Reader GetReaderByName(string userName)
        {
            return context.Readers.First(r => r.UserName == userName);
        }

        // Create an IdentityReader object and a Reader object that points to the IdentityReader
        public Reader CreateReader(string firstName, string lastName, string eMail, string password, 
            ReaderRole role, out IdentityResult identityResult)
        {
            Reader reader = null;
            identityResult = null;
            // Check to see if this IdentityReader already exists
            var asyncTask = userManager.FindByEmailAsync(eMail);
            asyncTask.Wait();
            var identityReader = asyncTask.Result;
            if (identityReader == null)
            {
                // Create a new IdentityReader
                identityReader = new IdentityReader
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = firstName + lastName,
                    Email = eMail
                };

                var asyncResultTask = userManager.CreateAsync(identityReader, password);
                asyncResultTask.Wait();
                identityResult = asyncResultTask.Result;
                if (identityResult.Succeeded)
                {
                    // Add a role to the IdentityReader
                    asyncResultTask = userManager.AddToRoleAsync(identityReader, role.ToString());
                    asyncResultTask.Wait();
                    identityResult = asyncResultTask.Result;
                    if (identityResult.Succeeded)
                    {
                        // Create a Reader that points to the IdentityReader
                        reader = new Reader();
                        reader.IdentityReaderId = identityReader.Id;
                        reader.UserName = identityReader.UserName;
                        context.Readers.Add(reader);
                        context.SaveChanges();
                    }
                }
                else
                {
                    identityResult = null;  // The Reader already exists
                }
            }

            return reader;
        }
    }
}

using BookInfo.Models;
using Microsoft.AspNetCore.Identity;

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

        // Use this constructor when creating a Reader for the first time
        //public ReaderRepository(UserManager<IdentityReader> um, string firstName, string lastName, string eMail, string password, string role)
        //{
        //    userManager = um;
        //    identityReader = new IdentityReader
        //    {
        //        FirstName = firstName,
        //        LastName = lastName,
        //        UserName = firstName + lastName,
        //        Email = eMail
        //    };
        //    var asyncTask = userManager.CreateAsync(identityReader, password);
        //    identityResult = asyncTask.Result;
        //    if (identityResult.Succeeded == true)
        //    {
        //        asyncTask = userManager.AddToRoleAsync(identityReader, role);
        //        identityResult = asyncTask.Result;
        //    }
        //}

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
                        context.Readers.Add(reader);
                    }
                }
                else
                {
                    identityResult = null;  // The Reader already exists
                }
            }

            return reader;
        }

        //public IdentityResult getIdentityResult()
        //{
        //    return identityResult;
        //}

        //[Required]
        //public string FirstName
        // {
        //     get
        //     {
        //         var asyncTask = userManager.FindByIdAsync(IdentityReaderId);
        //         return asyncTask.Result.FirstName;
        //     }
        //     set
        //     {
        //         var asyncTask = userManager.FindByIdAsync(IdentityReaderId);
        //         asyncTask.Result.FirstName = value;
        //     }
        // }

        // [Required]
        // public string LastName
        // {
        //     get
        //     {
        //         var asyncTask = userManager.FindByIdAsync(IdentityReaderId);
        //         return asyncTask.Result.LastName;
        //     }
        //     set
        //     {
        //         var asyncTask = userManager.FindByIdAsync(IdentityReaderId);
        //         asyncTask.Result.LastName = value;
        //     }
        // }
    }
}

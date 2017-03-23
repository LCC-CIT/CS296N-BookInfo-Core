using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Models;
using Microsoft.AspNetCore.Identity;
using BookInfo.Repositories;

namespace BookInfo.Web.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<IdentityReader> userManager;
        private SignInManager<IdentityReader> signInManager;
        private IReaderRepository readerRepo;

        public AuthController(UserManager<IdentityReader> usrMgr, SignInManager<IdentityReader> sim, IReaderRepository rRepo)
        {
            userManager = usrMgr;
            signInManager = sim;
            readerRepo = rRepo;
        }
         
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IdentityResult identityResult;
                Reader reader = readerRepo.CreateReader(vm.FirstName, vm.LastName, vm.Email, vm.Password,
                    ReaderRole.Reviewers, out identityResult);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
            }
            // We get here either if the model state is invalid or if create user fails
            return View(vm);
        }

        public ViewResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                IdentityReader identityReader = readerRepo.GetIdentityReaderByName(vm.UserName);
                if (identityReader != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                identityReader, vm.Password, false, false);
                    if (result.Succeeded)
                    {
                            // return to the action that required authorization, or to home if returnUrl is null
                            return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName),
                    "Invalid user or password");
            }
            return View(vm);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}


/* Notes:

1. There are not non-async (synchronous) versions of the UserManager and SignInManager async methods.
   If we were using MVC 5 or 6 (not Core MVC), we could have made our code easier to understand by using
   the non-async versions of the async methods. But since Core MVC is still so new the non-async versions 
   haven't been written yet-- they wanted to give us the higher performance options first. 
   So we have to use async methods and we have to put them in our own async method that returns a Task<> object.
   You can read about async methods here: https://msdn.microsoft.com/en-us/library/mt674882.asp

2. In the HttpPost Register method, look at the header. Note that it is an async method, 
    meaning that it runs on a separate thread and when it's finished, it returns a Task<IActionResult> object.
    Within the Register method, in a statement where I call an async method, like this one:
        IdentityResult result = await userManager.CreateAsync(user, vm.Password);
    I use the await keyword so that execution will pause until the CreateAsync method, 
    which is running on a separate thread, finishes.

3. Task<>: The Task class represents a single operation that does not return a value 
   and that usually executes asynchronously. Task objects are one of the central components 
   of the task-based asynchronous pattern first introduced in the .NET Framework 4. 
   Because the work performed by a Task object typically executes asynchronously on a thread pool 
   thread rather than synchronously on the main application thread, you can use the Status property, 
   as well as the IsCanceled, IsCompleted, and IsFaulted properties, to determine the state of a task. 
   From: https://msdn.microsoft.com/en-us/library/system.threading.tasks.task(v=vs.110).aspx

 */

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Models;
using Microsoft.AspNetCore.Identity;

namespace BookInfo.Web.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<Reader> userManager;
        private SignInManager<Reader> signInManager;

        public AuthController(UserManager<Reader> usrMgr, SignInManager<Reader> sim)
        {
            userManager = usrMgr;
            signInManager = sim;
        }
         
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Reader user = new Reader
                {
                    UserName = vm.FirstName + vm.LastName,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Email = vm.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Reviewers");
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
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
                Reader user = await userManager.FindByNameAsync(vm.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                user, vm.Password, false, false);
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

1. There is not a non-async (synchronous) version of UserManager.CreateAsync
  
2. Task: The Task class represents a single operation that does not return a value 
   and that usually executes asynchronously. Task objects are one of the central components 
   of the task-based asynchronous pattern first introduced in the .NET Framework 4. 
   Because the work performed by a Task object typically executes asynchronously on a thread pool 
   thread rather than synchronously on the main application thread, you can use the Status property, 
   as well as the IsCanceled, IsCompleted, and IsFaulted properties, to determine the state of a task. 
   From: https://msdn.microsoft.com/en-us/library/system.threading.tasks.task(v=vs.110).aspx
 
 */

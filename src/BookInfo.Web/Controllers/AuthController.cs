﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookInfo.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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
            return View(new AuthViewModel() );
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthViewModel vm)
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
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            // We get here either if the model state is invalid or if xreate user fails
            return View(vm);
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel details)
        {
            if (ModelState.IsValid)
            {
                Reader user = await userManager.FindByNameAsync(details.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName),
                    "Invalid user or password");
            }
            return View(details);
        }
    }
}

/* Notes:

1. There is not a non-async version of UserManager.CreateAsync
  
2. Task: The Task class represents a single operation that does not return a value 
   and that usually executes asynchronously. Task objects are one of the central components 
   of the task-based asynchronous pattern first introduced in the .NET Framework 4. 
   Because the work performed by a Task object typically executes asynchronously on a thread pool 
   thread rather than synchronously on the main application thread, you can use the Status property, 
   as well as the IsCanceled, IsCompleted, and IsFaulted properties, to determine the state of a task. 
   From: https://msdn.microsoft.com/en-us/library/system.threading.tasks.task(v=vs.110).aspx
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Books.Models;
using WebApplication_Books.Models.ViewModels;

namespace WebApplication_Books.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    Email = model.Email,
                    UserName = model.Email,
                    PasswordHash = model.Password,
                };

                var creationResult = await userManager.CreateAsync(user, model.Password);

                if (creationResult.Succeeded)
                {
                    return Content("Creation Success");
                }
            }
            return View("Error", model);
        }
    }
}

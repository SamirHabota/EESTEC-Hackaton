using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Viewmodels.Account;
using Web.Viewmodels.SharedVM;
using Web.Viewmodels.UserVM;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly VisyLrnContext _context;
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public AccountController(VisyLrnContext context, UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("/Login")]
        public IActionResult Login(LoginVM Model)
        {
            return View(Model);
        }

        public async Task<IActionResult> LoginAccount(LoginVM Model)
        {

            var account = _context.Account.FirstOrDefault(w => string.Equals(w.NormalizedUserName, Model.Username, StringComparison.CurrentCultureIgnoreCase));

            if (account == null)
                return View("Login", new LoginVM
                {
                    Username = Model.Username,
                    Error = "Incorrect username or password. Please try again."
                });

            Microsoft.AspNetCore.Identity.SignInResult response = await _signInManager.PasswordSignInAsync(account.UserName, Model.Password,
                Model.RememberMe, false);

            if (!response.Succeeded)
            {
                LoginVM model = new LoginVM
                {
                    Username = Model.Username,
                    Error = "Incorrect username or password. Please try again."
                };
                return View("Login", model);
            }

            return Redirect("/");
        }

        [Route("/Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();            
            return Redirect("/");

        }
    }
}
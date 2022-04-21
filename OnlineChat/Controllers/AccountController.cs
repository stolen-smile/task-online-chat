using Microsoft.AspNetCore.Mvc;
using OnlineChat.Mock;
using OnlineChat.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineChat.Models.DTO;

namespace OnlineChat.Controllers
{
    public class AccountController : Controller
    {
        private IRepository _context;

        public AccountController(IRepository context)
        {
            _context = context;
        }

        
        public IActionResult Index(UserAndContactsViewModel viewModel)
        {
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user =  _context.Users.FirstOrDefault(u => u.NickName == model.NickName);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация
                    //creat viewModel
                    var viewModel = new UserAndContactsViewModel
                    {
                        NickName = user.NickName,
                        Contacts = new List<string>()
                    };
                    foreach (var message in user.Messages)
                    {
                        viewModel.Contacts.Add(message.AddresseeUser.NickName);
                    }
                    //redirect to chat
                    return RedirectToAction("Index", "Account", viewModel);// переадресация на метод Index
                }
                ModelState.AddModelError("", "Bad nickname");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.NickName),           
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}

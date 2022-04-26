using Microsoft.AspNetCore.Mvc;
using OnlineChat.Data;
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
        private Context _context;

        public AccountController(Context context)
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
                User user =  _context.Users.Include(m=>m.Messages).Include(m=>m.Groups)
                    .FirstOrDefault(u => u.NickName == model.NickName);
                if (user != null)
                {
                    await Authenticate(user); 
                    //creat viewModel
                    var viewModel = new UserAndContactsViewModel
                    {
                        NickName = user.NickName,
                        Contacts = new List<string>(),
                        Groups = new List<string>()                        
                    };
                    foreach (var message in user.Messages)
                    {
                        var m = _context.Messages.Include(m=>m.AddresseeUser)
                            .FirstOrDefault(m=>m.Id==message.Id);

                        if (m.AddresseeUser is null)
                            continue;

                        if (!viewModel.Contacts.Contains(m.AddresseeUser.NickName))
                        {
                            viewModel.Contacts.Add(m.AddresseeUser.NickName);
                        }                                   
                    }
                    if (user.Groups != null)
                    {
                        foreach (var g in user.Groups)
                        {
                            viewModel.Groups.Add(g.GroupName);
                        }
                    }
                    else
                    {
                        viewModel.Groups = null;
                    }
                    //redirect to chat
                    return RedirectToAction("Index", "Account", viewModel);
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

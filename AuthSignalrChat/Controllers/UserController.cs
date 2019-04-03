using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthSignalrChat.Models;
using AuthSignalrChat.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthSignalrChat.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromServices]IUserService userService, LoginModel model)
        {
            var user = userService.GetUsers().FirstOrDefault(it => it.UserName == model.UserName && it.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "invalid userName or password");

                return View(model);
            }

            var chaims = new[] { new Claim("UserName", user.UserName), new Claim("UserID", user.Id) };
            var chaimsIdentity = new ClaimsIdentity(chaims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(chaimsIdentity);

            // 注册标识
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal).Wait();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();

            return RedirectToAction(nameof(Index));
        }
    }
}
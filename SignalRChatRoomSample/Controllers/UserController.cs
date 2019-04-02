using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalRChatRoomSample.Models;
using SignalRChatRoomSample.Services;

namespace SignalRChatRoomSample.Controllers
{
    public class UserController : Controller
    {
        // [Authorize]
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
            var user = userService.GetUsers()
                .FirstOrDefault(it => it.UserName.Equals
                (model.UserName, StringComparison.InvariantCultureIgnoreCase) &&
                 it.Password.Equals(model.Password, StringComparison.InvariantCultureIgnoreCase));

            if (user == null)
            {
                ModelState.AddModelError("error", "invalid userName or password");

                return View(model);
            }

            // 这是一些信息
            var chaims = new[] { new Claim("UserName", user.UserName), new Claim("UserID", user.Id.ToString()) };
            // 通过信息制造一个证件【标识】，这里通过cookie认证
            var chaimsIdentity = new ClaimsIdentity(chaims, CookieAuthenticationDefaults.AuthenticationScheme);
            // 拿到最终的证件【标识】
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(chaimsIdentity);

            // 注册标识
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal).Wait();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction(nameof(Login));
        }
    }
}
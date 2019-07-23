using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CatalogWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CatalogWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            var user = HttpContext.User;
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (model.Email=="admin@camp.com" && model.Password=="12345")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,model.Email)
                };

                var userIdentity = new ClaimsIdentity(claims,"login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("List","Category");
            }
            else
            {
                ViewBag.Error = "Bilgileri kontrol ediniz";
            }
            return View(model);
        }
    }
}